using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.New;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QLSQ.Application.Catalog.NewImage;
using QLSQ.Application.Catalog.SiQuans;

namespace QLSQ.Application.Catalog.New
{
    public class NewServices : INewServices
    {
        public readonly QL_SiQuanDBContext _context;
        public readonly INewImageServices _newImageServices;
        public NewServices(QL_SiQuanDBContext context,INewImageServices newImageServices)
        {
            _context = context;
            _newImageServices = newImageServices;
        }

        public async Task<APIResult<bool>> Create(NewCreateRequest request)
        {
            var news = new QLSQ.Data.Entities.New()
            {
                NewName = request.NewName,
                NewContent = request.NewContent,
                NewDatePost = DateTime.Now,
                NewCount = request.NewCount
            };
            if(request.FormFile != null)
            {
                news.NewImages = new List<Data.Entities.NewImage>()
                {
                    new QLSQ.Data.Entities.NewImage()
                    {
                        NewID = news.NewID,
                        ImagePath = await _newImageServices.SaveFile(request.FormFile),
                        DateCreated = DateTime.Now,
                        FileSize = request.FormFile.Length
                    }
                };
            }
            _context.News.Add(news);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<bool>> Delete(int NewID)
        {
            var news = await _context.News.FirstOrDefaultAsync(x => x.NewID == NewID);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            var deleteNewImage = await _newImageServices.DeleteNewImageByNewID(NewID);
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<NewDetailsViewModel>> Details(int NewID)
        {         
            var newsDetail = await (from news in _context.News
                                    where news.NewID == NewID
                                    select new NewDetailsViewModel() 
                                    {
                                        NewID = news.NewID,
                                        NewName = news.NewName,
                                        NewContent = news.NewContent,
                                        NewDatePost = news.NewDatePost,
                                        NewCount = news.NewCount
                                    }).FirstOrDefaultAsync();
            var imagePath = await _newImageServices.GetImagePathByNewID(NewID);
            if (imagePath.ResultObj != null)
                newsDetail.ImagePath = imagePath.ResultObj;
            return new APISuccessedResult<NewDetailsViewModel>(newsDetail);
        }

        public async Task<APIResult<bool>> Edit(int NewID, NewUpdateRequest request)
        {
            var news = await _context.News.FirstOrDefaultAsync(x=>x.NewID == NewID);
            news.NewName = request.NewName;
            news.NewContent = request.NewContent;
            news.NewDatePost = request.NewDatePost;
            news.NewCount = request.NewCount;
            if(request.FormFile != null)
            {
                var newimage = await _context.NewImages.FirstOrDefaultAsync(x=>x.NewID == NewID);
                if(newimage != null)
                {
                    newimage.DateCreated = DateTime.Now;
                    newimage.ImagePath = await _newImageServices.SaveFile(request.FormFile);
                    newimage.FileSize = request.FormFile.Length;
                }
                else
                {
                    var newNewImage = new QLSQ.Data.Entities.NewImage()
                    {
                        NewID = NewID,
                        ImagePath = await _newImageServices.SaveFile(request.FormFile),
                        DateCreated = DateTime.Now,
                        FileSize = request.FormFile.Length
                    };
                    _context.NewImages.Add(newNewImage);
                    await _context.SaveChangesAsync();
                }
            }
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<PageResult<NewViewModel>>> GetAllWithPaging(GetNewPagingRequest request)
        {
            var query = from news in _context.News
                        select new NewViewModel()
                        {
                            NewID = news.NewID,
                            NewName = news.NewName,
                            NewContent = news.NewContent,
                            NewDatePost = news.NewDatePost,
                            NewCount = news.NewCount
                        };
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.NewName.Contains(request.keyword));
            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new NewViewModel()
                {
                    NewID = x.NewID,
                    NewName = x.NewName,
                    NewContent = x.NewContent,
                    NewDatePost = x.NewDatePost,
                    NewCount = x.NewCount
                }).ToListAsync();
            var pageResult = new PageResult<NewViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<NewViewModel>>(pageResult);
        }

        public async Task<APIResult<List<NewViewModel>>> GetListNewAutoComplete(string prefix)
        {
            var query = await (from news in _context.News
                              where news.NewName.Contains(prefix)
                              select new NewViewModel() 
                              {
                                NewID = news.NewID,
                                NewName = news.NewName
                              }).ToListAsync();
           
            return new APISuccessedResult<List<NewViewModel>>(query);
        }
    }
}
