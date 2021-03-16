using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Common
{
    public class APISuccessedResult<T> : APIResult<T>
    {
        public APISuccessedResult()
        {
            IsSuccessed = true;
        }
        public APISuccessedResult(T resultObj)
        {
            IsSuccessed = true;
            ResultObj = resultObj;
        }

    }
}
