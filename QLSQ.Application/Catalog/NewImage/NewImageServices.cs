using Microsoft.AspNetCore.Http;
using QLSQ.Application.Common;
using System;
using System.Collections.Generic;
using QLSQ.Utilities.Exceptions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using QLSQ.ViewModel.Common;
using QLSQ.ViewModel.Catalogs.NewImage;
using QLSQ.Data.EF;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLSQ.Application.Catalog.NewImage
{
    public class NewImageServices : INewImageServices
    {
        public readonly INewImageStorageService _newImageStorageService;
        public readonly QL_SiQuanDBContext _context;
        public NewImageServices(INewImageStorageService newImageStorageService, QL_SiQuanDBContext context)
        {
            _newImageStorageService = newImageStorageService;
            _context = context;
        }

        public async Task<APIResult<bool>> Create(NewImageCreateRequest request)
        {
            if (request.FormFile != null)
            {
                var newimage = new QLSQ.Data.Entities.NewImage()
                {
                    NewID = request.NewID,
                    ImagePath = await this.SaveFile(request.FormFile),
                    DateCreated = DateTime.Now,
                    FileSize = request.FormFile.Length
                };
                _context.NewImages.Add(newimage);
                await _context.SaveChangesAsync();
                return new APISuccessedResult<bool>(true);
            }
            return new APIErrorResult<bool>("Thất bại");
        }

        public async Task<APIResult<bool>> Delete(int NewImageID)
        {
            var newimage = await _context.NewImages.FirstOrDefaultAsync(x=>x.NewImageID ==  NewImageID);
            _context.NewImages.Remove(newimage);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<bool>> DeleteNewImageByNewID(int NewID)
        {
            var query = from newimage in _context.NewImages
                        where newimage.NewID == NewID
                        select newimage;
            foreach (var data in query)
            {
                _context.NewImages.Remove(data);
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<NewImageDetailsModel>> Details(int NewImageID)
        {
            var newimageDetailsModel = await (from newimage in _context.NewImages
                                              join news in _context.News
                                              on newimage.NewID equals news.NewID
                                              where newimage.NewImageID == NewImageID
                                              select new NewImageDetailsModel() 
                                              {
                                                   NewImageID = NewImageID,
                                                   NewID = newimage.NewID,
                                                   NewName = news.NewName,
                                                   ImagePath = newimage.ImagePath,
                                                   DateCreated = newimage.DateCreated,
                                                   FileSize = newimage.FileSize
                                              }).FirstOrDefaultAsync();
            return new APISuccessedResult<NewImageDetailsModel>(newimageDetailsModel);
        }

        public async Task<APIResult<bool>> Edit(int NewImageID, NewImageUpdateRequest request)
        {
            var newImage = await _context.NewImages.FirstOrDefaultAsync(x => x.NewImageID == NewImageID);
            if(request.FormFile != null)
            {
                newImage.ImagePath = await this.SaveFile(request.FormFile);
                newImage.DateCreated = request.DateCreated;
                newImage.FileSize = request.FormFile.Length;
                await _context.SaveChangesAsync();
                return new APISuccessedResult<bool>(true);
            }
            return new APIErrorResult<bool>("Thất bại");
        }

        public async Task<APIResult<PageResult<NewImageViewModel>>> GetAllWithPaging(GetNewImagePagingRequest request)
        {
            var query = from newimage in _context.NewImages
                        join news in _context.News
                        on newimage.NewID equals news.NewID
                        select new NewImageViewModel()
                        {
                            NewImageID = newimage.NewImageID,
                            NewID = newimage.NewID,
                            NewName = news.NewName,
                            ImagePath = newimage.ImagePath,
                            DateCreated = newimage.DateCreated,
                            FileSize = newimage.FileSize
                        };
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.NewImageID.ToString().Contains(request.keyword) || x.NewID.ToString().Contains(request.keyword)
                || x.NewName.Contains(request.keyword));
            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new NewImageViewModel()
                {
                    NewImageID = x.NewImageID,
                    NewID = x.NewID,
                    NewName = x.NewName,
                    ImagePath = x.ImagePath,
                    DateCreated = x.DateCreated,
                    FileSize = x.FileSize
                }).ToListAsync();
            var pageResult = new PageResult<NewImageViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<NewImageViewModel>>(pageResult);
        }

        public async Task<APIResult<string>> GetImagePathByNewID(int NewID)
        {
            var imagepath = await (from newimage in _context.NewImages
                        where newimage.NewID == NewID
                        select newimage.ImagePath).FirstOrDefaultAsync();
            return new APISuccessedResult<string>(imagepath);
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            var orignalfilename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('*');
            //var filename = $"{Guid.NewGuid()}{Path.GetExtension(orignalfilename)}";
            var filename = orignalfilename.Substring(0, orignalfilename.Length);
            await _newImageStorageService.SaveFileAsync(file.OpenReadStream(), filename);
            //return filename;
            return filename;
        }
    }
}
