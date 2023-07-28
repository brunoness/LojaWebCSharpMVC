using LojaWebCSharp.Data;
using LojaWebCSharp.Models;

namespace LojaWebCSharp.Services {
    public class VendedorService {
        private readonly LojaWebCSharpContext _context;

        public VendedorService(LojaWebCSharpContext context) {
            _context = context;
        }

        public List<Vendedor> FindAll() {
            return _context.Vendedor.ToList();
        }
    }
}
