using Microsoft.EntityFrameworkCore;

namespace WorkoutTracker.Models
{
    public class WorkoutContext : DbContext
    {
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutSchedule> WorkoutSchedules { get; set; }
        public DbSet<ChallengeSchedule> ChallengeSchedules { get; set; }
        public DbSet<DailyRecord> DailyRecords { get; set; }
        public DbSet<ChallengeRecord> ChallengeRecords { get; set; }
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
