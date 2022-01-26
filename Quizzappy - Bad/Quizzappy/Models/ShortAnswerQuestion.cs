﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzappy.Models
{
    public class ShortAnswerQuestion : Question
    {
        [Required]
        public float WordLimit { get; set; }
    }
}
