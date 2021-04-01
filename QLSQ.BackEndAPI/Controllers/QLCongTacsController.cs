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
    }
}