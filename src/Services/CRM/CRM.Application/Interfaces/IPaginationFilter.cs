using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces
{
    public interface IPaginationFilter
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }

    }
}
