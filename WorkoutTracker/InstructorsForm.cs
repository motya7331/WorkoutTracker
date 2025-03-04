using System;
using System.Linq;
using System.Windows.Forms;
using WorkoutTracker.Models;

namespace WorkoutTracker
{
    public partial class InstructorsForm : Form
    {
        private WorkoutContext db;

        public InstructorsForm()
        {
            InitializeComponent();
            db = new WorkoutContext();
            LoadInstructors();
            buttonAdd.Click += buttonAdd_Click;
            buttonSave.Click += buttonSave_Click;
        }

        private void LoadInstructors()
        {
            dataGridViewInstructors.DataSource = db.Instructors
                .Select(i => new { i.Id, InstructorName = i.Name ?? "Без имени" })
                .ToList();
        }

        private void buttonAdd_Click(object? sender, EventArgs e)
        {
            var instructor = new Instructor { Name = "Новый инструктор" };
            db.Instructors.Add(instructor);
            db.SaveChanges();
            LoadInstructors();
        }

        private void buttonSave_Click(object? sender, EventArgs e)
        {
            db.SaveChanges();
            LoadInstructors();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            db.Dispose();
            base.OnFormClosing(e);
        }
    }
}