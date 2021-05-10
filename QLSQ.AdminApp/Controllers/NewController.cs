using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using QLSQ.ApiIntergration;
using QLSQ.ViewModel.Catalogs.New;

namespace QLSQ.AdminApp.Controllers
{
    public class NewController : Controller
    {
        public readonly INewApiClient _newApiClient;
        public NewController(INewApiClient newApiClient)
        {
            _newApiClient = newApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Error", "Home");
            var pagingRequest = new GetNewPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _newApiClient.GetAllWithPaging(pagingRequest);
            if(result.ResultObj != null)
            {
                if (TempData["result"] != null)
                {
                    ViewBag.Success = true;
                    ViewBag.SuccessMessage = TempData["result"];
                }
                return View(result.ResultObj);
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm]NewCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _newApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Tạo tin mới thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error","Home");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int NewID)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _newApiClient.Details(NewID);
            if (result.ResultObj != null)
                return View(result.ResultObj);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int NewID)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _newApiClient.Details(NewID);
            var newsUpdateRequest = new NewUpdateRequest()
            {
                NewName = result.ResultObj.NewName,
                NewContent = result.ResultObj.NewContent,
                NewDatePost = result.ResultObj.NewDatePost,
                NewCount = result.ResultObj.NewCount,
                ImagePath = result.ResultObj.ImagePath
            };
            return View(newsUpdateRequest);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm]NewUpdateRequest request)
        {
            var result = await _newApiClient.Edit(request.NewID, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Sửa in tức thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int NewID)
        {
            var result = await _newApiClient.Details(NewID);
            var newsDeleteReaquest = new NewDeleteRequest()
            {
                NewID = result.ResultObj.NewID,
                NewName = result.ResultObj.NewName,
                ImagePath = result.ResultObj.ImagePath,
                NewContent = result.ResultObj.NewContent,
                NewDatePost = result.ResultObj.NewDatePost,
                NewCount = result.ResultObj.NewCount

            };
            return View(newsDeleteReaquest);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(NewDeleteRequest request)
        {
            var result = await _newApiClient.Delete(request.NewID);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa tin tức thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}