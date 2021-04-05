﻿using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.HeSoLuongTheoQuanHam;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLSQ.Application.Catalog.HeSoLuongTheoQuanHam
{
    public class HeSoLuongTheoQuanHamServices : IHeSoLuongTheoQuanHamServices
    {
        public readonly QL_SiQuanDBContext _context;
        public HeSoLuongTheoQuanHamServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }
        public async Task<APIResult<PageResult<HeSoLuongTheoQuanHamViewModel>>> GetAllWithPaging(GetPagingRequestHeSoLuongTheoQuanHam request)
        {
            var query = (from qh in _context.QuanHams
                         join hsltqh in _context.HeSoLuongTheoQuanHams
                         on qh.IDQH equals hsltqh.IDQH
                         select new HeSoLuongTheoQuanHamViewModel()
                         {
                             IDHeSoLuongQH = hsltqh.IDHeSoLuongQH,
                             IDQH = hsltqh.IDQH,
                             TenQH = qh.TenQH,
                             HeSoLuong = hsltqh.HeSoLuong
                         });
            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.IDQH.ToString().Contains(request.keyword) || x.TenQH.Contains(request.keyword));
            }
            var totalrow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new HeSoLuongTheoQuanHamViewModel()
                {
                    IDHeSoLuongQH = x.IDHeSoLuongQH,
                    IDQH = x.IDQH,
                    TenQH = x.TenQH,
                    HeSoLuong = x.HeSoLuong
                }).ToListAsync();
            var pageresult = new PageResult<HeSoLuongTheoQuanHamViewModel>()
            {
                TotalRecord = totalrow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<HeSoLuongTheoQuanHamViewModel>>(pageresult); 
        }
    }
}
