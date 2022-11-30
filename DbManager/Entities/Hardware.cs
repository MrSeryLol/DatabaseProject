using System;
using System.Collections.Generic;

namespace DbManager.Entities;

public partial class Hardware
{
    public int HardwareId { get; set; }

    public string HardwareName { get; set; } = null!;

    public decimal Price { get; set; }

    public DateOnly? ProductionYear { get; set; }

    public DateOnly PurchaseDate { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
