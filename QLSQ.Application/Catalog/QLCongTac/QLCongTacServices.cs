using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.QLCongTac;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLSQ.Application.Catalog.QLCongTac
{
    public class QLCongTacServices : IQLCongTacServices
    {
        private readonly QL_SiQuanDBContext _context;
        public QLCongTacServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }

        public async Task<APIResult<bool>> Create(QLCongTacCreateRequest request)
        {
            var qlct = new QLSQ.Data.Entities.QLCongTac()
            {
                IDSQ = request.IDSQ,
                DiaChiCT = request.DiaChiCT,
                ThoiGianBatDauCT = request.ThoiGianBatDauCT,
                ThoiGianKetThucCT = request.ThoiGianKetThucCT
            };
            _context.QLCongTacs.Add(qlct);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<bool>> Delete(int IDCT)
        {
            var qlct = await _context.QLCongTacs.FirstOrDefaultAsync(x => x.IDCT == IDCT);
            _context.QLCongTacs.Remove(qlct);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true); 

        }

        public async Task<APIResult<QLCongTacViewModel>> Details(int IDCT)
        {
            var qlctdetail = (from sq in _context.SiQuans
                       join qlct in _context.QLCongTacs
                       on sq.IDSQ equals qlct.IDSQ
                       where qlct.IDCT == IDCT
                       select new QLCongTacViewModel()
                       {
                           IDCT = qlct.IDCT,
                           IDSQ = qlct.IDSQ,
                           HoTen = sq.HoTen,
                           DiaChiCT = qlct.DiaChiCT,
                           ThoiGianBatDauCT = qlct.ThoiGianBatDauCT,
                           ThoiGianKetThucCT = qlct.ThoiGianKetThucCT
                       }).FirstOrDefault();
            var qlctvm = new QLCongTacViewModel()
            {
                IDCT = qlctdetail.IDCT,
                IDSQ = qlctdetail.IDSQ,
                HoTen = qlctdetail.HoTen,
                DiaChiCT = qlctdetail.DiaChiCT,
                ThoiGianBatDauCT = qlctdetail.ThoiGianBatDauCT,
                ThoiGianKetThucCT = qlctdetail.ThoiGianKetThucCT
            };
            return new APISuccessedResult<QLCongTacViewModel>(qlctvm);
        }

        public async Task<APIResult<bool>> Edit(int IDCT, QLCongTacUpdateRequest request)
        {
            var qlct = await _context.QLCongTacs.FirstOrDefaultAsync(x=>x.IDCT == IDCT);
            qlct.DiaChiCT = request.DiaChiCT;
            qlct.ThoiGianBatDauCT = request.ThoiGianBatDauCT;
            qlct.ThoiGianKetThucCT = request.ThoiGianKetThucCT;
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<PageResult<QLCongTacViewModel>>> GetAll(GetQLCongTacPagingRequest request)
        {
            var query = (from sq in _context.SiQuans
                         join qlct in _context.QLCongTacs
                         on sq.IDSQ equals qlct.IDSQ
                         select new QLCongTacViewModel()
                         {
                             IDCT = qlct.IDCT,
                             IDSQ = qlct.IDSQ,
                             HoTen = sq.HoTen,
                             DiaChiCT = qlct.DiaChiCT,
                             ThoiGianBatDauCT = qlct.ThoiGianBatDauCT,
                             ThoiGianKetThucCT = qlct.ThoiGianKetThucCT
                         });
            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.IDSQ.ToString().Contains(request.keyword)|| x.HoTen.Contains(request.keyword));
            }
            int totalrow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new QLCongTacViewModel()
                {
                    IDCT = x.IDCT,
                    IDSQ = x.IDSQ,
                    HoTen = x.HoTen,
                    DiaChiCT = x.DiaChiCT,
                    ThoiGianBatDauCT = x.ThoiGianBatDauCT,
                    ThoiGianKetThucCT = x.ThoiGianKetThucCT
                }).ToListAsync();
            var pageresult = new PageResult<QLCongTacViewModel>()
            {
                TotalRecord = totalrow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<QLCongTacViewModel>>(pageresult); 
        }
    }
}
