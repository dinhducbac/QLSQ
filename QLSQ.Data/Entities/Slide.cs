using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class Slide
    {
        public int SlideID { get; set; }
        public string SlideUrl { get; set; }
        public string SlideName { get; set; }
        public string SlideContent { get; set; }
        public string SlideImage { get; set; }
        public DateTime SlideTimePost { get; set; }

    }
}
