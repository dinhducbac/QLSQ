using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.BoPhan;

namespace QLSQ.AdminApp.Controllers
{
    public class BoPhanController : Controller
    {
        public readonly IBoPhanApiClient _boPhanApiClient;
        public BoPhanController(IBoPhanApiClient boPhanApiClient)
        {
            _boPhanApiClient = boPhanApiClient;
        }
        public async Task<IActionResult> Index(string keyword,int pageIndex = 1, int pageSize = 5)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            var pagingRequest = new GetBoPhanPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            if (TempData["result"] != null)
            {
                ViewBag.Success = true;
                ViewBag.SuccessMessage = TempData["result"];
            }
            var result = await _boPhanApiClient.GetAllWithPaging(pagingRequest);
            return View(result.ResultObj);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BoPhanCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _boPhanApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Tạo bộ phận chức vụ thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}