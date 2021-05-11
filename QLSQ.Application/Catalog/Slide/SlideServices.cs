using QLSQ.Data.EF;
using QLSQ.ViewModel.Catalogs.Slide;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLSQ.Application.Catalog.Slide
{
    public class SlideServices : ISlideServices
    {
        public readonly QL_SiQuanDBContext _context;
        public SlideServices(QL_SiQuanDBContext context)
        {
            _context = context;
        }
        public async Task<APIResult<List<SlideViewModel>>> GetAllWithoutPaging()
        {
            var listSlide = await (from slide in _context.Slides
                                   orderby slide.SlideTimePost descending
                                   select new SlideViewModel() 
                                   {
                                        SlideID = slide.SlideID,
                                        SlideUrl = slide.SlideUrl,
                                        SlideName = slide.SlideName,
                                        SlideContent = slide.SlideContent,
                                        SlideImage = slide.SlideImage,
                                        SlideTimePost = slide.SlideTimePost
                                   }).Take(4).ToListAsync();
            return new APISuccessedResult<List<SlideViewModel>>(listSlide);
        }
    }
}
