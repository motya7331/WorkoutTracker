﻿namespace WorkoutTracker.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}