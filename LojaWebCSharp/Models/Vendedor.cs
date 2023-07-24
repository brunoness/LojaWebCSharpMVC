namespace LojaWebCSharp.Models {
    public class Vendedor {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento  { get; set; }
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
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
