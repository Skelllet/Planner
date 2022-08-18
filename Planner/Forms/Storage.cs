using MetroFramework;
using MetroFramework.Forms;
using Planner.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planner.Forms
{
    public partial class StorageForm : MetroForm
    {
        private Db db = new Db();
        private List<Field> fields;
        public StorageForm()
        {
            InitializeComponent();

            this.Text = "Склад";
            FillData();
        }

        private void FillData()
        {
            metroComboBox1.Items.Clear();
            fields = db.GetAllFields();

            for (int i = 0; i < fields.Count; i++)
                metroComboBox1.Items.Add(fields[i].Name);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "")
            {
                MetroMessageBox.Show(this, "Введите логин", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                metroTextBox1.Focus();
            }
            else
            {
                db.AddStorage(new Storage(0, metroTextBox1.Text, fields[metroComboBox1.SelectedIndex]));

                MetroMessageBox.Show(this, "Склад успешно добавлен", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                metroTextBox1.Text = "";
            }
        }


    }
}
