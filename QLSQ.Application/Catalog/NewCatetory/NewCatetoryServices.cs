using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.NewCatetory;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLSQ.Application.Catalog.NewCatetory
{
    public class NewCatetoryServices : INewCatetoryServices
    {
        public readonly QL_SiQuanDBContext _context;
        public NewCatetoryServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }

        public async Task<APIResult<bool>> Create(NewCatetoryCreateRequest request)
        {
            var newcatetory = new QLSQ.Data.Entities.NewCatetory();
            newcatetory.NewCatetoryName = request.NewCatetoryName;
            _context.NewCatetories.Add(newcatetory);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<bool>> Delete(int NewCatetoryID)
        {
            var newcatetory = await _context.NewCatetories.FirstOrDefaultAsync(x => x.NewCatetoryID == NewCatetoryID);
            _context.NewCatetories.Remove(newcatetory);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<NewCatetoryViewModel>> Details(int NewCatetoryID)
        {
            var newcatetoryDetails = await (from newcatetory in _context.NewCatetories
                                            where newcatetory.NewCatetoryID == NewCatetoryID
                                            select new NewCatetoryViewModel()
                                            {
                                                NewCatetoryID = newcatetory.NewCatetoryID,
                                                NewCatetoryName = newcatetory.NewCatetoryName
                                            }).FirstOrDefaultAsync();
            if (newcatetoryDetails != null)
                return new APISuccessedResult<NewCatetoryViewModel>(newcatetoryDetails);
            return new APIErrorResult<NewCatetoryViewModel>("Thất bại");
        }

        public async Task<APIResult<bool>> Edit(int NewCatetoryID, NewCatetoryUpdateRequest request)
        {
            var newcatetory = await _context.NewCatetories.FirstOrDefaultAsync(x => x.NewCatetoryID == NewCatetoryID);
            newcatetory.NewCatetoryName = request.NewCatetoryName;
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<PageResult<NewCatetoryViewModel>>> GetAllWithPaging(GetNewCatetoryPagingRequest request)
        {
            var query = from newcatetory in _context.NewCatetories
                        select newcatetory;
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.NewCatetoryName.Contains(request.keyword));
            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new NewCatetoryViewModel()
                {
                    NewCatetoryID = x.NewCatetoryID,
                    NewCatetoryName = x.NewCatetoryName
                }).ToListAsync();
            var pageResult = new PageResult<NewCatetoryViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<NewCatetoryViewModel>>(pageResult);

        }
    }
}
