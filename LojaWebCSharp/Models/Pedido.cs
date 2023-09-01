using LojaWebCSharp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LojaWebCSharp.Models {
    public class Pedido {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
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
