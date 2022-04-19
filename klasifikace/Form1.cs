using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace klasifikace
{
    public partial class Form1 : Form
    {
       
        List<Student> students;
        SQLRepository sQLRepository = new SQLRepository();

        public Form1()
        {
            InitializeComponent();
            students = sQLRepository.GetStudents();
            RefreshGUI();
        }

        private void RefreshGUI()
        {
            lvData.Items.Clear();
            foreach (Student student in students)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { 
                    student.lastname + " " + student.firstname,
                    student.birthday.ToString("dd.MM.yyyy")
                });
                lvData.Items.Add(listViewItem);
            }
        }
    }
}
