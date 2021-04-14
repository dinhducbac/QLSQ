using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QLSQ.Application.Common;
using QLSQ.Data.EF;
using QLSQ.Data.Entities;
using QLSQ.Utilities.Exceptions;
using QLSQ.ViewModel.Catalogs.QLDangVien;
using QLSQ.ViewModel.Catalogs.SiQuan;
using QLSQ.ViewModel.Catalogs.SiQuanImage;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.SiQuans
{
    public class ManageSiQuanServices : IManageSiQuanServices
    {
        private readonly IStorageServices _storageServices;
        private readonly QL_SiQuanDBContext _context;
        public ManageSiQuanServices(QL_SiQuanDBContext context, IStorageServices storageServices)
        {
            _context = context;
            _storageServices = storageServices;
        }
        //------------------------------------------------------------------------------------------------
        //Part of SiQuanImage

        public async Task<int> AddImages(int SiQuanID, SiQuanImageCreateRequest request)
        {
            var siquanimage = new SiQuanImage()
            {
                IDSQ = SiQuanID,
                Caption = request.Caption,
                DateCreated = DateTime.Now,
                IsDefault = request.IsDefault
            };
            if (request.ImageFile != null)
            {
                siquanimage.ImagePath = await this.SaveFile(request.ImageFile);
                siquanimage.FileSize = request.ImageFile.Length;
            }
            _context.SiQuanImages.Add(siquanimage);
            await _context.SaveChangesAsync();
            return siquanimage.IDImage;
        }

        public async Task<int> UpdateImages(int ImageID, SiQuanImageUpdateRequest request)
        {
            var siquanimage = await _context.SiQuanImages.FirstOrDefaultAsync(x => x.IDImage == request.IDImage);
            if (siquanimage == null)
                throw new QLSQException($"Không thể tìm thấy ảnh có id: {request.IDImage}");
            siquanimage.IDSQ = request.IDSQ;
            siquanimage.ImagePath = await this.SaveFile(request.ImageFile);
            siquanimage.FileSize = request.ImageFile.Length;
            siquanimage.Caption = request.Caption;
            siquanimage.IsDefault = request.IsDefault;
            _context.SiQuanImages.Update(siquanimage);
            return await _context.SaveChangesAsync();
        }
        public async Task<List<SiQuanImageViewModel>> GetListImage(int SiQuanID)
        {
            return await _context.SiQuanImages.Where(x => x.IDSQ == SiQuanID)
            .Select(
                    i => new SiQuanImageViewModel()
                    {
                        IDImage = i.IDImage,
                        ImagePath = i.ImagePath,
                        Caption = i.Caption,
                        DateCreated = i.DateCreated,
                        IsDefault = i.IsDefault,
                        FileSize = i.FileSize
                    }
                ).ToListAsync();
        }
        public async Task<int> RemoveImages(int ImageID)
        {
            var siquanimage = await _context.SiQuanImages.FindAsync(ImageID);
            if (siquanimage == null)
                throw new QLSQException($"Không thể tìm thấy ảnh có ID: {ImageID}");
            _context.SiQuanImages.Remove(siquanimage);
            return await _context.SaveChangesAsync();
        }

        public async Task<SiQuanImageViewModel> GetImageByID(int SiQuanImageID)
        {
            var siquanImage = await _context.SiQuanImages.FindAsync(SiQuanImageID);
            if (siquanImage == null)
                throw new QLSQException($"Không thể tìm thấy ảnh có id là: {SiQuanImageID}");
            var siquanImageMd = new SiQuanImageViewModel();
            siquanImageMd.IDImage = siquanImage.IDImage;
            siquanImageMd.IDSQ = siquanImage.IDSQ;
            siquanImageMd.ImagePath = siquanImage.ImagePath;
            siquanImageMd.Caption = siquanImage.Caption;
            siquanImageMd.IsDefault = siquanImage.IsDefault;
            siquanImageMd.DateCreated = siquanImage.DateCreated;
            siquanImageMd.FileSize = siquanImage.FileSize;
            return siquanImageMd;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var orignalfilename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('*');
            //var filename = $"{Guid.NewGuid()}{Path.GetExtension(orignalfilename)}";
            var filename = orignalfilename.Substring(1, orignalfilename.Length - 2);
            await _storageServices.SaveFileAsync(file.OpenReadStream(), filename);
            //return filename;
            return filename;
        }
        //------------------------------------------------------------------------------------------------
        // Part of SiQuan
        public async Task<APIResult<int>> Create(SiQuanCreateRequest request)
        {
            var siquan = new QLSQ.Data.Entities.SiQuan()
            {
                UserId = request.UserId,
                HoTen = request.HoTen,
                NgaySinh = request.NgaySinh,
                GioiTinh = request.GioiTinh,
                QueQuan = request.QueQuan,
                SDT = request.SDT
            };
            var test = siquan.UserId;
            if(request.ThumbnailImage != null)
            {
                siquan.SiQuanImages = new List<SiQuanImage>()
                {
                    new SiQuanImage()
                    {
                        IDSQ = siquan.IDSQ,
                        Caption = request.HoTen,
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                    }
                };
            }
            _context.SiQuans.Add(siquan);
           await _context.SaveChangesAsync();
            return new APISuccessedResult<int>(siquan.IDSQ);
        }

        public async Task<APIResult<string>> Detele(int IDSQ)
        {
            var siquan = await _context.SiQuans.FindAsync(IDSQ);
            if (siquan == null)
            {
                return new APIErrorResult<string>($"Không thể tìm thấy sĩ quan có Id: {IDSQ}");
            }
            var thumbnailImage = await _context.SiQuanImages.FirstOrDefaultAsync(x => x.IDSQ == IDSQ);
            if (thumbnailImage != null)
            {
                await _storageServices.DeleteFileAsync(thumbnailImage.ImagePath);
            }
            _context.SiQuans.Remove(siquan);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<string>("Xóa tài khoản thành công!");
        }



        public async Task<APIResult<PageResult<SiQuanViewModel>>> GetAllPaging(GetManageSiQuanPagingRequest request)
        {
            var query = from p in _context.SiQuans select p;
            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = _context.SiQuans.Where(p => p.HoTen.Contains(request.keyword) || p.IDSQ.Equals(request.keyword));
            }
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new SiQuanViewModel()
                {
                    IDSQ = x.IDSQ,
                    UserId = x.UserId,
                    HoTen = x.HoTen,
                    NgaySinh = x.NgaySinh,
                    GioiTinh = x.GioiTinh,
                    QueQuan = x.QueQuan,
                    SDT = x.SDT
                }).ToListAsync();
            var pageResult = new PageResult<SiQuanViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<SiQuanViewModel>>(pageResult);
        }

        public async Task<APIResult<bool>> Update(int IDSQ,SiQuanUpdateRequest request)
        {
            var siquan = await _context.SiQuans.FirstOrDefaultAsync(x => x.IDSQ == IDSQ);
            if (siquan == null)
                return new APIErrorResult<bool>($"Không thể tìm thấy sĩ quan có ID: {IDSQ}");
            siquan.UserId = request.UserId;
            siquan.HoTen = request.HoTen;
            siquan.NgaySinh = request.NgaySinh;
            siquan.GioiTinh = request.GioiTinh;
            siquan.QueQuan = request.QueQuan;
            siquan.SDT = request.SDT;
           // _context.SiQuans.Update(siquan);
            if(request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.SiQuanImages.FirstOrDefaultAsync(x => x.IsDefault == true && x.IDSQ == request.IDSQ);
                if (thumbnailImage != null)
                {
                       thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                       thumbnailImage.FileSize = request.ThumbnailImage.Length;
                       _context.SiQuanImages.Update(thumbnailImage);
                }
            }
          await _context.SaveChangesAsync();
          return new APISuccessedResult<bool>();
        }

        public async Task<APIResult<SiQuanViewModel>> GetById(int IDSQ)
        {
            var siquan = await _context.SiQuans.FindAsync(IDSQ);
            if (siquan == null)
                throw new QLSQException($"Không tìm thấy sĩ quan nào có ID = {IDSQ} ");
            var siquanmd = new SiQuanViewModel();
            siquanmd.IDSQ = siquan.IDSQ;
            siquanmd.UserId = siquan.UserId;
            siquanmd.HoTen = siquan.HoTen;
            siquanmd.NgaySinh = siquan.NgaySinh;
            siquanmd.GioiTinh = siquan.GioiTinh;
            siquanmd.QueQuan = siquan.QueQuan;
            siquanmd.SDT = siquan.SDT;
            return new APISuccessedResult<SiQuanViewModel>(siquanmd);
        }

        public async Task<APIResult<List<SiQuanViewModel>>> GetSiQuanNotInQLDangVien()
        {
            List<SiQuanViewModel> siQuanViewModels = new List<SiQuanViewModel>();
            var query = from sq in _context.SiQuans 
                        where !_context.QLDangViens.Any(qldv=>(qldv.IDSQ==sq.IDSQ))
                        select sq;
            foreach(var data in query)
            {
                var sqModel = new SiQuanViewModel()
                {
                    IDSQ = data.IDSQ,
                    HoTen = data.HoTen
                };
                siQuanViewModels.Add(sqModel);
            }
            return new APISuccessedResult<List<SiQuanViewModel>>(siQuanViewModels); 
        }

        public async Task<APIResult<List<SiQuanViewModel>>> GetAllWithoutPaging()
        {
            List<SiQuanViewModel> listsqvm = new List<SiQuanViewModel>();
            var query = _context.SiQuans;
            foreach(var data in query)
            {
                var siquanvm = new SiQuanViewModel()
                {
                    IDSQ = data.IDSQ,
                    HoTen = data.HoTen
                };
                listsqvm.Add(siquanvm);
            }
            return new APISuccessedResult<List<SiQuanViewModel>>(listsqvm);
        }

        public async Task<APIResult<List<SiQuanInQLLuongViewModel>>> GetListSiQuanAutocomplete(string preconfix)
        {
            List<SiQuanInQLLuongViewModel> listsqvm = new List<SiQuanInQLLuongViewModel>();
            var query = from sq in _context.SiQuans
                        join qlcv in _context.QLChucVus
                        on sq.IDSQ equals qlcv.IDSQ
                        join qh in _context.QuanHams
                        on qlcv.IDQH equals qh.IDQH
                        join hslqh in _context.HeSoLuongTheoQuanHams
                        on qh.IDQH equals hslqh.IDQH
                        join cv in _context.ChucVus
                        on qlcv.IDCV equals cv.IDCV
                        join hspccv in _context.HeSoPhuCapTheoChucVus
                        on cv.IDCV equals hspccv.IDCV          
                        where sq.HoTen.StartsWith(preconfix) && !_context.QLLuongs.Any(x=>x.IDSQ == sq.IDSQ)
                        select new SiQuanInQLLuongViewModel
                        { 
                            IDSQ = sq.IDSQ,
                            HoTen = sq.HoTen,
                            IDQH = qlcv.IDQH,
                            TenQH = qh.TenQH,
                            IDHeSoLuongQH = hslqh.IDHeSoLuongQH,
                            HeSoLuongQH = hslqh.HeSoLuong,
                            IDCV = qlcv.IDCV,
                            TenCV = cv.TenCV,
                            IDHeSoPhuCapCV = hspccv.IDHeSoPhuCapCV,
                            HeSoPhuCapCV = hspccv.HeSoPhuCap
                        };
            var queryGetLuongCB = await (from lcb in _context.LuongCoBans select lcb).FirstOrDefaultAsync();
            foreach (var data in query)
            {
                var siquanvm = new SiQuanInQLLuongViewModel()
                {
                    IDSQ = data.IDSQ,
                    HoTen = data.HoTen,
                    IDQH = data.IDQH,
                    TenQH = data.TenQH,
                    IDHeSoLuongQH = data.IDHeSoLuongQH,
                    HeSoLuongQH = data.HeSoLuongQH,
                    IDCV = data.IDCV,
                    TenCV = data.TenCV,
                    IDHeSoPhuCapCV = data.IDHeSoPhuCapCV,
                    HeSoPhuCapCV = data.HeSoPhuCapCV
                };
                siquanvm.IDLuongCB = queryGetLuongCB.IDLuongCB;
                siquanvm.LuongCB = queryGetLuongCB.LuongCB;
                siquanvm.Luong = Convert.ToUInt64(siquanvm.HeSoLuongQH * siquanvm.LuongCB + siquanvm.HeSoPhuCapCV * siquanvm.LuongCB);
                listsqvm.Add(siquanvm);
            }
            return new APISuccessedResult<List<SiQuanInQLLuongViewModel>>(listsqvm);
        }

        public async Task<APIResult<List<SiQuanViewModel>>> GetListSiQuanNotInQLChucVuAutocomplete(string prefix)
        {
            var query = from sq in _context.SiQuans
                        where !_context.QLChucVus.Any(x => x.IDSQ == sq.IDSQ) && sq.HoTen.StartsWith(prefix)
                        select sq;
            var list = new List<SiQuanViewModel>();
            foreach (var data in query)
            {
                var sq = new SiQuanViewModel()
                {
                    IDSQ = data.IDSQ,
                    HoTen = data.HoTen
                };
                list.Add(sq);
            }
            return new APISuccessedResult<List<SiQuanViewModel>>(list);
        }
    }
}
