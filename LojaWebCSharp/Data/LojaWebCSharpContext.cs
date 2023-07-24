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

        public DbSet<Departamento>? Departamento { get; set; } = default!;
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
    }
}
