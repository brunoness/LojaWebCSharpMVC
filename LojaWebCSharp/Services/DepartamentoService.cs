using LojaWebCSharp.Data;
using LojaWebCSharp.Models;
using System.Linq;

namespace LojaWebCSharp.Services {
    public class DepartamentoService {
        private readonly LojaWebCSharpContext _context;

        public DepartamentoService(LojaWebCSharpContext context) {
            _context = context;
        }

        public List<Departamento> FindAll() {
            return _context.Departamento.OrderBy(X => X.Nome).ToList();
        }

    }
}
