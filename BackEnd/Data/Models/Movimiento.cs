using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Movimiento
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public string TipoMovimiento { get; set; } = null!;

    public int Cantidad { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}
