﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Interfaces
{
    public interface IPaginationFilter
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}
