using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.QLLuong;
using QLSQ.ViewModel.Catalogs.QLLuong;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLLuongsController : ControllerBase
    {
        private readonly IQLLuongServices _qLLuongServices;
        public QLLuongsController(IQLLuongServices qLLuongServices)
        {
            _qLLuongServices = qLLuongServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery]GetQLLuongPagingRequest request)
        {
            var qll = await _qLLuongServices.GetAllWithPaging(request);
            return Ok(qll);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]QLLuongCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLLuongServices.Create(request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
    }
}