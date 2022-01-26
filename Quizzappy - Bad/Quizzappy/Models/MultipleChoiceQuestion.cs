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
        public List<TextAnswer> Answers { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
