using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.ApiIntergration;
using QLSQ.ViewModel.Catalogs.ChucVu;

namespace QLSQ.AdminApp.Controllers
{
    public class ChucVuController : Controller
    {
        public readonly IChucVuApiClient _chucVuApiClient;
        public readonly IBoPhanApiClient _boPhanApiClient;
        public ChucVuController(IChucVuApiClient chucVuApiClient, IBoPhanApiClient boPhanApiClient)
        {
            _chucVuApiClient = chucVuApiClient;
            _boPhanApiClient = boPhanApiClient;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var pagingRequest = new GetChucVuPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _chucVuApiClient.GetAllWithPaging(pagingRequest);
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
        public async Task<IActionResult> Create()
        {
            var cvCreateRequest = new ChucVuCreateRequest()
            {
                boPhanViewModels = new List<ViewModel.Catalogs.BoPhan.BoPhanViewModel>()
            };
            var getListCV = await _boPhanApiClient.GetAllWithNotPaging();
            var listCV = getListCV.ResultObj;
            cvCreateRequest.boPhanViewModels = listCV;
            return View(cvCreateRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ChucVuCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _chucVuApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Tạo chức vụ thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int IDCV)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _chucVuApiClient.Details(IDCV);
            if (result.IsSuccessed)
            {
                return View(result.ResultObj);
            }
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int IDCV)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var cvModel = await _chucVuApiClient.Details(IDCV);

            var cvUpdateRequest = new ChucVuUpdateRequest()
            {
                IDBP = cvModel.ResultObj.IDBP,
                IDCV = cvModel.ResultObj.IDCV,
                TenCV = cvModel.ResultObj.TenCV,
                boPhanViewModels = new List<ViewModel.Catalogs.BoPhan.BoPhanViewModel>()
                
            };
            var getlistbp = await _boPhanApiClient.GetAllWithNotPaging();
            var listbp = getlistbp.ResultObj;
            cvUpdateRequest.boPhanViewModels = listbp;
            return View(cvUpdateRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ChucVuUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _chucVuApiClient.Edit(request.IDCV, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Sửa chức vụ thành công";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int IDCV)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var cv = await _chucVuApiClient.Details(IDCV);
            var cvDeleteRequest = new ChucVuDeleteRequest()
            {
                TenBP = cv.ResultObj.TenBP,
                IDCV = cv.ResultObj.IDCV,
                TenCV = cv.ResultObj.TenCV
            };
            return View(cvDeleteRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ChucVuDeleteRequest request)
        {
            var result = await _chucVuApiClient.Delete(request.IDCV);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa chức vụ thành công";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}