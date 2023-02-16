using KainatTarar.Challange.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KainatTarar.Challange.Data.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-7JKJPBC; Initial Catalog=ChallangeDB; Integrated Security=True");
        }

        public DbSet<User> Users { get; set; }
    }
}
