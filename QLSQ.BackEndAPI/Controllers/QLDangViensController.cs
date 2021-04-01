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
        [HttpGet("{IDQLDV}/details")]
        public async Task<IActionResult> GetById(int IDQLDV)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _qLDangVienServices.GetByID(IDQLDV);
            if (result.IsSuccessed)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("{IDQLDV}/edit")]
        public async Task<IActionResult> Edit(int IDQLDV, [FromBody] QLDangVienUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _qLDangVienServices.Edit(IDQLDV,request);
            if (result.IsSuccessed)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("{IDQLDV}/delete")]
        public async Task<IActionResult> Delete(int IDQLDV)
        {
            var result = await _qLDangVienServices.Delete(IDQLDV);
            if (result.IsSuccessed)
                return Ok(result);
            return BadRequest(result);
        }
    }
}