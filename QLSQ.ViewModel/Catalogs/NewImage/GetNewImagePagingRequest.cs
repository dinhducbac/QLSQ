using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.NewImage
{
    public class GetNewImagePagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
        public List<int> NewID { get; set; }
    }
}
