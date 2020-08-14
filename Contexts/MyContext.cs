using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Contexts
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}
        public DbSet<Dishes> Dish {get;set;}
    }
}