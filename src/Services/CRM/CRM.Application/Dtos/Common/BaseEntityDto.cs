using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Dtos.Common
{
    public abstract class BaseEntityDto
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

    }
}
