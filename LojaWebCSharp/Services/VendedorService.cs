using LojaWebCSharp.Data;
using LojaWebCSharp.Models;
using Microsoft.EntityFrameworkCore;
using LojaWebCSharp.Services.Excessoes;

namespace LojaWebCSharp.Services {
    public class VendedorService {
        private readonly LojaWebCSharpContext _context;

        public VendedorService(LojaWebCSharpContext context) {
            _context = context;
        }

        public async Task<List<Vendedor>> FindAllAsync() {
            return await _context.Vendedor.ToListAsync();
        }

        public async Task InsertAsync(Vendedor obj) {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendedor> FindByIdAsync(int id) {
            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id) {
            try { 
            var obj = await _context.Vendedor.FindAsync(id);
            _context.Vendedor.Remove(obj);
            await _context.SaveChangesAsync();
            } catch (DbUpdateException e) {
                throw new Integridade("Não é possivel deletar o vendedor.");

            }
        }

        public async Task UpdateAsync(Vendedor obj) {
            bool hasAny = await _context.Vendedor.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny) {
                throw new NotFoundExcessao("Id não existe"); 
            }
            try {
            _context.Update(obj);
             await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException e) {
                throw new DbConcurrencyExcessao(e.Message);
            }


        }
    }
}
