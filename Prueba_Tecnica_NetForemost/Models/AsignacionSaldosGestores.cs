using System.ComponentModel.DataAnnotations;

namespace Prueba_Tecnica_NetForemost.Models
{
    public class AsignacionSaldosGestores
    {
        [Key]
        public int GestorID { get; set; }
        public int NumSaldos { get; set; }
        public decimal Monto { get; set; }
        public string GestorNombre { get; set; } = null!;
    }
}
