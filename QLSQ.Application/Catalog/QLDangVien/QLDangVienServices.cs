using QLSQ.Application.Common;
using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.QLDangVien;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QLSQ.Data.Entities;
using QLSQ.Data.Entities;

namespace QLSQ.Application.Catalog.QLDangVien
{
    public class QLDangVienServices : IQLDangVienServices
    {

        private readonly IStorageServices _storageServices;
        private readonly QL_SiQuanDBContext _context;

        public QLDangVienServices(QL_SiQuanDBContext context, IStorageServices storageServices)
        {
            _context = context;
            _storageServices = storageServices;
        }

        public async Task<APIResult<bool>> Create(QLDangVienCreateRequest request)
        {
            var qldv = new QLSQ.Data.Entities.QLDangVien()
            {
                IDSQ = request.IDSQ,
                NgayVaoDang = request.NgayVaoDang,
                NoiVaoDang = request.NoiVaoDang
            };
            _context.QLDangViens.Add(qldv);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<bool>> Delete(int IDQLDV)
        {
            var qldv = await _context.QLDangViens.FirstOrDefaultAsync(x=>x.IDQLDV == IDQLDV);
            _context.QLDangViens.Remove(qldv);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>();
        }

        public async Task<APIResult<bool>> Edit(int IDQLDV,QLDangVienUpdateRequest request)
        {
            var qldv = await _context.QLDangViens.FirstOrDefaultAsync(x=>x.IDQLDV == IDQLDV);
            qldv.NgayVaoDang = request.NgayVaoDang;
            qldv.NoiVaoDang = request.NoiVaoDang;
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async  Task<APIResult<PageResult<QLDangVienViewModel>>> GetAllQLDangVien(GetQLDangVienPagingRequest request)
        {
            var query = (from sq in _context.SiQuans
                        join qldv in _context.QLDangViens
                        on sq.IDSQ equals qldv.IDSQ
                        select new QLDangVienViewModel()
                        { 
                            IDQLDV = qldv.IDQLDV,
                            IDSQ = qldv.IDSQ,
                            HoTen = sq.HoTen,
                            NgayVaoDang = qldv.NgayVaoDang,
                            NoiVaoDang = qldv.NoiVaoDang
                        });
            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(p => p.HoTen.Contains(request.keyword) || p.IDSQ.Equals(request.keyword));
            }
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
               .Take(request.pageSize)
               .Select(x => new QLDangVienViewModel()
               {
                   IDQLDV = x.IDQLDV,
                   IDSQ = x.IDSQ,
                   HoTen = x.HoTen,
                   NgayVaoDang = x.NgayVaoDang,
                   NoiVaoDang = x.NoiVaoDang
               }).ToListAsync();
            var pageResult = new PageResult<QLDangVienViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<QLDangVienViewModel>>(pageResult);
        }

        public async Task<APIResult<QLDangVienViewModel>> GetByID(int IDQLDV)
        {
            var query = (from sq in _context.SiQuans
                         join qldv in _context.QLDangViens
                         on sq.IDSQ equals qldv.IDSQ
                         where qldv.IDQLDV == IDQLDV
                         select new QLDangVienViewModel()
                         {
                             IDQLDV = qldv.IDQLDV,
                             IDSQ = qldv.IDSQ,
                             HoTen = sq.HoTen,
                             NgayVaoDang = qldv.NgayVaoDang,
                             NoiVaoDang = qldv.NoiVaoDang
                         }).FirstOrDefaultAsync();
            var qldvViewModel = new QLDangVienViewModel() 
            {
                IDQLDV = query.Result.IDQLDV,
                IDSQ = query.Result.IDSQ,
                HoTen = query.Result.HoTen,
                NgayVaoDang = query.Result.NgayVaoDang,
                NoiVaoDang = query.Result.NoiVaoDang
            };
            return new APISuccessedResult<QLDangVienViewModel>(qldvViewModel);
        }
    }
}
