using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AOWebApp.Models;

public partial class ItemCategories
{
    [Key]
    public int CategoryId { get; set; }

    public int? ParentCategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<ItemCategories> InverseParentCategory { get; set; } = new List<ItemCategories>();

    public virtual ICollection<Items> Items { get; set; } = new List<Items>();

    public virtual ItemCategories? ParentCategory { get; set; }
}
