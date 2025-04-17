using System;
using System.Linq;
using System.Windows.Forms;
using WorkoutTrackerTests.Models;

namespace WorkoutTrackerTests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            using (var db = new WorkoutContext())
            {
                var user = db.Users
                    .FirstOrDefault(u => u.Username == textBoxUsername.Text && u.Password == textBoxPassword.Text);
                labelResult.Text = user != null ? "Успешный вход" : "Ошибка входа";
            }
        }
    }
}