using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzappy.Models
{
    public class TextAnswer
    {
        [Key]
        public int AnswerId { get; set; }
        public string Answer { get; set; }
    }
}
