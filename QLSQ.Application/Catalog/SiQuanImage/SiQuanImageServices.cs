using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.SiQuanImage;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QLSQ.Application.Catalog.SiQuans;

namespace QLSQ.Application.Catalog.SiQuanImage
{
    public class SiQuanImageServices : ISiQuanImageServices
    {
        public readonly QL_SiQuanDBContext _context;
        public readonly IManageSiQuanServices _manageSiQuanServices;

        public SiQuanImageServices(QL_SiQuanDBContext context,IManageSiQuanServices manageSiQuanServices)
        {
            _context = context;
            _manageSiQuanServices = manageSiQuanServices;
        }

        public async Task<APIResult<bool>> Create(SiQuanImageCreateRequest request)
        {
            var sqImage = new QLSQ.Data.Entities.SiQuanImage()
            {
                IDSQ = request.IDSQ,
                Caption = request.Caption,
                IsDefault = request.IsDefault,
                FileSize = request.ImageFile.Length,
                ImagePath = await _manageSiQuanServices.SaveFile(request.ImageFile)
            };
            _context.SiQuanImages.Add(sqImage);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<bool>> Delete(int IDImage)
        {
            var sqImage = await _context.SiQuanImages.FirstOrDefaultAsync(x => x.IDImage == IDImage);
            _context.SiQuanImages.Remove(sqImage);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<SiQuanImageViewModel>> Details(int IDImage)
        {
            var sqImageViewModel = await (from sqimage in _context.SiQuanImages
                          join sq in _context.SiQuans
                          on sqimage.IDSQ equals sq.IDSQ
                          where sqimage.IDImage == IDImage
                          select new SiQuanImageViewModel()
                          {
                              IDImage = sqimage.IDImage,
                              IDSQ = sqimage.IDSQ,
                              HoTenSQ = sq.HoTen,
                              ImagePath = sqimage.ImagePath,
                              Caption = sqimage.Caption,
                              IsDefault = sqimage.IsDefault,
                              DateCreated = sqimage.DateCreated,
                              FileSize = sqimage.FileSize
                          }).FirstOrDefaultAsync();
            return new APISuccessedResult<SiQuanImageViewModel>(sqImageViewModel);
        }

        public async Task<APIResult<bool>> Edit(int IDImage, SiQuanImageUpdateRequest request)
        {
            var siquanImage = await _context.SiQuanImages.FirstOrDefaultAsync(x => x.IDImage == IDImage);
            siquanImage.Caption = request.Caption;
            siquanImage.IsDefault = request.IsDefault;
            siquanImage.DateCreated = request.DateCreated;
            if (request.ImageFile != null)
            {
                siquanImage.DateCreated = DateTime.Now;
                siquanImage.ImagePath = await _manageSiQuanServices.SaveFile(request.ImageFile);
                siquanImage.FileSize = request.ImageFile.Length;
            }
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<PageResult<SiQuanImageViewModel>>> GetAllWithPaging(GetSiQuanImagePagingRequest request)
        {
            var query = from sqimage in _context.SiQuanImages
                        join sq in _context.SiQuans
                        on sqimage.IDSQ equals sq.IDSQ
                        select new SiQuanImageViewModel()
                        {
                            IDImage = sqimage.IDImage,
                            IDSQ = sqimage.IDSQ,
                            HoTenSQ = sq.HoTen,
                            ImagePath = sqimage.ImagePath,
                            Caption = sqimage.Caption,
                            IsDefault = sqimage.IsDefault,
                            DateCreated = sqimage.DateCreated,
                            FileSize = sqimage.FileSize
                        };
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.HoTenSQ.Contains(request.keyword) || x.Caption.Contains(request.keyword));
            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new SiQuanImageViewModel()
                {
                    IDImage = x.IDImage,
                    IDSQ = x.IDSQ,
                    HoTenSQ = x.HoTenSQ,
                    ImagePath = x.ImagePath,
                    Caption = x.Caption,
                    IsDefault = x.IsDefault,
                    DateCreated = x.DateCreated,
                    FileSize = x.FileSize
                }).ToListAsync();
            var pageResult = new PageResult<SiQuanImageViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<SiQuanImageViewModel>>(pageResult);
        }
    }
}
