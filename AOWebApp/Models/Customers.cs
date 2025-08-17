using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AOWebApp.Models;

public partial class Customers
{
    [Key]
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MainPhoneNumber { get; set; } = null!;

    public string? SecondaryPhoneNumber { get; set; }

    public int AddressId { get; set; }

    public virtual Addresses Address { get; set; } = null!;

    public virtual ICollection<CustomerOrders> CustomerOrders { get; set; } = new List<CustomerOrders>();

    public virtual ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
}
