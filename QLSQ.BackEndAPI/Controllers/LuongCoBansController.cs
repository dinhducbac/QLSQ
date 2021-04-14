using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.LuongCoBan;
using QLSQ.ViewModel.Catalogs.LuongCoBan;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LuongCoBansController : ControllerBase
    {
        public readonly ILuongCoBanServices _luongCoBanServices;
        public LuongCoBansController(ILuongCoBanServices luongCoBanServices)
        {
            _luongCoBanServices = luongCoBanServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery]GetLuongCoBanPagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _luongCoBanServices.GetALLWithPaging(request);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("{IDLuongCB}/details")]
        public async Task<IActionResult> Details(int IDLuongCB)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _luongCoBanServices.Details(IDLuongCB);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("{IDLuongCB}/edit")]
        public async Task<IActionResult> Edit(int IDLuongCB, LuongCoBanUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _luongCoBanServices.Edit(IDLuongCB,request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
    }
}