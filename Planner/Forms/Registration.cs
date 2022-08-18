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
    public partial class Registration : MetroForm
    {
        private Db myDb = new Db();
        public Registration()
        {
            InitializeComponent();

            metroComboBox2.Items.Clear();

            // Должность 
            List<Post> post = myDb.GetAllPositions();
            for (int i = 0; i < post.Count; i++)
            {
                metroComboBox2.Items.Add(post[i].Name);
            }

            // Стадионы
            List<Field> fields = myDb.GetAllFields();
            for (int j = 0; j < fields.Count; j++)
                metroComboBox1.Items.Add(fields[j].Name);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (log_in.Text == "")
            {
                MetroMessageBox.Show(this, "Введите логин", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                log_in.Focus();
            }
            else if (pass_word.Text == "")
            {
                MetroMessageBox.Show(this, "Введите пароль", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                pass_word.Focus();
            }
            else if (metroComboBox2.Text == "")
            {
                MetroMessageBox.Show(this, "Выберете роль", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                metroComboBox2.Focus();
            }
            else if (last_name.Text == "")
            {
                MetroMessageBox.Show(this, "Введите фамилию", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                last_name.Focus();
            }
            else if (first_name.Text == "")
            {
                MetroMessageBox.Show(this, "Введите имя", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                first_name.Focus();
            }
            else if (middle_name.Text == "")
            {
                MetroMessageBox.Show(this, "Введите отчество", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                middle_name.Focus();
            }
            else if (phone_number.Text == "")
            {
                MetroMessageBox.Show(this, "Введите номер телефона", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                phone_number.Focus();
            }
            else if (metroComboBox1.SelectedIndex == -1)
            {
                MetroMessageBox.Show(this, "Выберите стадион", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                metroComboBox1.Focus();
            }
            else
            {
                if (myDb.GetAllAdmin().FindIndex(Admin => Admin.Login == log_in.Text) != -1 && (myDb.GetAllStadiumworkers().FindIndex(Stadiumworkers => Stadiumworkers.Login == log_in.Text) != -1))
                {
                    MetroMessageBox.Show(this, "Данный логин уже занят", "Введите новый логин", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    log_in.Focus();
                }
                else
                {
                    int idPosition = myDb.GetAllPositions()
                        [myDb.GetAllPositions().FindIndex(Position => Position.Name == metroComboBox2.Text)].Id;
                    // создать worker. добавить в бд + логин и пароль
                    Stadiumworkers stadiumworkers = new Stadiumworkers(0, last_name.Text, first_name.Text, middle_name.Text, phone_number.Text, log_in.Text, pass_word.Text,
                        myDb.GetPositionById(idPosition), myDb.GetAllFields()[metroComboBox1.SelectedIndex]);
                    myDb.AddWorker(stadiumworkers);

                    MetroMessageBox.Show(this, "Пользователь зарегистрирован", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.OpenForms["Authorization"].Show();
                    this.Close();
                }
            }
        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Authorization form = (Authorization)Application.OpenForms["Authorization"];
                FormAdmin ad_min = (FormAdmin)Application.OpenForms["FormAdmin"];
                ForWorkers worker_form = (ForWorkers)Application.OpenForms["ForWorkers"];
                if (ad_min != null)
                {
                    if (!form.Visible && !ad_min.Visible)
                        form.Close();
                }
                else if (worker_form != null)
                    if (!form.Visible && !worker_form.Visible)
                        form.Close();
            }
        }

        private void Ba_ck_Click_1(object sender, EventArgs e)
        {
            Form form = Application.OpenForms[0];
            form.Show();
            this.Close();
        }

        private void phone_number_Enter(object sender, EventArgs e)
        {
            phone_number.SelectionStart = 0;
            phone_number.SelectionLength = phone_number.Text.Length;
        }
    }
}

