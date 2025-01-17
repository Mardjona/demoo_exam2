using System;
using System.Collections.Generic;

namespace demo_exam.Models;

public partial class Manufacture
{
    public int IdManufacture { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
