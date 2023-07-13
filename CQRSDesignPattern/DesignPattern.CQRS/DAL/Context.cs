using DesignPattern.CQRS.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.CQRS.DAL
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;initial catalog=DesignPatternCQRS;integrated security=true;");
        }

        public DbSet<Product> Products { get; set; }
    }
}
