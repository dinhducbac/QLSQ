﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.QLNghiPhep;
using QLSQ.ViewModel.Catalogs.QLNghiPHep;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLNghiPhepsController : ControllerBase
    {
        public readonly IQLNghiPhepServices _qLNghiPhepServices;
        public QLNghiPhepsController(IQLNghiPhepServices qLNghiPhepServices)
        {
            _qLNghiPhepServices = qLNghiPhepServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery] GetQLNghiPhepPagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLNghiPhepServices.GetAllWithPaging(request);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] QLNghiPhepCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLNghiPhepServices.Create(request);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("{IDNP}/details")]
        public async Task<IActionResult> Details(int IDNP)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLNghiPhepServices.Details(IDNP);
            if (result.ResultObj != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("{IDNP}/edit")]
        public async Task<IActionResult> Edit(int IDNP, QLNghiPhepUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLNghiPhepServices.Edit(IDNP, request);
            if (result.IsSuccessed)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("{IDNP}/delete")]
        public async Task<IActionResult> Delete(int IDNP)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLNghiPhepServices.Delete(IDNP);
            if (result.IsSuccessed)
                return Ok(result);
            return BadRequest(result);
        }
    }
}