using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.QLNghiPHep;

namespace QLSQ.AdminApp.Controllers
{
    public class QLNghiPhepController : Controller
    {
        public readonly IQLNghiPhepApiClient _qLNghiPhepApiClient;
        public QLNghiPhepController(IQLNghiPhepApiClient qLNghiPhepApiClient) 
        {
            _qLNghiPhepApiClient = qLNghiPhepApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var pagingRequest = new GetQLNghiPhepPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _qLNghiPhepApiClient.GetAllWithPaging(pagingRequest);
            if (result.IsSuccessed)
            {
                if(ViewData["result"] != null)
                {
                    ViewBag.Success = true;
                    ViewBag.SuccessMessage = ViewData["result"];
                }
                return View(result.ResultObj);
            }
            return View(result);
        }
    }
}