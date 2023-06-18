using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LojaWebCSharp.Models;

namespace LojaWebCSharp.Data
{
    public class LojaWebCSharpContext : DbContext
    {
        public LojaWebCSharpContext (DbContextOptions<LojaWebCSharpContext> options)
            : base(options)
        {
        }

        public DbSet<LojaWebCSharp.Models.Department> Department { get; set; } = default!;

        public DbSet<LojaWebCSharp.Models.Departamento>? Departamento { get; set; }
    }
}
