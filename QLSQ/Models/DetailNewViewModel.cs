using QLSQ.ViewModel.Catalogs.New;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.WebApp.Models
{
    public class DetailNewViewModel
    {
        public int NewID { get; set; }
        public int NewCatetoryID { get; set; }
        public string NewCatetoryName { get; set; }
        public DateTime NewDatePost { get; set; }
        public string ImagePath { get; set; }
        public string NewName { get; set; }
        public string NewContent { get; set; }

        public List<NewDetailsViewModel> ListMostViewNew { get; set; }
        public List<NewDetailsViewModel> ListRelatedNew { get; set; }
    }
}
