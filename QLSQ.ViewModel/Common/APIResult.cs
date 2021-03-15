using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Common
{
   public  class APIResult<T>
    {

        public bool IsSuccessed { get; set; }
         public string Message { set; get; }
        public T ResultObj { get; set; }
    }
}
