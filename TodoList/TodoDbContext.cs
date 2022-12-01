using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    internal class TodoDbContext : DbContext
    {
        string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Todos1;Trusted_Connection=True;MultipleActiveResultSets=true";

        public DbSet<Task> Tasks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // We tell the app to use the connectionstring
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
        }
    }
}