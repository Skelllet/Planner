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
    public partial class SeeTasks : MetroForm
    {
        private Db db = new Db();
        private int Id;
        private List<Stadiumworkers> stadiumworkers;
        private List<Field> fields;
        public SeeTasks(int id)
        {
            InitializeComponent();
            this.Text = "Просмотр задач";

            Id = id;

            FillTable();
        }

        private void FillTable()
        {
            List<Job> jobs = db.GetAllJobsByIdFields(Id);
            stadiumworkers = db.GetAllStadiumworkersByIdField(Id);


            metroGrid1.Rows.Clear();
            for (int i = 0; i < jobs.Count; i++)
            {
                metroGrid1.Rows.Add();
                metroGrid1[0, i].Value = jobs[i].Name;
                metroGrid1[1, i].Value = (jobs[i].Stadiumworkers.FirstName + " " + jobs[i].Stadiumworkers.LastName[0] + ". " + jobs[i].Stadiumworkers.MiddleName[0] + ".");
                metroGrid1[2, i].Value = jobs[i].TimeConstraints;
                metroGrid1[3, i].Value = jobs[i].IsDone;
                if (jobs[i].IsDone)
                    metroGrid1[4, i].Value = jobs[i].TimeIsDone;

            }
        }
    }
}
