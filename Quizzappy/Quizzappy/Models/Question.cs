using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzappy.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [Required]
        public int Score { get; set; }
        [Required]
        public string QuestionText { get; set; }
    }
}
