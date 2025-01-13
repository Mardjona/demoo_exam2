using System;
using System.Collections.Generic;

namespace demo_exam.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductArticle { get; set; }

    public string? ProductName { get; set; }

    public string? ProdductDscription { get; set; }

    public string? ProductCategory { get; set; }

    public string? ProductPhoto { get; set; }

    public string? ProductFacturer { get; set; }

    public decimal? ProductCost { get; set; }

    public long? ProductQuantityInstock { get; set; }

    public short? ProductDiscountAmount { get; set; }

    public string? ProductStatus { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
