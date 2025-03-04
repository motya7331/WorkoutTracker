using System;
using System.Linq;
using System.Windows.Forms;
using WorkoutTracker.Models;

namespace WorkoutTracker
{
    public partial class ExercisesForm : Form
    {
        private WorkoutContext db;

        public ExercisesForm()
        {
            InitializeComponent();
            db = new WorkoutContext();
            LoadExercises();
            buttonAdd.Click += buttonAdd_Click;
            buttonSave.Click += buttonSave_Click;
        }

        private void LoadExercises()
        {
            dataGridViewExercises.DataSource = db.Exercises
                .Select(e => new { e.Id, ExerciseName = e.Name ?? "Без имени" })
                .ToList();
        }

        private void buttonAdd_Click(object? sender, EventArgs e)
        {
            var exercise = new Exercise { Name = "Новое упражнение" };
            db.Exercises.Add(exercise);
            db.SaveChanges();
            LoadExercises();
        }

        private void buttonSave_Click(object? sender, EventArgs e)
        {
            db.SaveChanges();
            LoadExercises();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            db.Dispose();
            base.OnFormClosing(e);
        }
    }
}