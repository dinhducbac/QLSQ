﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.NewImage;

namespace QLSQ.AdminApp.Controllers
{
    public class NewImageController : Controller
    {
        public readonly INewImageApiClient _newImageApiClient;
        public readonly INewApiClient _newApiClient;
        public NewImageController(INewImageApiClient newImageApiClient, INewApiClient newApiClient)
        {
            _newImageApiClient = newImageApiClient;
            _newApiClient = newApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var pagingRequest = new GetNewImagePagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _newImageApiClient.GetAllWithPaging(pagingRequest);
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
        public async Task<JsonResult> GetListNewAutoComplete(string prefix)
        {
           var result = await _newApiClient.GetListNewAutoComplete(prefix);
            return Json(result.ResultObj);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create(NewImageCreateRequest request)
        {
            var result = await _newImageApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Tạo ảnh tin tức thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int NewImageID)
        {
            var result = await _newImageApiClient.Details(NewImageID);
            if (result.ResultObj != null)
                return View(result.ResultObj);
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int NewImageID)
        {
            var result = await _newImageApiClient.Details(NewImageID);
            var newImageUpdateRequest = new NewImageUpdateRequest()
            {
                NewImageID = result.ResultObj.NewImageID,
                NewID = result.ResultObj.NewID,
                NewName = result.ResultObj.NewName,
                ImagePath = result.ResultObj.ImagePath,
                DateCreated = result.ResultObj.DateCreated,
                FileSize = result.ResultObj.FileSize
            };
            return View(newImageUpdateRequest);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm]NewImageUpdateRequest request)
        {
            var result = await _newImageApiClient.Edit(request.NewID,request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Sửa ảnh tin tức thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}