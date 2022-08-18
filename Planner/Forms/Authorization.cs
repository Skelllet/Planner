using MetroFramework;
using MetroFramework.Forms;
using Planner.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planner
{
    public partial class Authorization : MetroForm
    {
        private Db myDb = new Db();
        public Authorization()
        {
            InitializeComponent();
            this.SetTopLevel(true);
        }





        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "")
            {
                MetroMessageBox.Show(this, "Введите логин", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                metroTextBox1.Focus();
            }
            else if (metroTextBox2.Text == "")
            {
                MetroMessageBox.Show(this, "Введите пароль", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                metroTextBox2.Focus();
            }
            else
            {
                if (myDb.GetAllAdmin().Any(Admin => Admin.Login == metroTextBox1.Text
                && Admin.Password == metroTextBox2.Text))
                {
                    // Находим id записи
                    int idUser = myDb.GetAllAdmin()
                        [myDb.GetAllAdmin().FindIndex(Admin => Admin.Login == metroTextBox1.Text)].Id;


                    FormAdmin admin = new FormAdmin(myDb.GetAllAdmin()
                        [myDb.GetAllAdmin().FindIndex(Admin => Admin.Login == metroTextBox1.Text)]);
                    admin.Show();
                    this.Hide();

                }
                else if (myDb.GetAllStadiumworkers().Any(Stadiumworkers => Stadiumworkers.Login == metroTextBox1.Text
                && Stadiumworkers.Password == metroTextBox2.Text))
                {
                    // Находим id записи
                    int idUser = myDb.GetAllStadiumworkers()
                        [myDb.GetAllStadiumworkers().FindIndex(Stadiumworkers => Stadiumworkers.Login == metroTextBox1.Text)].Id;
                    // Определяем кто это

                    ForWorkers worker = new ForWorkers(myDb.GetAllStadiumworkers()
                        [myDb.GetAllStadiumworkers().FindIndex(Stadiumworkers => Stadiumworkers.Login == metroTextBox1.Text)]);
                    worker.Show();
                    this.Hide();

                }
                else if ("1" == metroTextBox1.Text && "1" == metroTextBox2.Text)
                {
                    MainAdmin samiyglavniy = new MainAdmin();
                    samiyglavniy.Show();
                    this.Hide();
                }
                else
                {
                    MetroMessageBox.Show(this, "Проверьте введенные данные", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    metroTextBox1.Focus();
                }
            }
        }

        private void reg_istartion_Click(object sender, EventArgs e)
        {
            Registration form = new Registration();
            form.Show();
            this.Hide();
        }

        private void metroTextBox2_Enter(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(metroTextBox2.Text))
            {
                metroTextBox2.SelectionStart = 0;
                metroTextBox2.SelectionLength = metroTextBox2.Text.Length;
            }
        }
    }
}
