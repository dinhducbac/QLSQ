using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.SiQuan;
using QLSQ.ViewModel.System.Users;

namespace QLSQ.AdminApp.Controllers
{
    public class SiQuansController : Controller
    {
        public readonly ISiQuanApiClient _siQuanApiClient;
        public readonly IConfiguration _configuration;
        public readonly IRolesApiClient _rolesApiClient;
        public readonly IUserApiClient _userApiClient;

        public SiQuansController(ISiQuanApiClient siQuanApiClient, IRolesApiClient rolesApiClient, IUserApiClient userApiClient, IConfiguration configuration)
        {
            _siQuanApiClient = siQuanApiClient;
            _rolesApiClient = rolesApiClient;
            _userApiClient = userApiClient;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetManageSiQuanPagingRequest() {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var data = await _siQuanApiClient.GetAllManagePaging(request);

            return View(data.ResultObj);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var siquanCreateRequest = new SiQuanCreateRequest()
            {
                userViewModels = new List<UserViewModel>()
            };
            var getuser = await _userApiClient.GetAllUser();
            var user = getuser.ResultObj;
            siquanCreateRequest.userViewModels = user.ToList();
            return View(siquanCreateRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SiQuanCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var test = request.UserId;
            var result = await _siQuanApiClient.Create(request);
            if (result.ResultObj != null)
            {
                TempData["result"] = "Tạo tài khoản thành công!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(result);
        }
        public async Task<IActionResult> Details(int IDSQ)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var test = IDSQ;
            var result = await _siQuanApiClient.GetByID(IDSQ);
            if (result.ResultObj != null)
                return View(result.ResultObj);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int IDSQ)
        {
            var result = await _siQuanApiClient.GetByID(IDSQ);
            if (result.IsSuccessed)
            {
                var siquan = result.ResultObj;
                var siquanUpdateRequest = new SiQuanUpdateRequest()
                {
                    IDSQ = IDSQ,
                    UserId = siquan.UserId,
                    HoTen = siquan.HoTen,
                    NgaySinh = siquan.NgaySinh,
                    GioiTinh = siquan.GioiTinh,
                    QueQuan = siquan.QueQuan,
                    SDT = siquan.SDT
                };
                return View(siquanUpdateRequest);
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SiQuanUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _siQuanApiClient.Update(request.IDSQ, request);
            if(result.IsSuccessed)
                return RedirectToAction("Index");
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int IDSQ)
        {
            var result = await _siQuanApiClient.GetByID(IDSQ);
            if (result.IsSuccessed)
            {
                var siquanDeleteRequest = new SiQuanDeleteRequest()
                {
                    IDSQ = IDSQ,
                    HoTen = result.ResultObj.HoTen
                };
                return View(siquanDeleteRequest);
            }
            return RedirectToAction("Eror", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(SiQuanDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var test = request.IDSQ;
            var result = await _siQuanApiClient.Delete(request.IDSQ, request);
            if (result.IsSuccessed)
                return RedirectToAction("Index");
            return View(result);
        }
    }
}