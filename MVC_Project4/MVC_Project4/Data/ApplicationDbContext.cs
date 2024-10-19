using Microsoft.EntityFrameworkCore;
using MVC_Project4.Models;

namespace MVC_Project4.Data
   
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          :base(options)
        {

        }
            

           public DbSet<movie> Movie_tb { get; set; }
    }
}

