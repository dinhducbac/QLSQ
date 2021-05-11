using QLSQ.ViewModel.Catalogs.Slide;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.ApiIntergration
{
    public interface ISlideApiClient
    {
        public Task<APIResult<List<SlideViewModel>>> GetAllWithoutPaging();
    }
}
