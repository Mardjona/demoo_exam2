using System;
using System.Collections.Generic;

namespace demo_exam.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? OrderStatus { get; set; }

    public DateTime? OrderDeliveryDate { get; set; }

    public string? OrderPickupPoint { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
