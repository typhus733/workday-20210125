using Microsoft.EntityFrameworkCore;
using Quizzappy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzappy.Daos
{
    
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options) : base(options)
        {

        }

        public DbSet<Quiz> Quizzes { get; set; }
    }
}
