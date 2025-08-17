using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AOWebApp.Models;

public partial class ItemsInOrder
{
    [Key]
    public int OrderNumber { get; set; }

    public int ItemId { get; set; }

    public int NumberOf { get; set; }

    public decimal? TotalItemCost { get; set; }

    public virtual Items Item { get; set; } = null!;

    public virtual CustomerOrders OrderNumberNavigation { get; set; } = null!;
}
