
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
    }
}
