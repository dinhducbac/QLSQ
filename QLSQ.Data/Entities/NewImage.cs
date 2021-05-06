using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class NewImage
    {
        public int NewImageID { get; set; }
        public int NewID { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateCreated { get; set; }
        public long FileSize { get; set; }

        public New New { get; set; }
    }
}
