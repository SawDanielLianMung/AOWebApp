using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AOWebApp.Models;

public partial class Customers
{

    [Key]
    public int CustomerId { get; set; }

    [Display(Name ="Firt Name")]
    public string FirstName { get; set; } = null!;

    [Display (Name = "Last Name")]
    public string LastName { get; set; } = null!;

    [NotMapped]
    [Display(Name = "Customer Name")]
    public string FullName => FirstName + " " + LastName;

    public string Email { get; set; } = null!;

    public string MainPhoneNumber { get; set; } = null!;

    public string? SecondaryPhoneNumber { get; set; }

    public int AddressId { get; set; }


    public virtual Addresses Address { get; set; } = null!;

    public virtual ICollection<CustomerOrders> CustomerOrders { get; set; } = new List<CustomerOrders>();

    public virtual ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();


    [NotMapped]
    [Display(Name = "Contact Number")]
    public string ContactNumber
    {
        get
        {
            var contact = "";
            if (!string.IsNullOrWhiteSpace(MainPhoneNumber)) { contact = MainPhoneNumber; }
            if (!string.IsNullOrWhiteSpace(SecondaryPhoneNumber)) { contact = (contact.Length > 0 ? "</br>" : "") + SecondaryPhoneNumber; }
            return contact;
        }
    }
}