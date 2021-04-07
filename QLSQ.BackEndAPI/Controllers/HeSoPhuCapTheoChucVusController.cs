﻿using System;
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
            if(result.ResultObj != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}