using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Models;

namespace WorkoutTrackerTests.Models
{
    public class WorkoutContext : DbContext
    {
        public DbSet<User> Users { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\chech\\source\\repos\\WorkoutTracker\\WorkoutTracker\\workouts.db");
        }

        public void EnsureDatabaseCreated()
        {
            Database.EnsureCreated();
        }
    }
}