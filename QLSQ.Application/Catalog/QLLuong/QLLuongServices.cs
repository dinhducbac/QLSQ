using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.QLLuong;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace QLSQ.Application.Catalog.QLLuong
{
    public class QLLuongServices : IQLLuongServices
    {
        private readonly QL_SiQuanDBContext _context;

        public QLLuongServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }

        public async Task<APIResult<bool>> Create(QLLuongCreateRequest request)
        {
            var qll = new QLSQ.Data.Entities.QLLuong()
            {
                IDSQ = request.IDSQ,
                IDHeSoLuongQH = request.IDHeSoLuongQH,
                IDLuongCB = request.IDLuongCB,
                IDHeSoPhuCapCV = request.IDHeSoPhuCapCV
            };
            _context.QLLuongs.Add(qll);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<QLLuongDetailsViewModel>> Details(int IDLuong)
        {
            var query = await (from qll in _context.QLLuongs
                        join sq in _context.SiQuans
                        on qll.IDSQ equals sq.IDSQ
                        join hsl in _context.HeSoLuongTheoQuanHams
                        on qll.IDHeSoLuongQH equals hsl.IDHeSoLuongQH
                        join qh in _context.QuanHams
                        on hsl.IDQH equals qh.IDQH
                        join hspc in _context.HeSoPhuCapTheoChucVus
                        on qll.IDHeSoPhuCapCV equals hspc.IDHeSoPhuCapCV
                        join cv in _context.ChucVus
                        on hspc.IDCV equals cv.IDCV
                        join lcb in _context.LuongCoBans
                        on qll.IDLuongCB equals lcb.IDLuongCB
                        where qll.IDLuong == IDLuong
                        select new QLLuongDetailsViewModel()
                        {
                            IDLuong = qll.IDLuong,
                            HoTen = sq.HoTen,
                            IDSQ = qll.IDSQ,
                            IDQH = qh.IDQH,
                            TenQH = qh.TenQH,
                            IDHeSoLuongQH = qll.IDHeSoLuongQH,
                            HeSoLuongQH = hsl.HeSoLuong,
                            IDCV = cv.IDCV,
                            TenCV = cv.TenCV,
                            IDHeSoPhuCapCV = qll.IDHeSoPhuCapCV,
                            HeSoPhuCapCV = hspc.HeSoPhuCap,
                            IDLuongCB = qll.IDLuongCB,
                            LuongCB = lcb.LuongCB
                        }).FirstOrDefaultAsync();
            var qllDetailsViewModel = new QLLuongDetailsViewModel()
            {
                IDLuong = query.IDLuong,
                HoTen = query.HoTen,
                IDSQ = query.IDSQ,
                IDQH = query.IDQH,
                TenQH = query.TenQH,
                IDHeSoLuongQH = query.IDHeSoLuongQH,
                HeSoLuongQH = query.HeSoLuongQH,
                IDCV = query.IDCV,
                TenCV = query.TenCV,
                IDHeSoPhuCapCV = query.IDHeSoPhuCapCV,
                HeSoPhuCapCV = query.HeSoPhuCapCV,
                IDLuongCB = query.IDLuongCB,
                LuongCB = query.LuongCB,
                Luong = Convert.ToUInt64(query.HeSoLuongQH * query.LuongCB + query.HeSoPhuCapCV * query.LuongCB)
            };
            return new APISuccessedResult<QLLuongDetailsViewModel>(qllDetailsViewModel);
            
        }

    public async Task<APIResult<PageResult<QLLuongViewModel>>> GetAllWithPaging(GetQLLuongPagingRequest request)
        {
            var query = (from sq in _context.SiQuans
                         join qlluong in _context.QLLuongs
                            on sq.IDSQ equals qlluong.IDSQ
                         join hslqh in _context.HeSoLuongTheoQuanHams
                            on qlluong.IDHeSoLuongQH equals hslqh.IDHeSoLuongQH
                         join hspccv in _context.HeSoPhuCapTheoChucVus
                            on qlluong.IDHeSoPhuCapCV equals hspccv.IDHeSoPhuCapCV
                         join lcb in _context.LuongCoBans
                            on qlluong.IDLuongCB equals lcb.IDLuongCB
                         select new QLLuongViewModel
                         {
                             IDLuong = qlluong.IDLuong,
                             IDSQ = qlluong.IDSQ,
                             HoTen = sq.HoTen,
                             HeSoLuong = hslqh.HeSoLuong,
                             HeSoPhuCap = hspccv.HeSoPhuCap,
                             LuongCB = lcb.LuongCB,
                             Luong = Convert.ToUInt64(hslqh.HeSoLuong * lcb.LuongCB + hspccv.HeSoPhuCap * lcb.LuongCB)
                         });
            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(p => p.HoTen.Contains(request.keyword) || p.IDSQ.Equals(request.keyword));
            }
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
               .Take(request.pageSize)
               .Select(x=> new QLLuongViewModel() 
               { 
                    IDLuong = x.IDLuong,
                    IDSQ = x.IDSQ,
                    HoTen = x.HoTen,
                    HeSoLuong = x.HeSoLuong,
                    HeSoPhuCap = x.HeSoPhuCap,
                    LuongCB = x.LuongCB,
                    Luong = x.Luong
               }).ToListAsync();
            var pageResult = new PageResult<QLLuongViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<QLLuongViewModel>>(pageResult);
        }
    }
}
