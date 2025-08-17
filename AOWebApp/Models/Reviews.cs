using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AOWebApp.Models;

public partial class Reviews
{
    [Key]
    public int ReviewId { get; set; }

    public int CustomerId { get; set; }

    public DateOnly ReviewDate { get; set; }

    public int ItemId { get; set; }

    public int Rating { get; set; }

    public string ReviewDescription { get; set; } = null!;

    public virtual Customers Customer { get; set; } = null!;

    public virtual Items Item { get; set; } = null!;
}
