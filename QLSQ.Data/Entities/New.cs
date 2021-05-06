using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class New
    {
        public int NewID { get; set; }
        public string NewName { get; set; }
        public string NewContent { get; set; }
        public DateTime NewDatePost { get; set; }
        public int NewCount { get; set; }

        public List<NewImage> NewImages { get; set; }
    }
}
