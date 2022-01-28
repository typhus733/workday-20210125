using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzappy.Models
{
    public class MultipleChoiceQuestion : Question
    {
        [Required]
        public virtual List<TextAnswer> Answers { get; set; }
        [Required]
        public string CorrectAnswer { get; set; }
    }
}
