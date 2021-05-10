using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.ApiIntergration;
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
        [HttpGet]
        public async Task<IActionResult> Details(int IDBP)
        {
            if(!ModelState.IsValid)
                return View(ModelState);
            var result = await _boPhanApiClient.Details(IDBP);
            if (result.ResultObj != null)
                return View(result.ResultObj);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int IDBP)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _boPhanApiClient.Details(IDBP);
            var bpUpdateRequest = new BoPhanUpdateRequest()
            {
                IDBP = result.ResultObj.IDBP,
                TenBP = result.ResultObj.TenBP
            };
            return View(bpUpdateRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BoPhanUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _boPhanApiClient.Edit(request.IDBP, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Sửa bộ phận chức vụ thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int IDBP)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var bp = await _boPhanApiClient.Details(IDBP);
            if(bp.ResultObj != null)
            {
                var bpDeleteRequest = new BoPhanDeleteRequest()
                {
                    IDBP = bp.ResultObj.IDBP,
                    TenBP = bp.ResultObj.TenBP
                };
                return View(bpDeleteRequest);
            }
            return View(bp);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(BoPhanDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _boPhanApiClient.Delete(request.IDBP);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa bộ phận thành công";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}