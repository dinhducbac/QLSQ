using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.ApiIntergration;
using QLSQ.ViewModel.Catalogs.NewCatetory;

namespace QLSQ.AdminApp.Controllers
{
    public class NewCatetoryController : Controller
    {
        public readonly INewCatetoryApiClient _newCatetoryApiClient;
        public NewCatetoryController(INewCatetoryApiClient newCatetoryApiClient)
        {
            _newCatetoryApiClient = newCatetoryApiClient;
        }
        public async Task<IActionResult> Index( string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var pagingRequest = new GetNewCatetoryPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _newCatetoryApiClient.GetAllWithPaging(pagingRequest);
            if(result.ResultObj != null)
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewCatetoryCreateRequest request)
        {
            var result = await _newCatetoryApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Tạo loại tin tức thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int NewCatetoryID)
        {
            var result = await _newCatetoryApiClient.Details(NewCatetoryID);
            if (result.ResultObj != null)
                return View(result.ResultObj);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int NewCatetoryID)
        {
            var result = await _newCatetoryApiClient.Details(NewCatetoryID);
            var newcatetoryUpdateRequest = new NewCatetoryUpdateRequest()
            {
                NewCatetoryID = result.ResultObj.NewCatetoryID,
                NewCatetoryName = result.ResultObj.NewCatetoryName
            };
            return View(newcatetoryUpdateRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(NewCatetoryUpdateRequest request)
        {
            var result = await _newCatetoryApiClient.Edit(request.NewCatetoryID, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Sửa loại tin tức thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int NewCatetoryID)
        {
            var result = await _newCatetoryApiClient.Details(NewCatetoryID);
            return View(result.ResultObj);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(NewCatetoryViewModel newCatetoryViewModel)
        {
            var result = await _newCatetoryApiClient.Delete(newCatetoryViewModel.NewCatetoryID);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa loại tin tức thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}