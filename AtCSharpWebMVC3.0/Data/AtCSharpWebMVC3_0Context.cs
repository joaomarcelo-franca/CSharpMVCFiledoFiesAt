using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AtCSharpWebMVC3._0.Models;

namespace AtCSharpWebMVC3._0.Data
{
    public class AtCSharpWebMVC3_0Context : DbContext
    {
        public AtCSharpWebMVC3_0Context (DbContextOptions<AtCSharpWebMVC3_0Context> options)
            : base(options)
        {
        }

        public DbSet<AtCSharpWebMVC3._0.Models.AlunoModel> AlunoModel { get; set; } = default!;

        public DbSet<AtCSharpWebMVC3._0.Models.ProfessorModel>? ProfessorModel { get; set; }
    }
}
