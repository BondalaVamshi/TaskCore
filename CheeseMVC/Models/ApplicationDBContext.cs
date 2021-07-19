//using CheeseMVC.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }
        public DbSet<Cheese> Cheese { get; set; }
        public DbSet<CheeseCategory> CheeseCategory { get; set; }
       // public DbSet<CheeseViewModel> cheeseViewModels { get; set; }
    }
}
