using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AOWebApp.Models;

public partial class CustomerOrders
{
    [Key]
    public int OrderNumber { get; set; }

    public int CustomerId { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly? DatePaid { get; set; }

    public virtual Customers Customer { get; set; } = null!;

    public virtual ICollection<ItemsInOrder> ItemsInOrders { get; set; } = new List<ItemsInOrder>();
}
