using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.LuongCoBan;

namespace QLSQ.AdminApp.Controllers.Component
{
    public class LuongCoBanController : Controller
    {
        public readonly ILuongCoBanApiClient _luongCoBanApiClient;
        public LuongCoBanController(ILuongCoBanApiClient luongCoBanApiClient)
        {
            _luongCoBanApiClient = luongCoBanApiClient;
        }
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 5)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var lcbPagingRequest = new GetLuongCoBanPagingRequest()
            {
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _luongCoBanApiClient.GetAllWithPaging(lcbPagingRequest);
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