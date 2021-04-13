using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.QLChucVu;
using QLSQ.ViewModel.Catalogs.QLChucVu;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLChucVusController : ControllerBase
    {
        public readonly IQLChucVuServices _qLChucVuServices;
        public QLChucVusController(IQLChucVuServices qLChucVuServices)
        {
            _qLChucVuServices = qLChucVuServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery]GetQLChucVuPagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLChucVuServices.GetAllWithPaging(request);
            if (result.IsSuccessed)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] QLChucVuCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLChucVuServices.Create(request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("{IDQLCV}/details")]
        public async Task<IActionResult> Details(int IDQLCV)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLChucVuServices.Details(IDQLCV);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
    }
}