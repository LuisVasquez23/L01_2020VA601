using System.ComponentModel.DataAnnotations;

namespace L01_2020VA601.Models
{
    public class Pedido
    {

        [Key]
        public int pedidoId { get; set; }

        public int motoristaId { get; set; }
        public int clienteId { get; set; }
        public int platoId { get; set;}
        public int cantidad { get; set; }
        public Decimal precio { get; set; }

    }
}
