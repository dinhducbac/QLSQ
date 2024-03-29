﻿using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalog.QLKhenThuongKiLuat;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QLSQ.ViewModel.Catalogs.QLKhenThuongKiLuat;

namespace QLSQ.Application.Catalog.QLKhenThuongKiLuat
{
    public class QLKhenThuongKiLuatServices : IQLKhenThuongKiLuatServices
    {
        public readonly QL_SiQuanDBContext _context;
        public QLKhenThuongKiLuatServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }

        public async Task<APIResult<bool>> Create(QLKhenThuongKiLuatCreateRequest request)
        {
            var qlktkl = new QLSQ.Data.Entities.QLKhenThuongKiLuat()
            {
                IDSQ = request.IDSQ,
                NgayThucHien = request.NgayThucHien,
                LoaiKTKL = request.LoaiKTKL,
                HinhThuc = request.HinhThuc,
                DonViCap = request.DonViCap,
                NoiDung = request.NoiDung
            };
            _context.QLKhenThuongKiLuats.Add(qlktkl);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<bool>> Delete(int IDQLKTKL)
        {
            var qlktkl = await _context.QLKhenThuongKiLuats.FirstOrDefaultAsync(x => x.IDQLKTKL == IDQLKTKL);
             _context.QLKhenThuongKiLuats.Remove(qlktkl);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<QLKhenThuongKiLuatViewModel>> Details(int IDQLKTKL)
        {
            var getqlktklvm = await (from qlktkl in _context.QLKhenThuongKiLuats
                                join sq in _context.SiQuans
                                on qlktkl.IDSQ equals sq.IDSQ
                                where qlktkl.IDQLKTKL == IDQLKTKL
                                     select new QLKhenThuongKiLuatViewModel()
                                {
                                    IDQLKTKL = qlktkl.IDQLKTKL,
                                    IDSQ = qlktkl.IDSQ,
                                    HoTen = sq.HoTen,
                                    NgayThucHien = qlktkl.NgayThucHien,
                                    LoaiKTKL = qlktkl.LoaiKTKL,
                                    HinhThuc = qlktkl.HinhThuc,
                                    DonViCap = qlktkl.DonViCap,
                                    NoiDung = qlktkl.NoiDung
                                }).FirstOrDefaultAsync();
            var qlktklvm = new QLKhenThuongKiLuatViewModel()
            {
                IDQLKTKL = getqlktklvm.IDQLKTKL,
                IDSQ = getqlktklvm.IDSQ,
                HoTen = getqlktklvm.HoTen,
                NgayThucHien = getqlktklvm.NgayThucHien,
                LoaiKTKL = getqlktklvm.LoaiKTKL,
                HinhThuc = getqlktklvm.HinhThuc,
                DonViCap = getqlktklvm.DonViCap,
                NoiDung = getqlktklvm.NoiDung
            };
            return new APISuccessedResult<QLKhenThuongKiLuatViewModel>(qlktklvm);
        }

        public async Task<APIResult<bool>> Edit(int IDQLKTKL, QLKhenThuongKiLuatUpdateRequest request)
        {
            var qlktkl = await _context.QLKhenThuongKiLuats.FirstOrDefaultAsync(x => x.IDQLKTKL == IDQLKTKL);
            qlktkl.LoaiKTKL = request.LoaiKTKL;
            qlktkl.NgayThucHien = request.NgayThucHien;
            qlktkl.HinhThuc = request.HinhThuc;
            qlktkl.NoiDung = request.NoiDung;
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<PageResult<QLKhenThuongKiLuatViewModel>>> GetAllWithPaging(GetQLKhenThuongKiLuatPagingRequest request)
        {
            var query = from qlktkl in _context.QLKhenThuongKiLuats
                        join sq in _context.SiQuans
                        on qlktkl.IDSQ equals sq.IDSQ
                        select new QLKhenThuongKiLuatViewModel()
                        {
                            IDQLKTKL = qlktkl.IDQLKTKL,
                            IDSQ = qlktkl.IDSQ,
                            HoTen = sq.HoTen,
                            NgayThucHien = qlktkl.NgayThucHien,
                            LoaiKTKL = qlktkl.LoaiKTKL,
                            HinhThuc = qlktkl.HinhThuc,
                            DonViCap = qlktkl.DonViCap,
                            NoiDung = qlktkl.NoiDung
                        };
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x=>x.HoTen.Contains(request.keyword)||x.HinhThuc.Contains(request.keyword)||
                x.NoiDung.Contains(request.keyword));
            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new QLKhenThuongKiLuatViewModel
                {
                    IDQLKTKL = x.IDQLKTKL,
                    IDSQ = x.IDSQ,
                    HoTen = x.HoTen,
                    NgayThucHien = x.NgayThucHien,
                    LoaiKTKL = x.LoaiKTKL,
                    HinhThuc = x.HinhThuc,
                    DonViCap = x.DonViCap,
                    NoiDung = x.NoiDung
                }).ToListAsync();
            var pageResult = new PageResult<QLKhenThuongKiLuatViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<QLKhenThuongKiLuatViewModel>>(pageResult);
        }
    }
}
