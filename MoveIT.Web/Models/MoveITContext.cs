
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MoveIT.Web.Models
{
    public class MoveITContext : DbContext
    {
        public MoveITContext(DbContextOptions<MoveITContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Offer> Offers { get; set; } = null!;
    }
}

