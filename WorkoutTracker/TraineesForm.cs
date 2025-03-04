using System;
using System.Linq;
using System.Windows.Forms;
using WorkoutTracker.Models;

namespace WorkoutTracker
{
    public partial class TraineesForm : Form
    {
        private WorkoutContext db;

        public TraineesForm()
        {
            InitializeComponent();
            db = new WorkoutContext();
            LoadTrainees();
            buttonAdd.Click += buttonAdd_Click;
            buttonSave.Click += buttonSave_Click;
        }

        private void LoadTrainees()
        {
            dataGridViewTrainees.DataSource = db.Trainees
                .Select(t => new
                {
                    t.Id,
                    TraineeName = t.Name ?? "Без имени",
                    GroupName = t.Group != null ? t.Group.Name ?? "Без имени" : "Нет группы"
                })
                .ToList();
        }

        private void buttonAdd_Click(object? sender, EventArgs e)
        {
            var group = db.Groups.FirstOrDefault() ?? new Group { Name = "Группа Начальная" };
            if (!db.Groups.Any()) db.Groups.Add(group);
            db.SaveChanges();

            var trainee = new Trainee { Name = "Новый тренирующийся", GroupId = group.Id };
            db.Trainees.Add(trainee);
            db.SaveChanges();
            LoadTrainees();
        }

        private void buttonSave_Click(object? sender, EventArgs e)
        {
            db.SaveChanges();
            LoadTrainees();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            db.Dispose();
            base.OnFormClosing(e);
        }
    }
}