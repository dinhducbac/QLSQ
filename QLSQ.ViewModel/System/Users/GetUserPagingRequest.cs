using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string keyword { set; get; }
    }
}
