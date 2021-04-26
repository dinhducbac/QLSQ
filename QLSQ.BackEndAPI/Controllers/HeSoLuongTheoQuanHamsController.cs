using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.HeSoLuongTheoQuanHam;
using QLSQ.ViewModel.Catalogs.HeSoLuongTheoQuanHam;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeSoLuongTheoQuanHamsController : ControllerBase
    {
        public readonly IHeSoLuongTheoQuanHamServices _heSoLuongTheoQuanHamServices;
        public HeSoLuongTheoQuanHamsController(IHeSoLuongTheoQuanHamServices heSoLuongTheoQuanHamServices)
        {
            _heSoLuongTheoQuanHamServices = heSoLuongTheoQuanHamServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery]GetPagingRequestHeSoLuongTheoQuanHam request)
        {
            var result = await _heSoLuongTheoQuanHamServices.GetAllWithPaging(request);
            return Ok(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] HeSoLuongTheoQuanHamCreateRequest request)
        {
            var result = await _heSoLuongTheoQuanHamServices.Create(request);
            return Ok(result);
        }
        [HttpGet("{IDHeSoLuongQH}/details")]
        public async Task<IActionResult> Details(int IDHeSoLuongQH)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _heSoLuongTheoQuanHamServices.Details(IDHeSoLuongQH);
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut("{IDHeSoLuongQH}/edit")]
        public async Task<IActionResult> Edit(int IDHeSoLuongQH, HeSoLuongTheoQuanHamUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _heSoLuongTheoQuanHamServices.Edit(IDHeSoLuongQH, request);
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete("{IDHeSoLuongQH}/delete")]
        public async Task<IActionResult> Delete(int IDHeSoLuongQH)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _heSoLuongTheoQuanHamServices.Delete(IDHeSoLuongQH);
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPost("checkname")]
        public async Task<IActionResult> CheckNameHeSoLuongInCreate([FromBody]string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _heSoLuongTheoQuanHamServices.CheckNameHeSoLuongInCreate(name);
            if (result.IsSuccessed)
                return Ok(result);
            return BadRequest(result);
        }
    }
}