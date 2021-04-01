using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.QLCongTac;
using QLSQ.ViewModel.Catalogs.QLCongTac;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLCongTacsController : ControllerBase
    {
        private readonly IQLCongTacServices _qLCongTacServices;
        public QLCongTacsController(IQLCongTacServices qLCongTacServices)
        {
            _qLCongTacServices = qLCongTacServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAll([FromQuery] GetQLCongTacPagingRequest request)
        {
            var result = await _qLCongTacServices.GetAll(request);
            return Ok(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] QLCongTacCreateRequest request)
        {
            var result = await _qLCongTacServices.Create(request);
            return Ok(result);
        }
        [HttpGet("{IDCT}/details")]
        public async Task<IActionResult> Details(int IDCT)
        {
            var result = await _qLCongTacServices.Details(IDCT);
            return Ok(result);
        }
        [HttpPut("{IDCT}/edit")]
        public async Task<IActionResult> Edit(int IDCT, QLCongTacUpdateRequest request)
        {
            var result = await _qLCongTacServices.Edit(IDCT,request);
            return Ok(result);

        }
        [HttpDelete("{IDCT}/delete")]
        public async Task<IActionResult> Delete(int IDCT)
        {
            var result = await _qLCongTacServices.Delete(IDCT);
            return Ok(result);
        }
    }
}