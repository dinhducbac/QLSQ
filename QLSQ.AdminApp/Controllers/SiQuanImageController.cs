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
        public readonly ISiQuanApiClient _siQuanApiClient;
        public SiQuanImageController(ISiQuanImageApiClient siQuanImageApiClient, ISiQuanApiClient siQuanApiClient)
        {
            _siQuanImageApiClient = siQuanImageApiClient;
            _siQuanApiClient = siQuanApiClient;
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
        [HttpGet]
        public async Task<JsonResult> GetListSiQuanAutoComplete(string preconfix)
        {
            var result = await _siQuanApiClient.GetFullListSiQuanAutocomplete(preconfix);
            return Json(result.ResultObj);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] SiQuanImageCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _siQuanImageApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Tạo ảnh thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}