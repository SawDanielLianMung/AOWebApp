using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AOWebApp.Models;

public partial class Items
{
    public Items()
    {
        ItemMarkupHistories = new HashSet<ItemMarkupHistory>();
        ItemsInOrders = new HashSet<ItemsInOrder>();
        Reviews = new HashSet<Reviews>();
    }
    [Key]
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public string ItemDescription { get; set; } = null!;

    public decimal ItemCost { get; set; }

    public string ItemImage { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual ItemCategories Category { get; set; } = null!;

    public virtual ICollection<ItemMarkupHistory> ItemMarkupHistories { get; set; } = new List<ItemMarkupHistory>();

    public virtual ICollection<ItemsInOrder> ItemsInOrders { get; set; } = new List<ItemsInOrder>();

    public virtual ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
}
