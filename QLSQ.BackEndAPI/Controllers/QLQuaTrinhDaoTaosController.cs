using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.QLQuaTrinhDaoTao;
using QLSQ.ViewModel.Catalogs.QLQuaTrinhDaoTao;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLQuaTrinhDaoTaosController : ControllerBase
    {
        public readonly IQLQuaTrinhDaoTaoServices _qLQuaTrinhDaoTaoServices;
        public QLQuaTrinhDaoTaosController(IQLQuaTrinhDaoTaoServices qLQuaTrinhDaoTaoServices)
        {
            _qLQuaTrinhDaoTaoServices = qLQuaTrinhDaoTaoServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery]GetQLQuaTrinhDaoTaoPagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLQuaTrinhDaoTaoServices.GetAllWithPaging(request);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] QLQuaTrinhDaoTaoCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLQuaTrinhDaoTaoServices.Create(request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("{IDQLQTDT}/details")]
        public async Task<IActionResult> Details(int IDQLQTDT)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLQuaTrinhDaoTaoServices.Details(IDQLQTDT);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("{IDQLQTDT}/edit")]
        public async Task<IActionResult> Edit(int IDQLQTDT,[FromBody] QLQuaTrinhDaoTaoUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLQuaTrinhDaoTaoServices.Edit(IDQLQTDT,request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
    }
}