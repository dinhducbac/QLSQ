using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class NewCatetory
    {
        public int NewCatetoryID { get; set; }
        public string NewCatetoryName { get; set; }
        public List<New> News { get; set; }
    }
}
