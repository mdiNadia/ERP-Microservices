using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Models
{
    public class AddressDto
    {
        public String Street { get;  set; }
        public String City { get;  set; }
        public String State { get;  set; }
        public String Country { get;  set; }
        public String ZipCode { get;  set; }
        public bool IsCurrentAddress { get;  set; }
    }
}
