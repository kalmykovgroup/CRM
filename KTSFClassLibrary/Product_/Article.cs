﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.Product_
{ 
    public class Article
    { 
        public int Id { get; set; }
         
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
