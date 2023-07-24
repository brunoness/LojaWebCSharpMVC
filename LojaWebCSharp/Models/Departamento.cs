using Microsoft.AspNetCore.Authentication;

namespace LojaWebCSharp.Models {
    public class Departamento {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Departamento() { }

        public Departamento(int id, string nome) {
            Id = id;
            Nome = nome;
        }

        public void AdicionarVendedor(Vendedor vendedor) {
            Vendedores.Add(vendedor);
        }
        public void RemoverVendedor(Vendedor vendedor) {
            Vendedores.Remove(vendedor);
        }


        public double TotalPedidos(DateTime inicial, DateTime final) {
            return Vendedores.Sum(vendedor => vendedor.TotalPedidos(inicial, final));
        }
    }
}