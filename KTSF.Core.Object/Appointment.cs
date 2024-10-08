﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Core.Object
{
    [Table("appointments")]
    public class Appointment
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; } = String.Empty;

        [MaxLength(1000)]
        public string Description { get; set; } = String.Empty;

        public override string ToString() => Name;
    }
}
