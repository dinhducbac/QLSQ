using QLSQ.ViewModel.Catalogs.Slide;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.Catalog.Slide
{
    public interface ISlideServices
    {
        public Task<APIResult<List<SlideViewModel>>> GetAllWithoutPaging();
    }
}
