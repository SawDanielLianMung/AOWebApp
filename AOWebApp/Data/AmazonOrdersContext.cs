using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AOWebApp.Models;

namespace AOWebApp.Data;

public partial class AmazonOrdersContext : DbContext
{
    internal IEnumerable<object> Addresses;

    public AmazonOrdersContext()
    {
    }

    public AmazonOrdersContext(DbContextOptions<AmazonOrdersContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Data Source=DESKTOP-L1HQUDJ\SQLEXPRESS;Initial Catalog=AmazonOrders;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<AOWebApp.Models.Items> Items { get; set; } = default!;
    public IEnumerable<object> ItemCategories { get; internal set; }

public DbSet<AOWebApp.Models.Customers> Customers { get; set; } = default!;
}
