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
        [HttpGet]
        public async Task<IActionResult> Details(int IDImage)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _siQuanImageApiClient.Details(IDImage);
            if (result.ResultObj != null)
                return View(result.ResultObj);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int IDImage)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var sqImageViewModel = await _siQuanImageApiClient.Details(IDImage);
            var sqImageUpdateRequest = new SiQuanImageUpdateRequest()
            {
                IDImage = sqImageViewModel.ResultObj.IDImage,
                IDSQ = sqImageViewModel.ResultObj.IDSQ,
                HoTenSQ = sqImageViewModel.ResultObj.HoTenSQ,
                Caption = sqImageViewModel.ResultObj.Caption,
                ImagePath = sqImageViewModel.ResultObj.ImagePath,
                IsDefault = sqImageViewModel.ResultObj.IsDefault,
                DateCreated = sqImageViewModel.ResultObj.DateCreated,
                FileSize = sqImageViewModel.ResultObj.FileSize
            };
            return View(sqImageUpdateRequest);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit(SiQuanImageUpdateRequest request)
        {
            var result = await _siQuanImageApiClient.Edit(request.IDImage, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Sửa anht thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}