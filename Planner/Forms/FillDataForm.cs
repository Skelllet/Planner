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
    public partial class FillDataForm : MetroForm
    {
        private Db db = new Db();
        private Field Field;
        private List<Storage> storages;
        public FillDataForm(Field field)
        {
            InitializeComponent();
            this.Text = "Склад стадиона";
            Field = field;
            FillField(metroComboBox1);
            FillField(metroComboBox2);
            FillField(metroComboBox3);
        }

        private void FillField(MetroFramework.Controls.MetroComboBox comboBox)
        {
            comboBox.Items.Clear();
            storages = db.GetAllStorageByIdField(Field.Id);
            for (int i = 0; i < storages.Count; i++)
                comboBox.Items.Add(storages[i].Name);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "")
            {
                MetroMessageBox.Show(this, "Введите название удобрения", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                metroTextBox1.Focus();
            }
            else if (metroTextBox6.Text == "")
            {
                MetroMessageBox.Show(this, "Введите количество удобрения", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                metroTextBox6.Focus();
            }
            else if (metroComboBox1.SelectedIndex == -1)
            {
                MetroMessageBox.Show(this, "Выберите склад", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                metroComboBox1.Focus();
            }
            else
            {
                db.AddFertilizers(new Fertilizers(0, metroTextBox1.Text, Convert.ToInt32(metroTextBox6.Text), storages[metroComboBox1.SelectedIndex]));

                MetroMessageBox.Show(this, "Удобрение успешно добавлено", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox2.Text == "")
            {
                MetroMessageBox.Show(this, "Введите название инвертаря", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                metroTextBox2.Focus();
            }
            else if (metroTextBox5.Text == "")
            {
                MetroMessageBox.Show(this, "Введите количество инвертаря", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                metroTextBox5.Focus();
            }
            else if (metroComboBox2.SelectedIndex == -1)
            {
                MetroMessageBox.Show(this, "Выберите склад", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                metroTextBox2.Focus();
            }
            else
            {
                db.AddAllInventory(new Inventory(0, metroTextBox2.Text, Convert.ToInt32(metroTextBox5.Text), storages[metroComboBox2.SelectedIndex]));

                MetroMessageBox.Show(this, "Инвентарь успешно добавлено", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (metroTextBox3.Text == "")
            {
                MetroMessageBox.Show(this, "Введите название техники", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                metroTextBox3.Focus();
            }
            else if (metroTextBox4.Text == "")
            {
                MetroMessageBox.Show(this, "Введите количество техники", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                metroTextBox4.Focus();
            }
            else if (metroComboBox3.SelectedIndex == -1)
            {
                MetroMessageBox.Show(this, "Выберите склад", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                metroTextBox3.Focus();
            }
            else
            {
                db.AddTechnics(new Technic(0, metroTextBox3.Text, Convert.ToInt32(metroTextBox4.Text), storages[metroComboBox3.SelectedIndex]));

                MetroMessageBox.Show(this, "Техника успешно добавлено", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }


    }
}
