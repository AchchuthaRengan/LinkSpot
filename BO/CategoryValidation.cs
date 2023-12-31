﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class CategoryValidation
    {
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string CategoryDesc { get; set; }
    }

    [MetadataType(typeof(CategoryValidation))]
    public partial class Category
    {

    }
}
