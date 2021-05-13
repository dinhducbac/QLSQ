using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.New;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QLSQ.Application.Catalog.NewImage;
using QLSQ.Application.Catalog.SiQuans;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace QLSQ.Application.Catalog.New
{
    public class NewServices : INewServices
    {
        public readonly QL_SiQuanDBContext _context;
        public readonly INewImageServices _newImageServices;
        public NewServices(QL_SiQuanDBContext context,INewImageServices newImageServices)
        {
            _context = context;
            _newImageServices = newImageServices;
        }

        public async Task<APIResult<bool>> Create(NewCreateRequest request)
        {
            var news = new QLSQ.Data.Entities.New()
            {
                NewName = request.NewName,
                NewContent = request.NewContent,
                NewDatePost = DateTime.Now,
                NewCount = request.NewCount,
                NewCatetoryID = request.NewCatetoryID
            };
            if(request.FormFile != null)
            {
                news.NewImages = new List<Data.Entities.NewImage>()
                {
                    new QLSQ.Data.Entities.NewImage()
                    {
                        NewID = news.NewID,
                        ImagePath = await _newImageServices.SaveFile(request.FormFile),
                        DateCreated = DateTime.Now,
                        FileSize = request.FormFile.Length
                    }
                };
            }
            _context.News.Add(news);
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<bool>> Delete(int NewID)
        {
            var news = await _context.News.FirstOrDefaultAsync(x => x.NewID == NewID);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            var deleteNewImage = await _newImageServices.DeleteNewImageByNewID(NewID);
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<NewDetailsViewModel>> DetailNew(int NewID)
        {
            var newDetailVM = await (from news in _context.News
                                     join newcatetory in _context.NewCatetories
                                     on news.NewCatetoryID equals newcatetory.NewCatetoryID
                                     join newimage in _context.NewImages
                                     on news.NewID equals newimage.NewID
                                     where news.NewID == NewID
                                     select new NewDetailsViewModel()
                                     {
                                         NewID = news.NewID,
                                         NewCatetoryID = news.NewCatetoryID,
                                         NewCatetoryName = newcatetory.NewCatetoryName,
                                         NewDatePost = news.NewDatePost,
                                         ImagePath = newimage.ImagePath,
                                         NewName = news.NewName,
                                         NewContent = news.NewContent
                                     }).FirstOrDefaultAsync();
            return new APISuccessedResult<NewDetailsViewModel>(newDetailVM);
        }

        public async Task<APIResult<NewDetailsViewModel>> Details(int NewID)
        {         
            var newsDetail = await (from news in _context.News
                                    join newcatetory in _context.NewCatetories
                                    on news.NewCatetoryID equals newcatetory.NewCatetoryID
                                    where news.NewID == NewID
                                    select new NewDetailsViewModel() 
                                    {
                                        NewID = news.NewID,
                                        NewName = news.NewName,
                                        NewContent = news.NewContent,
                                        NewDatePost = news.NewDatePost,
                                        NewCount = news.NewCount,
                                        NewCatetoryID = news.NewCatetoryID,
                                        NewCatetoryName = newcatetory.NewCatetoryName
                                    }).FirstOrDefaultAsync();
            var imagePath = await _newImageServices.GetImagePathByNewID(NewID);
            if (imagePath.ResultObj != null)
                newsDetail.ImagePath = imagePath.ResultObj;
            return new APISuccessedResult<NewDetailsViewModel>(newsDetail);
        }

        public async Task<APIResult<bool>> Edit(int NewID, NewUpdateRequest request)
        {
            var news = await _context.News.FirstOrDefaultAsync(x=>x.NewID == NewID);
            news.NewName = request.NewName;
            news.NewContent = request.NewContent;
            news.NewDatePost = request.NewDatePost;
            news.NewCount = request.NewCount;
            news.NewCatetoryID = request.NewCatetoryID;
            if(request.FormFile != null)
            {
                var newimage = await _context.NewImages.FirstOrDefaultAsync(x=>x.NewID == NewID);
                if(newimage != null)
                {
                    newimage.DateCreated = DateTime.Now;
                    newimage.ImagePath = await _newImageServices.SaveFile(request.FormFile);
                    newimage.FileSize = request.FormFile.Length;
                }
                else
                {
                    var newNewImage = new QLSQ.Data.Entities.NewImage()
                    {
                        NewID = NewID,
                        ImagePath = await _newImageServices.SaveFile(request.FormFile),
                        DateCreated = DateTime.Now,
                        FileSize = request.FormFile.Length
                    };
                    _context.NewImages.Add(newNewImage);
                    await _context.SaveChangesAsync();
                }
            }
            await _context.SaveChangesAsync();
            return new APISuccessedResult<bool>(true);
        }

        public async Task<APIResult<PageResult<NewViewModel>>> GetAllWithPaging(GetNewPagingRequest request)
        {
            var query = from news in _context.News
                        join newcatetory in _context.NewCatetories
                        on news.NewCatetoryID equals newcatetory.NewCatetoryID
                        select new NewViewModel()
                        {
                            NewID = news.NewID,
                            NewName = news.NewName,
                            NewContent = news.NewContent,
                            NewDatePost = news.NewDatePost,
                            NewCount = news.NewCount,
                            NewCatetoryName = newcatetory.NewCatetoryName
                        };
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.NewName.Contains(request.keyword));
            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new NewViewModel()
                {
                    NewID = x.NewID,
                    NewName = x.NewName,
                    NewContent = x.NewContent,
                    NewDatePost = x.NewDatePost,
                    NewCount = x.NewCount,
                    NewCatetoryName = x.NewCatetoryName
                }).ToListAsync();
            var pageResult = new PageResult<NewViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new APISuccessedResult<PageResult<NewViewModel>>(pageResult);
        }

        public async Task<APIResult<List<NewDetailsViewModel>>> GetKHCNNewInIndex()
        {
            var listKHCNNewInIndex = await (from news in _context.News
                                            join newimage in _context.NewImages
                                            on news.NewID equals newimage.NewID
                                            join newcatetory in _context.NewCatetories
                                            on news.NewCatetoryID equals newcatetory.NewCatetoryID
                                            where news.NewCatetoryID == 3
                                            orderby news.NewDatePost descending
                                            select new NewDetailsViewModel()
                                            {
                                                NewID = news.NewID,
                                                NewName = news.NewName,
                                                NewContent = news.NewContent,
                                                NewCatetoryName = newcatetory.NewCatetoryName,
                                                ImagePath = newimage.ImagePath
                                            }).Take(5).ToListAsync();
            return new APISuccessedResult<List<NewDetailsViewModel>>(listKHCNNewInIndex);
        }

        public async Task<APIResult<List<NewDetailsViewModel>>> GetLastestNew()
        {
            var listLastestNew = await (from news in _context.News
                                        join newimage in _context.NewImages
                                        on news.NewID equals newimage.NewID
                                        join newcatetory in _context.NewCatetories
                                        on news.NewCatetoryID equals newcatetory.NewCatetoryID
                                        orderby news.NewDatePost descending
                                        select new NewDetailsViewModel()
                                        {
                                            NewID = news.NewID,
                                            NewName = news.NewName,
                                            ImagePath = newimage.ImagePath,
                                            NewCatetoryName = newcatetory.NewCatetoryName
                                        }).Take(6).ToListAsync();
            return new APISuccessedResult<List<NewDetailsViewModel>>(listLastestNew);
        }

        public async Task<APIResult<List<NewDetailsViewModel>>> GetListKHCNNew()
        {
            var listKHCNNew = await (from news in _context.News
                                     join newcatetory in _context.NewCatetories
                                     on news.NewCatetoryID equals newcatetory.NewCatetoryID
                                     join newimage in _context.NewImages
                                     on news.NewID equals newimage.NewID
                                     orderby news.NewDatePost descending
                                     where news.NewCatetoryID == 3
                                     select new NewDetailsViewModel()
                                     {
                                         NewID = news.NewID,
                                         NewCatetoryName = newcatetory.NewCatetoryName,
                                         NewName = news.NewName,
                                         NewContent = news.NewContent,
                                         ImagePath = newimage.ImagePath
                                     }).ToListAsync();
            return new APISuccessedResult<List<NewDetailsViewModel>>(listKHCNNew);
        }

        public async Task<APIResult<List<NewViewModel>>> GetListNewAutoComplete(string prefix)
        {
            var query = await (from news in _context.News
                              where news.NewName.Contains(prefix)
                              select new NewViewModel() 
                              {
                                NewID = news.NewID,
                                NewName = news.NewName
                              }).ToListAsync();
           
            return new APISuccessedResult<List<NewViewModel>>(query);
        }

        public async Task<APIResult<List<NewDetailsViewModel>>> GetMostViewNew()
        {
            var mostViewNew = await (from news in _context.News
                               join newcatetory in _context.NewCatetories
                               on news.NewCatetoryID equals newcatetory.NewCatetoryID
                               join newimage in _context.NewImages
                               on news.NewID equals newimage.NewID
                               orderby news.NewCount descending
                               select new NewDetailsViewModel()
                               {
                                   NewID = news.NewID,
                                   NewName = news.NewName,
                                   NewContent = news.NewContent,
                                   NewCatetoryName = newcatetory.NewCatetoryName,
                                   ImagePath = newimage.ImagePath
                               }).Take(4).ToListAsync();
            return new APISuccessedResult<List<NewDetailsViewModel>>(mostViewNew);
        }

        public async Task<APIResult<List<NewDetailsViewModel>>> GetRelatedNew(int NewCatetoryID)
        {
            var listRelatedNew = await (from news in _context.News
                                        join newimage in _context.NewImages
                                        on news.NewID equals newimage.NewID
                                        join newcatetory in _context.NewCatetories
                                        on news.NewCatetoryID equals newcatetory.NewCatetoryID
                                        where news.NewCatetoryID == NewCatetoryID
                                        orderby news.NewDatePost descending
                                        select new NewDetailsViewModel()
                                        {
                                            NewID = news.NewID,
                                            NewCatetoryID = news.NewCatetoryID,
                                            NewCatetoryName = newcatetory.NewCatetoryName,
                                            ImagePath = newimage.ImagePath,
                                            NewName = news.NewName,
                                            NewContent = news.NewContent,
                                            NewCount = news.NewCount,
                                            NewDatePost = news.NewDatePost
                                        }).Take(3).ToListAsync();
            return new APISuccessedResult<List<NewDetailsViewModel>>(listRelatedNew);
        }

        public async Task<APIResult<List<NewDetailsViewModel>>> GetTuyenSinhNewInIndex()
        {
            var listTuyenSinhNew = await (from news in _context.News
                                          where news.NewCatetoryID == 4
                                          orderby news.NewDatePost descending
                                          select new NewDetailsViewModel() 
                                          {
                                            NewID = news.NewID,
                                            NewName = news.NewName,
                                            NewDatePost = news.NewDatePost
                                          }).Take(4).ToListAsync();
            return new APISuccessedResult<List<NewDetailsViewModel>>(listTuyenSinhNew);

        }
    }
}
