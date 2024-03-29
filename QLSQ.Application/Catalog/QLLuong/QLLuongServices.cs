﻿using QLSQ.Data.EF;
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
                IDQLQH = request.IDQLQH,
                IDQLCV = request.IDQLCV,
                IDLuongCB = request.IDLuongCB,
            };
            _context.QLLuongs.Add(qll);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<bool>> Delete(int IDLuong)
        {
            var qll = await _context.QLLuongs.FirstOrDefaultAsync(x => x.IDLuong == IDLuong);
            _context.QLLuongs.Remove(qll);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<QLLuongDetailsViewModel>> Details(int IDLuong)
        {
            var query = await (from sq in _context.SiQuans
                               join qlluong in _context.QLLuongs
                                  on sq.IDSQ equals qlluong.IDSQ
                               join lcb in _context.LuongCoBans
                                  on qlluong.IDLuongCB equals lcb.IDLuongCB
                               join qlqh in _context.QLQuanHams
                                   on qlluong.IDQLQH equals qlqh.IDQLQH
                               join hsl in _context.HeSoLuongTheoQuanHams
                                   on qlqh.IDHeSoLuongTheoQH equals hsl.IDHeSoLuongQH
                               join qh in _context.QuanHams
                                   on qlqh.IDQH equals qh.IDQH
                               join qlcv in _context.QLChucVus
                                   on qlluong.IDQLCV equals qlcv.IDQLCV
                               join cv in _context.ChucVus
                                   on qlcv.IDCV equals cv.IDCV
                               join hspc in _context.HeSoPhuCapTheoChucVus
                                   on cv.IDCV equals hspc.IDCV
                                   where qlluong.IDLuong == IDLuong 
                               select new QLLuongDetailsViewModel()
                        {
                            IDLuong = qlluong.IDLuong,
                            HoTen = sq.HoTen,
                            IDSQ = qlluong.IDSQ,
                            IDQH = qlqh.IDQH,
                            TenQH = qh.TenQH,
                            IDHeSoLuongQH = qlqh.IDHeSoLuongTheoQH,
                            HeSoLuongQH = hsl.HeSoLuong,
                            IDCV = qlcv.IDCV,
                            TenCV = cv.TenCV,
                            IDHeSoPhuCapCV = hspc.IDHeSoPhuCapCV,
                            HeSoPhuCapCV = hspc.HeSoPhuCap,
                            IDLuongCB = qlluong.IDLuongCB,
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
                         join lcb in _context.LuongCoBans
                            on qlluong.IDLuongCB equals lcb.IDLuongCB
                         join qlqh in _context.QLQuanHams
                             on qlluong.IDQLQH equals qlqh.IDQLQH
                         join hsl in _context.HeSoLuongTheoQuanHams
                             on qlqh.IDHeSoLuongTheoQH equals hsl.IDHeSoLuongQH
                         join qlcv in _context.QLChucVus
                             on qlluong.IDQLCV equals qlcv.IDQLCV
                         join cv in _context.ChucVus
                             on qlcv.IDCV equals cv.IDCV
                         join hspc in _context.HeSoPhuCapTheoChucVus
                             on cv.IDCV equals hspc.IDCV
                         select new QLLuongViewModel
                         {
                             IDLuong = qlluong.IDLuong,
                             IDSQ = qlluong.IDSQ,
                             HoTen = sq.HoTen,
                             HeSoLuong = hsl.HeSoLuong,
                             HeSoPhuCap = hspc.HeSoPhuCap,
                             LuongCB = lcb.LuongCB,
                             Luong = Convert.ToUInt64(hsl.HeSoLuong * lcb.LuongCB + hspc.HeSoPhuCap * lcb.LuongCB)
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
