using LojaWebCSharp.Models.Enums;

namespace LojaWebCSharp.Models {
    public class Pedido {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Total { get; set;}
        public StatusPedido Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public Pedido() { }

        public Pedido(int id, DateTime data, double total, StatusPedido status, Vendedor vendedor) {
            Id = id;
            Data = data;
            Total = total;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
