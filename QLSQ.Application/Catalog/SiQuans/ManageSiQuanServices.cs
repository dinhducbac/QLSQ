using Microsoft.EntityFrameworkCore;
using QLSQ.Application.Catalog.SiQuans.Dtos;
using QLSQ.Application.Catalog.SiQuans.Dtos.Manage;
using QLSQ.Application.Dtos;
using QLSQ.Data.EF;
using QLSQ.Data.Entities;
using QLSQ.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.SiQuans
{
    public class ManageSiQuanServices : IManageSiQuanServices
    {

        private readonly QL_SiQuanDBContext _context;
        public ManageSiQuanServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }
        public async Task<int> Create(SiQuanCreateRequest request)
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
            _context.SiQuans.Add(siquan);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Detele(int SiQuanID)
        {
            var siquan = await _context.SiQuans.FindAsync(SiQuanID);
            if (siquan == null)
            {
                throw new QLSQException($"Không thể tìm thấy sĩ quan có Id: {SiQuanID}");
            }
            _context.SiQuans.Remove(siquan);
            return await _context.SaveChangesAsync();
        }



        public async Task<PageResult<SiQuanViewModel>> GetAllPaging(GetSiQuanPagingRequest request)
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
                Items = data
            };
            return pageResult;
        }

        public async Task<int> Update(SiQuanUpdateRequest request)
        {
            var siquan = await _context.SiQuans.FirstOrDefaultAsync(x => x.IDSQ == request.IDSQ);
            if (siquan == null)
                throw new QLSQException($"Không thể tìm thấy sĩ quan có ID: {request.IDSQ}");
            siquan.UserId = request.UserId;
            siquan.HoTen = request.HoTen;
            siquan.NgaySinh = request.NgaySinh;
            siquan.GioiTinh = request.GioiTinh;
            siquan.QueQuan = request.QueQuan;
            siquan.SDT = request.SDT;
            return await _context.SaveChangesAsync();
        }
    }
}
