﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Models.Common
{
    public class GetLookupDto
    {
        public string Id {  get; set; }
        public string Name { get; set; }
        public DateTime CreationDate {  get; set; }
    }
}
