using first_proj.Models;
using Microsoft.EntityFrameworkCore;

namespace first_proj.Data
{
    public class appdbcontext :DbContext
    { 
        public appdbcontext(DbContextOptions <appdbcontext> options) : base(options) 
        {

        }
        public DbSet<item> items { get; set; }
    }


}
