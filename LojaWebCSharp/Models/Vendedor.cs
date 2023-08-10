using System.ComponentModel.DataAnnotations;

namespace LojaWebCSharp.Models {
    public class Vendedor {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento  { get; set; }

        [Display(Name = "Salário Base")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

        public Vendedor() { }
        public Vendedor(int id, string name, string email, DateTime dataNascimento, double salarioBase, Departamento departamento) {
            Id = id;
            Name = name;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AdicionarPedido(Pedido sr) {
            Pedidos.Add(sr);
        }

        public void RemoverPedido(Pedido sr) {
            Pedidos.Remove(sr);
        }

        public double TotalPedidos(DateTime inicial, DateTime final) {
            return Pedidos.Where(sr => sr.Data >= inicial && sr.Data <= final).Sum(sr => sr.Total);
        }
    }
}
