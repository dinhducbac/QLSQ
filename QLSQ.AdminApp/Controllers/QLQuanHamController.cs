using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.QLQuanHam;

namespace QLSQ.AdminApp.Controllers
{
    public class QLQuanHamController : Controller
    {
        public readonly IQLQuanHamApiClient _qLQuanHamApiClient;
        public QLQuanHamController(IQLQuanHamApiClient qLQuanHamApiClient)
        {
            _qLQuanHamApiClient = qLQuanHamApiClient;
        }
        public async Task<IActionResult> Index(string keyword,int pageIndex = 1, int pageSize = 5)
        {
            var pageResult = new GetQLQuanHamPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _qLQuanHamApiClient.GetAllWithPaging(pageResult);
            if(result.ResultObj != null)
            {
                if(TempData["result"]!= null)
                {
                    ViewBag.Success = true;
                    ViewBag.SuccessMessage = TempData["result"];
                }
                return View(result.ResultObj);
            }
            return View(result);
        }
    }
}