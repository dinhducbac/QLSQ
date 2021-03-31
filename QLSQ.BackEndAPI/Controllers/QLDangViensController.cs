using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.QLDangVien;
using QLSQ.ViewModel.Catalogs.QLDangVien;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class QLDangViensController : ControllerBase
    {
        private readonly IQLDangVienServices _qLDangVienServices;
        public QLDangViensController(IQLDangVienServices qLDangVienServices)
        {
            _qLDangVienServices = qLDangVienServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllQLDangVien([FromQuery]GetQLDangVienPagingRequest request)
        {
            var qldv = await _qLDangVienServices.GetAllQLDangVien(request);
            return Ok(qldv);
        }
        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] QLDangVienCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _qLDangVienServices.Create(request);
            if (result.IsSuccessed)
                return Ok(result);
            return BadRequest(result);
        }
    }
}