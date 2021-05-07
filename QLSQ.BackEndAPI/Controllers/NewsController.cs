﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.New;
using QLSQ.ViewModel.Catalogs.New;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        public readonly INewServices _newServices;
        public NewsController(INewServices newServices)
        {
            _newServices = newServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery]GetNewPagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _newServices.GetAllWithPaging(request);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("create")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm]NewCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _newServices.Create(request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("{NewID}/details")]
        public async Task<IActionResult> Details(int NewID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _newServices.Details(NewID);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("{NewID}/edit")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit(int NewID,[FromForm] NewUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _newServices.Edit(NewID,request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("{NewID}/delete")]
        public async Task<IActionResult> Delete(int NewID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _newServices.Delete(NewID);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
    }
}