﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }    
        public DateTime CreationDate { get; set; } = DateTime.Now;

    }
}
