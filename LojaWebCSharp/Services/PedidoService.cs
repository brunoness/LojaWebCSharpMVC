using LojaWebCSharp.Data;
using LojaWebCSharp.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaWebCSharp.Services {
    public class PedidoService {
        private readonly LojaWebCSharpContext _context;

        public PedidoService(LojaWebCSharpContext context) {
            _context = context;
        }

        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate) {
            var result = from obj in _context.Pedido select obj;
            if (minDate.HasValue) {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue) {
                result = result.Where(x => x.Data <= maxDate.Value);
            }
            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Departamento, Pedido>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate) {
            var result = from obj in _context.Pedido select obj;
            if (minDate.HasValue) {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue) {
                result = result.Where(x => x.Data <= maxDate.Value);
            }
            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .GroupBy(x => x.Vendedor.Departamento)
                .ToListAsync();
        }
    }

}