using System.ComponentModel.DataAnnotations;

namespace L01_2020VA601.Models
{
    public class Plato
    {
        [Key]
        public int platoId { get; set; }

        public string? nombrePlato { get; set; }
        public Decimal? precio { get; set; }
    }
}
