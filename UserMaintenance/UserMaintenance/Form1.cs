using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();

            btnAdd.Text = Resource1.Add;
            lblFullName.Text = Resource1.FullName;
            btnWrite.Text = Resource1.Write;
            btnDelete.Text = Resource1.Delete;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtFullName.Text
            };
            users.Add(u);
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, true))
                {
                    foreach (var x in users)
                    {
                        sw.WriteLine(string.Format("{0};{1}", x.ID, x.FullName));
                    }
                }

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listUsers.SelectedItem == null) return;
            var torles = (User)listUsers.SelectedItem;
            users.Remove(torles);
            
        }
    }
}
