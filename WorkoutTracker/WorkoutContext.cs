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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\chech\\source\\repos\\WorkoutTracker\\WorkoutTracker\\workouts.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instructor>()
                .HasMany(i => i.Groups)
                .WithMany(g => g.Instructors);
        }
    }
}