using System;
using System.Linq;
using System.Windows.Forms;
using WorkoutTracker.Models;

namespace WorkoutTracker
{
    public partial class DailyRecordsForm : Form
    {
        private WorkoutContext db;

        public DailyRecordsForm()
        {
            InitializeComponent();
            db = new WorkoutContext();
            LoadDailyRecords();
            buttonAdd.Click += buttonAdd_Click;
            buttonSave.Click += buttonSave_Click;
        }

        private void LoadDailyRecords()
        {
            dataGridViewDailyRecords.DataSource = db.DailyRecords
                .Select(d => new
                {
                    d.Id,
                    TraineeName = d.Trainee != null ? d.Trainee.Name ?? "Без имени" : "Нет тренирующегося",
                    ExerciseName = d.Exercise != null ? d.Exercise.Name ?? "Без имени" : "Нет упражнения",
                    d.Reps,
                    d.Date,
                    d.Notes
                })
                .ToList();
        }

        private void buttonAdd_Click(object? sender, EventArgs e)
        {
            var trainee = db.Trainees.FirstOrDefault() ?? new Trainee
            {
                Name = "Иван Сидоров",
                GroupId = db.Groups.FirstOrDefault()?.Id ?? 1
            };
            var exercise = db.Exercises.FirstOrDefault() ?? new Exercise { Name = "Отжимания" };
            if (!db.Trainees.Any()) db.Trainees.Add(trainee);
            if (!db.Exercises.Any()) db.Exercises.Add(exercise);
            db.SaveChanges();

            var daily = new DailyRecord
            {
                TraineeId = trainee.Id,
                ExerciseId = exercise.Id,
                Reps = 15,
                Date = DateTime.Now,
                Notes = "Нормально"
            };
            db.DailyRecords.Add(daily);
            db.SaveChanges();
            LoadDailyRecords();
        }

        private void buttonSave_Click(object? sender, EventArgs e)
        {
            db.SaveChanges();
            LoadDailyRecords();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            db.Dispose();
            base.OnFormClosing(e);
        }
    }
}