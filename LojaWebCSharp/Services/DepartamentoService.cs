using LojaWebCSharp.Data;
using LojaWebCSharp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LojaWebCSharp.Services {
    public class DepartamentoService {
        private readonly LojaWebCSharpContext _context;

        public DepartamentoService(LojaWebCSharpContext context) {
            _context = context;
        }

        public async Task<List<Departamento>> FindAllAsync() {
            return await _context.Departamento.OrderBy(X => X.Nome).ToListAsync();
        }

    }
}
