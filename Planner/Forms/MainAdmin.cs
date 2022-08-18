using MetroFramework;
using MetroFramework.Forms;
using Planner.Forms;
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

namespace Planner
{
    public partial class MainAdmin : MetroForm
    {
        private Db myDb = new Db();
        private Field Field = null;
        private List<Admin> admins1 = new List<Admin>();
        public MainAdmin()
        {
            InitializeComponent();
            this.Text = "Главный администратор";

            administrator.Visible = false;
            newStadium.Visible = true;

            FillMetroComboBox1();
        }
        private void FillMetroComboBox1()
        {
            metroComboBox1.Items.Clear();
            List<Admin> admins = myDb.GetAllAdmin();
            List<Field> fields = myDb.GetAllFields();
            for (int i = 0; i < admins.Count; i++)
                if (!fields.Any(Field => Field.Admin.Id == admins[i].Id))
                {
                    metroComboBox1.Items.Add(admins[i].LastName + " " + admins[i].FirstName[0] + ". " + admins[i].MiddleName[0] + ".");
                    admins1.Add(admins[i]);
                }
        }
        private void FillMetroComboBox2()
        {
            metroComboBox2.Items.Clear();
            List<Admin> admins = myDb.GetAllAdmin();
            for (int i = 0; i < admins.Count; i++)
                metroComboBox2.Items.Add(admins[i].LastName + " " + admins[i].FirstName[0] + ". " + admins[i].MiddleName[0] + ".");
        }
        private void addNewAdmin_Click(object sender, EventArgs e)
        {
            if (log_inAdmin.Text == "")
            {
                MetroMessageBox.Show(this, "Введите логин", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                log_inAdmin.Focus();
            }
            else if (pass_wordAdmin.Text == "")
            {
                MetroMessageBox.Show(this, "Введите пароль", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                pass_wordAdmin.Focus();
            }

            else if (last_nameAdmin.Text == "")
            {
                MetroMessageBox.Show(this, "Введите фамилию", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                last_nameAdmin.Focus();
            }
            else if (first_nameAdmin.Text == "")
            {
                MetroMessageBox.Show(this, "Введите имя", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                first_nameAdmin.Focus();
            }
            else if (middle_nameAdmin.Text == "")
            {
                MetroMessageBox.Show(this, "Введите отчество", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                middle_nameAdmin.Focus();
            }
            else if (phone_numberAdmin.Text == "")
            {
                MetroMessageBox.Show(this, "Введите номер телефона", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                phone_numberAdmin.Focus();
            }

            else
            {
                if (myDb.GetAllAdmin().FindIndex(Admin => Admin.Login == log_inAdmin.Text) != -1)
                {
                    MetroMessageBox.Show(this, "Данный логин уже занят", "Введите новый логин", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    log_inAdmin.Focus();
                }
                else
                {

                    // создать worker. добавить в бд + логин и пароль
                    Admin admins = new Admin(0, last_nameAdmin.Text, first_nameAdmin.Text, middle_nameAdmin.Text, phone_numberAdmin.Text, log_inAdmin.Text, pass_wordAdmin.Text);
                    myDb.AddAdmin(admins);

                    MetroMessageBox.Show(this, "Администратор успешно добавлен", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearAdmin();
                    FillMetroComboBox1();
                }
            }
        }

        private void ClearAdmin()
        {
            log_inAdmin.Text = "";
            pass_wordAdmin.Text = "";
            last_nameAdmin.Text = "";
            first_nameAdmin.Text = "";
            middle_nameAdmin.Text = "";
            phone_numberAdmin.Text = "";
        }
        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Authorization form = (Authorization)Application.OpenForms["Authorization"];
                form.Close();
            }
        }

        private void addNewStadium_Click(object sender, EventArgs e)
        {
            if (newStadium.Visible)
            {
                administrator.Visible = false;
                if (stadiumName.Text == "")
                {
                    MetroMessageBox.Show(this, "Введите название стадиона", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    stadiumName.Focus();
                }
                else if (metroTextBox2.Text == "")
                {
                    MetroMessageBox.Show(this, "Введите адрес стадиона", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    metroTextBox2.Focus();
                }
                else if (metroTextBox6.Text == "")
                {
                    MetroMessageBox.Show(this, "Введите время работы стадиона", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    metroTextBox6.Focus();
                }
                else if (metroComboBox1.SelectedIndex == -1)
                {
                    MetroMessageBox.Show(this, "Выберите администратора", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    metroComboBox1.Focus();
                }
                else
                {
                    Field field = new Field(0, stadiumName.Text, DateTime.Parse(metroTextBox6.Text), DateTime.Parse(metroTextBox3.Text),
                        metroTextBox2.Text, admins1[metroComboBox1.SelectedIndex]);

                    myDb.AddField(field);
                    MetroMessageBox.Show(this, "Стадион успешно добавлен", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearStadion();
                    FillAllStadium();
                }
            }
            else
            {
                administrator.Visible = false;
                newStadium.Visible = true;
                FillMetroComboBox1();
            }
        }

        private void ClearStadion()
        {
            stadiumName.Text = "";
            metroTextBox2.Text = "";
            metroTextBox6.Text = "";
            metroComboBox1.SelectedIndex = -1;
            metroComboBox1.Text = "";
            metroTextBox3.Text = "";
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (administrator.Visible)
            {
                newStadium.Visible = false;
                if (allStadium.SelectedIndex == -1)
                {
                    MetroMessageBox.Show(this, "Выберите стадион", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    allStadium.Focus();
                }
                else
                {
                    if (metroTextBox5.Text == "")
                    {
                        MetroMessageBox.Show(this, "Введите адрес стадиона", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        metroTextBox5.Focus();
                    }
                    else if (metroTextBox4.Text == "")
                    {
                        MetroMessageBox.Show(this, "Введите время работы стадиона", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        metroTextBox4.Focus();
                    }
                    else if (metroTextBox1.Text == "")
                    {
                        MetroMessageBox.Show(this, "Введите конец времени работы стадиона", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        metroTextBox4.Focus();
                    }
                    else if (metroComboBox2.SelectedIndex == -1)
                    {
                        MetroMessageBox.Show(this, "Выберите администратора", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        metroComboBox2.Focus();
                    }
                    else
                    {
                        myDb.UpdateField(new Field(Field.Id, allStadium.Text, DateTime.Parse(metroTextBox4.Text), DateTime.Parse(metroTextBox1.Text),
                            metroTextBox5.Text, myDb.GetAllAdmin()[metroComboBox2.SelectedIndex]));

                        MetroMessageBox.Show(this, "Данные успешно обновлены", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        metroTextBox5.Text = "";
                        metroTextBox4.Text = "";
                        metroTextBox2.Text = "";
                        allStadium.SelectedIndex = -1;
                        allStadium.Text = "";
                        metroTextBox1.Text = "";
                    }
                }
            }
            else
            {
                administrator.Visible = true;
                newStadium.Visible = false;
                FillAllStadium();
            }
        }

        private void FillAllStadium()
        {
            allStadium.Items.Clear();
            List<Field> fields = myDb.GetAllFields();
            for (int i = 0; i < fields.Count; i++)
                allStadium.Items.Add(fields[i].Name);
        }

        private void allStadium_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allStadium.SelectedIndex != -1)
            {
                Field = myDb.GetAllFields()[allStadium.SelectedIndex];

                metroTextBox5.Text = Field.StadiumAdress;
                metroTextBox4.Text = Field.WorkingHoursTimeStart.TimeOfDay.ToString();
                metroTextBox1.Text = Field.WorkingHoursTimeFinish.TimeOfDay.ToString();
                FillMetroComboBox2();
                metroComboBox2.SelectedIndex = metroComboBox2.Items.IndexOf(Field.Admin.LastName + " " + Field.Admin.FirstName[0] + ". " + Field.Admin.MiddleName[0] + ".");
            }
        }

        private void phone_numberAdmin_Enter(object sender, EventArgs e)
        {

            phone_numberAdmin.SelectionStart = 0;
            phone_numberAdmin.SelectionLength = phone_numberAdmin.Text.Length;

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Forms.StorageForm storage = new Forms.StorageForm();
            storage.ShowDialog();
        }
    }

}
