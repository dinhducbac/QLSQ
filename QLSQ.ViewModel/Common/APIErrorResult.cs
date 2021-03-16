using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Common
{
    public class APIErrorResult<T> : APIResult<T>
    {
        public string[] ValidationError { set; get; } 
        public APIErrorResult(string message)
        {
            IsSuccessed = false;
            Message = message;
        }
        public APIErrorResult(string[] Validation)
        {
            IsSuccessed = false;
            ValidationError = Validation;
        }
    }
}
