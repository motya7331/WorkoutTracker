﻿namespace WorkoutTracker.Models
{
    public class DailyRecord
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public Trainee? Trainee { get; set; }
        public int ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
        public int Reps { get; set; }
        public DateTime Date { get; set; }
        public string? Notes { get; set; }
    }
}