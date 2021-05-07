using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.NewImage;
using QLSQ.ViewModel.Catalogs.NewImage;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewImagesController : ControllerBase
    {
        public readonly INewImageServices _newImageServices;
        public NewImagesController(INewImageServices newImageServices)
        {
            _newImageServices = newImageServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery]GetNewImagePagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _newImageServices.GetAllWithPaging(request);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("create")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] NewImageCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _newImageServices.Create(request);
            if (result.IsSuccessed)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("{NewImageID}/details")]
        public async Task<IActionResult> Details(int NewImageID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _newImageServices.Details(NewImageID);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        } 
        [HttpPut("{NewImageID}/edit")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit(int NewImageID,[FromForm]NewImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _newImageServices.Edit(NewImageID,request);
            if (result.IsSuccessed)
                return Ok(result);
            return BadRequest(result);
        }
    }
}