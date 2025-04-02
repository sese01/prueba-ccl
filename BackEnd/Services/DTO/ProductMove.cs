using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class ProductMove
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string Tipo { get; set; } // "entrada" o "salida"
        public int Cantidad { get; set; }
    }
}
