using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace WebApplication1.Models
{
    public class AaladinContext:DbContext
    {
        public AaladinContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Questionary> Questionaries { get; set; }
        public DbSet<HomeStay> HomeStays { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<HomeStay>()
        //        .HasKey(e => e.Id);

        //    modelBuilder.Entity<HomeStay>()
        //        .Property(e => e.Pics)
        //        .HasColumnType("varbinary(MAX)");
        //}
    }
}
