using System;
using System.Linq;
using System.Windows.Forms;
using WorkoutTracker.Models;

namespace WorkoutTracker
{
    public partial class GroupsForm : Form
    {
        private WorkoutContext db;

        public GroupsForm()
        {
            InitializeComponent();
            db = new WorkoutContext();
            LoadGroups();
            buttonAdd.Click += buttonAdd_Click;
            buttonSave.Click += buttonSave_Click;
        }

        private void LoadGroups()
        {
            dataGridViewGroups.DataSource = db.Groups
                .Select(g => new { g.Id, GroupName = g.Name ?? "Без имени" })
                .ToList();
        }

        private void buttonAdd_Click(object? sender, EventArgs e)
        {
            var group = new Group { Name = "Новая группа" };
            db.Groups.Add(group);
            db.SaveChanges();
            LoadGroups();
        }

        private void buttonSave_Click(object? sender, EventArgs e)
        {
            db.SaveChanges();
            LoadGroups();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            db.Dispose();
            base.OnFormClosing(e);
        }
    }
}