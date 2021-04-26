using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QLSQ.Application.Catalog.QLQuanHam;
using QLSQ.ViewModel.Catalogs.QLQuanHam;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLQuanHamsController : ControllerBase
    {
        public readonly IQLQuanHamServices _qLQuanHamServices;
        public QLQuanHamsController(IQLQuanHamServices qLQuanHamServices)
        {
            _qLQuanHamServices = qLQuanHamServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery]GetQLQuanHamPagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLQuanHamServices.GetAllWithPaging(request);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }

    }
}