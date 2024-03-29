﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.SiQuanImage;
using QLSQ.ViewModel.Catalogs.SiQuanImage;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiQuanImagesController : ControllerBase
    {
        public readonly ISiQuanImageServices _siQuanImageServices;
        public SiQuanImagesController(ISiQuanImageServices siQuanImageServices)
        {
            _siQuanImageServices = siQuanImageServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery]GetSiQuanImagePagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _siQuanImageServices.GetAllWithPaging(request);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("create")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] SiQuanImageCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _siQuanImageServices.Create(request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("{IDImage}/details")]
        public async Task<IActionResult> Details(int IDImage)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _siQuanImageServices.Details(IDImage);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("{IDImage}/edit")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit(int IDImage,[FromForm] SiQuanImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _siQuanImageServices.Edit(IDImage,request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("{IDImage}/delete")]
        public async Task<IActionResult> Delete(int IDImage)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _siQuanImageServices.Delete(IDImage);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
    }
}