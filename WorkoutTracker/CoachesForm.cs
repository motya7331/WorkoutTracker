using System;
using System.Linq;
using System.Windows.Forms;
using WorkoutTracker.Models;

namespace WorkoutTracker
{
    public partial class CoachesForm : Form
    {
        private WorkoutContext db;

        public CoachesForm()
        {
            InitializeComponent();
            db = new WorkoutContext();
            LoadCoaches();
            buttonAdd.Click += buttonAdd_Click;
            buttonSave.Click += buttonSave_Click;
        }

        private void LoadCoaches()
        {
            dataGridViewCoaches.DataSource = db.Coaches
                .Select(c => new
                {
                    c.Id,
                    CoachName = c.Name ?? "Без имени",
                    TraineeName = c.Trainee != null ? c.Trainee.Name ?? "Без имени" : "Нет тренирующегося"
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
            if (!db.Trainees.Any()) db.Trainees.Add(trainee);
            db.SaveChanges();

            var coach = new Coach
            {
                Name = "Новый тренер",
                TraineeId = trainee.Id
            };
            db.Coaches.Add(coach);
            db.SaveChanges();
            LoadCoaches();
        }

        private void buttonSave_Click(object? sender, EventArgs e)
        {
            db.SaveChanges();
            LoadCoaches();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            db.Dispose();
            base.OnFormClosing(e);
        }
    }
}