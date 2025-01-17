using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.IO;

namespace demo_exam.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductArticle { get; set; }

    public string? ProductName { get; set; }

    public string? ProdductDscription { get; set; }

    public int? ProductCategory { get; set; }

    public string? ProductPhoto { get; set; }
    public Bitmap? Image => File.Exists($"ТОвар/{ProductPhoto}") ? new Bitmap($"./ТОвар/{ProductPhoto}") : new Bitmap($"./ТОвар/picture.png");

    public int? ProductFacturer { get; set; }

    public decimal? ProductCost { get; set; }
    public string? GetCost => ProductCost + " руб.";

    public long? ProductQuantityInstock { get; set; }
    public string GetQuantity => ProductQuantityInstock + " шт.";

    public short? ProductDiscountAmount { get; set; }

    public string? ProductStatus { get; set; }

    public virtual Category? ProductCategoryNavigation { get; set; }

    public virtual Manufacture? ProductFacturerNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
