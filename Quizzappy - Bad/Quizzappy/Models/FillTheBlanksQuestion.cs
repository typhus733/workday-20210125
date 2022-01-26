using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzappy.Models
{
    public class FillTheBlanksQuestion
    {
        [Required]
        public List<TextAnswer> CorrectAnswers { get; set; }
    }
}
