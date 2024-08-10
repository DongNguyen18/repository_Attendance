using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseAttendanceASM2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

  

        private void studentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student student = new Student();

            student.ShowDialog();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();

            registration.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher();

            teacher.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Attendance attendance = new Attendance();

            attendance.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Show Show = new Show();

            Show.ShowDialog();
        }
    }
}
