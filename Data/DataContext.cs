using dot_net.Models;
using Microsoft.EntityFrameworkCore;

namespace dot_net.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
        public DbSet<Character> Characters {get;set;}
        public DbSet<User> Users {get;set;}
    }
}