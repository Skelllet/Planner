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
    public partial class FormAdmin : MetroForm
    {
        private Db db = new Db();
        private List<Field> fields;
        private List<Stadiumworkers> stadiumworkers;
        private Field Field;
        private Admin Admin;
        public FormAdmin(Admin admin)
        {
            InitializeComponent();
            this.Text = "Администратор";

            Admin = admin;
            Field = db.GetFieldByIdAdmin(Admin.Id);

            FillField();
        }

        private void FillField()
        {
            FieldName.Items.Clear();
            fields = db.GetAllFields();
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i].Admin.Id == Admin.Id)
                    FieldName.Items.Add(fields[i].Name);
            }
        }
        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Authorization form = (Authorization)Application.OpenForms["Authorization"];
                form.Close();
            }
        }

        private void seeTasks_Click(object sender, EventArgs e)
        {
            if (Field != null)
            {
                SeeTasks seeTasks = new SeeTasks(Field.Id);
                seeTasks.ShowDialog();
            }
            else MetroMessageBox.Show(this, "Задач не найдено", "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }


        private void FieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            stadiumworkers = db.GetAllStadiumworkersByIdField(db.GetFieldByIdAdmin(Admin.Id).Id);
            FIOWorker.Items.Clear();
            for (int i = 0; i < stadiumworkers.Count; i++)
                FIOWorker.Items.Add(stadiumworkers[i].LastName + " " + stadiumworkers[i].FirstName[0] + ". " + stadiumworkers[i].MiddleName[0] + ".");
        }

        private void AddTask_Click(object sender, EventArgs e)
        {
            if (TextDescription.Text == "")
            {
                MetroMessageBox.Show(this, "Введите описание задачи", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                TextDescription.Focus();
            }
            else if (FieldName.SelectedIndex == -1)
            {
                MetroMessageBox.Show(this, "Выберите стадион", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                FieldName.Focus();
            }
            else if (FIOWorker.SelectedIndex == -1)
            {
                MetroMessageBox.Show(this, "Выберите работника", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                FIOWorker.Focus();
            }
            else
            {
                db.AddJob(new Job(0, TextDescription.Text, false,
                    new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0),
                    new DateTime(dateTimePicker1.Value.Date.Year, dateTimePicker1.Value.Date.Month, dateTimePicker1.Value.Date.Day,
                    dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute, dateTimePicker2.Value.Second),
                    stadiumworkers[FIOWorker.SelectedIndex]));

                MetroMessageBox.Show(this, "Задача добавлена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            StorageAdmin storage = new StorageAdmin(Field);
            storage.ShowDialog();
        }
    }
}
