using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QLSQ.ApiIntergration;
using QLSQ.ViewModel.Catalogs.QLDangVien;
using QLSQ.ViewModel.Catalogs.SiQuan;

namespace QLSQ.AdminApp.Controllers
{
    public class QLDangVienController : Controller
    {
        public readonly IQLDangVienAPIClient _qLDangVienAPIClient;
        public readonly ISiQuanApiClient _siQuanApiClient;
        public readonly IConfiguration _configuration;

        public QLDangVienController(IQLDangVienAPIClient qLDangVienAPIClient, ISiQuanApiClient siQuanApiClient, IRolesApiClient rolesApiClient, IUserApiClient userApiClient, IConfiguration configuration)
        {
            _qLDangVienAPIClient = qLDangVienAPIClient;
            _siQuanApiClient = siQuanApiClient;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetQLDangVienPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _qLDangVienAPIClient.GetAllQLDangVien(request);
            if (TempData["result"] != null)
            {
                ViewBag.Success = true;
                ViewBag.SuccessMessage = TempData["result"];
            }
            return View(result.ResultObj);
        }
        [HttpGet]
        public async Task<JsonResult> GetListSiQuanNotInQLDangVienAutoComplete(string prefix)
        {
            var result = await _siQuanApiClient.GetListSiQuanNotInQLDangVienAutoComplete(prefix);
            var test = result.ResultObj;
            return Json(result.ResultObj);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var qldvCreateRequest = new QLDangVienCreateRequest();
            return View(qldvCreateRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Create(QLDangVienCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _qLDangVienAPIClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Tạo đảng viên thành công!";
                return RedirectToAction("Index");
            }           
            return View(result);
        }
        public async Task<IActionResult> Details(int IDQLDV)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _qLDangVienAPIClient.GetByID(IDQLDV);
            if (result.ResultObj != null)
                return View(result.ResultObj);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int IDQLDV)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _qLDangVienAPIClient.GetByID(IDQLDV);
            if (result.ResultObj != null)
            {
                var qldvUpdateRequest = new QLDangVienUpdateRequest()
                {
                    IDQLDV = result.ResultObj.IDQLDV,
                    IDSQ = result.ResultObj.IDSQ,
                    HoTen = result.ResultObj.HoTen,
                    NgayVaoDang = result.ResultObj.NgayVaoDang,
                    NoiVaoDang = result.ResultObj.NoiVaoDang
                };
                return View(qldvUpdateRequest);
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(QLDangVienUpdateRequest request)
        {
            var result = await _qLDangVienAPIClient.Edit(request.IDQLDV, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Sửa đảng viên thành công!";
                return RedirectToAction("Index");
            }
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int IDQLDV)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _qLDangVienAPIClient.GetByID(IDQLDV);
            var qldvDeleteRequest = new QLDangVienDeleteRequest()
            {
                IDQLDV = result.ResultObj.IDQLDV,
                IDSQ = result.ResultObj.IDSQ,
                HoTen = result.ResultObj.HoTen,
                NgayVaoDang = result.ResultObj.NgayVaoDang,
                NoiVaoDang = result.ResultObj.NoiVaoDang
            };
            return View(qldvDeleteRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(QLDangVienDeleteRequest request)
        {
            var result = await _qLDangVienAPIClient.Delete(request.IDQLDV);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa đảng viên thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Eror", "Home");
        }
    }
}