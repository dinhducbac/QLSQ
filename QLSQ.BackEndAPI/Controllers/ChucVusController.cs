using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.ChucVu;
using QLSQ.ViewModel.Catalogs.ChucVu;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVusController : ControllerBase
    {
        public readonly IChucVuServices _chucVuServices;
        public ChucVusController(IChucVuServices chucVuServices) 
        {
            _chucVuServices = chucVuServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery]GetChucVuPagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _chucVuServices.GetAllWithPaging(request);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ChucVuCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _chucVuServices.Create(request);
            if(result.ResultObj == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("{IDCV}/details")]
        public async Task<IActionResult> Details(int IDCV)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _chucVuServices.Details(IDCV);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("{IDCV}/edit")]
        public async Task<IActionResult> Edit(int IDCV, ChucVuUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _chucVuServices.Edit(IDCV,request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("{IDCV}/delete")]
        public async Task<IActionResult> Delete(int IDCV)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _chucVuServices.Delete(IDCV);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
    }
}