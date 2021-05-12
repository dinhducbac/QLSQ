using QLSQ.ViewModel.Catalogs.New;
using QLSQ.ViewModel.Catalogs.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.WebApp.Models
{
    public class HomeViewModel
    {
        public List<SlideViewModel> SlideViewModels { get; set; }
        public List<NewDetailsViewModel> LastestNews { get; set; }
        public List<NewDetailsViewModel> MostViewNews { get; set; }
        public List<NewDetailsViewModel> KHCNNewInInDex { get; set; }
        public List<NewDetailsViewModel> TuyenSinhNewInIndexs { get; set; }
    }
}
