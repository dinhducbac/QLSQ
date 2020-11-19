﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Application.Dtos
{
    public class PageResult<T>
    {
        public List<T> Items { set; get; }
        public int TotalRecord { set; get; } 
    }
}
