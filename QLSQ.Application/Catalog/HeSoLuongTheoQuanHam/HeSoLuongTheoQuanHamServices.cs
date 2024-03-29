﻿using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.HeSoLuongTheoQuanHam;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QLSQ.ViewModel.Catalogs.QuanHam;

namespace QLSQ.Application.Catalog.HeSoLuongTheoQuanHam
{
    public class HeSoLuongTheoQuanHamServices : IHeSoLuongTheoQuanHamServices
    {
        public readonly QL_SiQuanDBContext _context;
        public HeSoLuongTheoQuanHamServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }

        public async Task<APIResult<bool>> CheckNameHeSoLuongInCreate(string name)
        {
            var hslqh = await _context.HeSoLuongTheoQuanHams.ToListAsync();
            foreach (var data in hslqh)
            {
                if(data.TenHeSoLuongQH.ToString().ToLower() == name.ToLower())
                {
                    return new APISuccessedResult<bool>(true);
                }
            }
            return new APIResult<bool>();
        }

        public async Task<APIResult<bool>> Create(HeSoLuongTheoQuanHamCreateRequest request)
        {
            var hsl = new QLSQ.Data.Entities.HeSoLuongTheoQuanHam()
            {
                IDQH = request.IDQH,
                HeSoLuong = request.HeSoLuong,
                TenHeSoLuongQH = request.TenHeSoLuongQH
            };
            _context.HeSoLuongTheoQuanHams.Add(hsl);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<bool>> Delete(int IDHeSoLuongQH)
        {
            var hslqh = await _context.HeSoLuongTheoQuanHams.FirstOrDefaultAsync(x=>x.IDHeSoLuongQH == IDHeSoLuongQH);
            _context.HeSoLuongTheoQuanHams.Remove(hslqh);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<HeSoLuongTheoQuanHamViewModel>> Details(int IDHeSoLuongQH)
        {
            var query = await (from qh in _context.QuanHams
             join hsltqh in _context.HeSoLuongTheoQuanHams
             on qh.IDQH equals hsltqh.IDQH
             where hsltqh.IDHeSoLuongQH == IDHeSoLuongQH
             select new HeSoLuongTheoQuanHamViewModel()
             {
                 IDHeSoLuongQH = hsltqh.IDHeSoLuongQH,
                 IDQH = hsltqh.IDQH,
                 TenQH = qh.TenQH,
                 TenHeSoLuongQH = hsltqh.TenHeSoLuongQH,
                 HeSoLuong = hsltqh.HeSoLuong
             }).FirstOrDefaultAsync();
            return new APISuccessedResult<HeSoLuongTheoQuanHamViewModel>(query); 
        }

        public async Task<APIResult<bool>> Edit(int IDHeSoLuongQH, HeSoLuongTheoQuanHamUpdateRequest request)
        {
            var hsl = await _context.HeSoLuongTheoQuanHams.FirstOrDefaultAsync(x=>x.IDHeSoLuongQH == IDHeSoLuongQH);
            hsl.TenHeSoLuongQH = request.TenHeSoLuongQH;
            hsl.HeSoLuong = request.HeSoLuong;
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
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
                             TenHeSoLuongQH = hsltqh.TenHeSoLuongQH,
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
                    TenHeSoLuongQH = x.TenHeSoLuongQH,
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

        public async Task<APIResult<HeSoLuongTheoQuanHamViewModel>> GetHeSoLuongTheoQHByIDHeSoLuongQH(int IDHeSoLuongQH)
        {
            var hslqhvm = await (from hslqh in _context.HeSoLuongTheoQuanHams
                                 where hslqh.IDHeSoLuongQH == IDHeSoLuongQH
                                 select new HeSoLuongTheoQuanHamViewModel()
                                 {
                                     IDHeSoLuongQH = hslqh.IDHeSoLuongQH,
                                     HeSoLuong = hslqh.HeSoLuong
                                 }).FirstOrDefaultAsync();
            return new APISuccessedResult<HeSoLuongTheoQuanHamViewModel>(hslqhvm);
        }

        public async Task<APIResult<List<HeSoLuongTheoQuanHamViewModel>>> GetHeSoLuongTheoQHByIDQH(int IDQH)
        {
            var query = await (from hslqh in _context.HeSoLuongTheoQuanHams
                              where hslqh.IDQH == IDQH
                              select new HeSoLuongTheoQuanHamViewModel()
                              {
                                  IDHeSoLuongQH = hslqh.IDHeSoLuongQH,
                                  TenHeSoLuongQH = hslqh.TenHeSoLuongQH,
                                  HeSoLuong = hslqh.HeSoLuong
                              }).ToListAsync();
            return new APISuccessedResult<List<HeSoLuongTheoQuanHamViewModel>>(query);
        }
    }
}
