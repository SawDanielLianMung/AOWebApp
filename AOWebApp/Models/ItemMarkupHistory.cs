using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AOWebApp.Models;

public partial class ItemMarkupHistory
{
    [Key]
    public int ItemId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal Markup { get; set; }

    public bool Sale { get; set; }

    public virtual Items Item { get; set; } = null!;
}
