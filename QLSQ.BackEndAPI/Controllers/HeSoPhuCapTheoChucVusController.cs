using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.HeSoPhuCapTHeoChucVu;
using QLSQ.ViewModel.Catalogs.HeSoPhuCapTheoChucVu;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeSoPhuCapTheoChucVusController : ControllerBase
    {
        public readonly IHeSoPhuCapTheoChucVuServices _heSoPhuCapTheoChucVuServices;
        public HeSoPhuCapTheoChucVusController(IHeSoPhuCapTheoChucVuServices heSoPhuCapTheoChucVuServices)
        {
            _heSoPhuCapTheoChucVuServices = heSoPhuCapTheoChucVuServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery]GetHeSoPhuCapPagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _heSoPhuCapTheoChucVuServices.GetAllWithPaging(request);
            if (result.ResultObj != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]HeSoPhuCapTheoChucVuCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _heSoPhuCapTheoChucVuServices.Create(request);
            if (result.ResultObj != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("{IDHeSoPhuCapCV}/details")]
        public async Task<IActionResult> Details(int IDHeSoPhuCapCV)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _heSoPhuCapTheoChucVuServices.Details(IDHeSoPhuCapCV);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("{IDHeSoPhuCapCV}/edit")]
        public async Task<IActionResult> Edit(int IDHeSoPhuCapCV, HeSoPhuCapTheoChucVuUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _heSoPhuCapTheoChucVuServices.Edit(IDHeSoPhuCapCV, request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("{IDHeSoPhuCapCV}/delete")]
        public async Task<IActionResult> Delete(int IDHeSoPhuCapCV)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _heSoPhuCapTheoChucVuServices.Delete(IDHeSoPhuCapCV);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("{IDCV}/gethesophucapbyidcv")]
        public async Task<IActionResult> GetHeSoPhuCapByIDCV(int IDCV)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _heSoPhuCapTheoChucVuServices.GetHeSoPhuCapByIDCV(IDCV);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }

    }
}