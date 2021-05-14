
using QLSQ.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QLSQ.ViewModel.Common;
using QLSQ.ViewModel.Catalogs.SiQuan;

namespace QLSQ.Application.Catalog.SiQuan
{
    public class PublicSiQuanServices : IPublicSiQuanServices
    {
        private readonly QL_SiQuanDBContext _context;
        public PublicSiQuanServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }

        public async Task<List<SiQuanViewModel>> GetAll()
        {
            var query = from p in _context.SiQuans select p;
            var data = await query.Select(x => new SiQuanViewModel()
                {
                    IDSQ = x.IDSQ,
                    UserId = x.UserId,
                    HoTen = x.HoTen,
                    NgaySinh = x.NgaySinh,
                    GioiTinh = x.GioiTinh,
                    QueQuan = x.QueQuan,
                    SDT = x.SDT
                }).ToListAsync();
            return data;
        }

        public async Task<PageResult<SiQuanViewModel>> GetAllBySiQuanId(GetPublicSiQuanPagingRequest request)
        {

            var query = from p in _context.SiQuans select p;
            if (request.IDSQ.HasValue && request.IDSQ.Value > 0)
            {
                query = query.Where(p => p.IDSQ == request.IDSQ);
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
            return pageResult;
        }

        public async Task<APIResult<InfoOfJobOfSiQuanViewModel>> GetInfoOfJobOfSiQuan(int IDSQ)
        {
            var infoOfJobSiQuanVM = await (from sq in _context.SiQuans
                                           join qlct in _context.QLCongTacs
                                           on sq.IDSQ equals qlct.IDSQ
                                           join qlqh in _context.QLQuanHams
                                           on sq.IDSQ equals qlqh.IDSQ
                                           join qh in _context.QuanHams
                                           on qlqh.IDQH equals qh.IDQH
                                           join hslqh in _context.HeSoLuongTheoQuanHams
                                           on qlqh.IDHeSoLuongTheoQH equals hslqh.IDHeSoLuongQH
                                           join qlcv in _context.QLChucVus
                                           on sq.IDSQ equals qlcv.IDSQ
                                           join cv in _context.ChucVus
                                           on qlcv.IDCV equals cv.IDCV
                                           join bp in _context.BoPhans
                                           on cv.IDBP equals bp.IDBP
                                           join hspccv in _context.HeSoPhuCapTheoChucVus
                                           on cv.IDCV equals hspccv.IDCV
                                           join qll in _context.QLLuongs
                                           on sq.IDSQ equals qll.IDSQ
                                           join lcb in _context.LuongCoBans
                                           on qll.IDLuongCB equals lcb.IDLuongCB
                                           where sq.IDSQ == IDSQ && qlct.CongTacState == 1
                                           select new InfoOfJobOfSiQuanViewModel()
                                           {
                                               DiaChiCT = qlct.DiaChiCT,
                                               TenQH = qh.TenQH,
                                               TenBP = bp.TenBP,
                                               TenCV = cv.TenCV,
                                               Luong = Convert.ToUInt64(hslqh.HeSoLuong * lcb.LuongCB +
                                               hspccv.HeSoPhuCap * lcb.LuongCB)
                                           }).FirstOrDefaultAsync();
            return new APISuccessedResult<InfoOfJobOfSiQuanViewModel>(infoOfJobSiQuanVM);
        }

        public async Task<APIResult<ProfileViewModel>> GetProfileByUsername(string UserName)
        {
            var profileVM = await (from user in _context.Users
                                   join sq in _context.SiQuans
                                   on user.Id equals sq.UserId
                                   where user.UserName == UserName
                                   select new ProfileViewModel() 
                                   {
                                       UserID = user.Id,
                                       IDSQ = sq.IDSQ,
                                       HoTen = sq.HoTen,
                                       NgaySinh = sq.NgaySinh,
                                       GioiTinh = sq.GioiTinh,
                                       QueQuan = sq.QueQuan,
                                       SDT = sq.SDT
                                   }).FirstOrDefaultAsync();
            var sqImage = await _context.SiQuanImages.FirstOrDefaultAsync(x => x.IDSQ == profileVM.IDSQ);
            if (sqImage != null)
                profileVM.ImagePath = sqImage.ImagePath;
            return new APISuccessedResult<ProfileViewModel>(profileVM);
        }
    }
}
