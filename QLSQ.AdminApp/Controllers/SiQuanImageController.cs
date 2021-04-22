using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.SiQuanImage;

namespace QLSQ.AdminApp.Controllers
{
    public class SiQuanImageController : Controller
    {
        public readonly ISiQuanImageApiClient _siQuanImageApiClient;
        public SiQuanImageController(ISiQuanImageApiClient siQuanImageApiClient)
        {
            _siQuanImageApiClient = siQuanImageApiClient;
        }
        public async  Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var sqImagePagingRequest = new GetSiQuanImagePagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _siQuanImageApiClient.GetAllWithPaging(sqImagePagingRequest);
            if (result.ResultObj != null)
            {
                if(TempData["result"] != null)
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