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
    public partial class ForWorkers : MetroForm
    {
        private Stadiumworkers Stadiumworkers;
        private List<Job> jobs;
        public ForWorkers(Stadiumworkers stadiumworkers)
        {
            InitializeComponent();
            Stadiumworkers = stadiumworkers;
            this.Text = "Задачи";
            metroGrid1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            metroGrid1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            FillDataGrid();
        }

        private void FillDataGrid()
        {
            metroGrid1.Rows.Clear();
            Db db = new Db();
            jobs = db.GetAllJobsByIdWorkers(Stadiumworkers.Id);

            for (int i = 0; i < jobs.Count; i++)
            {
                metroGrid1.Rows.Add();
                metroGrid1[0, i].Value = jobs[i].Name;
                metroGrid1[1, i].Value = Stadiumworkers.Field.Name;
                metroGrid1[2, i].Value = jobs[i].TimeConstraints;
                metroGrid1[3, i].Value = jobs[i].IsDone;
                if (jobs[i].IsDone)
                    metroGrid1[4, i].Value = jobs[i].TimeIsDone;
            }
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                if (Convert.ToBoolean(metroGrid1[3, e.RowIndex].Value) == false)
                {
                    Db db = new Db();
                    metroGrid1.Rows[e.RowIndex].ReadOnly = true;
                    Job job = jobs[e.RowIndex];
                    db.updateJob(new Job(job.Id, job.Name, true, DateTime.Now, job.TimeConstraints, job.Stadiumworkers));
                    FillDataGrid();
                }
            }
        }

        private void closeProfile_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms[0];
            form.Show();
            this.Close();
        }



        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Authorization form = (Authorization)Application.OpenForms["Authorization"];
                form.Close();
            }
        }
    }
}
