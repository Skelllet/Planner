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
    public partial class StorageAdmin : MetroForm
    {
        private Field Field;
        private Db Db = new Db();
        private List<Fertilizers> fertilizers;
        private List<Technic> technic;
        private List<Inventory> inventories;

        public StorageAdmin(Field field)
        {
            InitializeComponent();

            Field = field;

            FillTechnic();
            FillFertilizers();
            FillInventory();
        }

        private void FillTechnic()
        {
            metroGrid2.Rows.Clear();
            technic = Db.GetAllTechnics(Field.Id);
            for (int i = 0; i < technic.Count; i++)
            {
                metroGrid2.Rows.Add();
                metroGrid2[0, i].Value = technic[i].Name;
                metroGrid2[1, i].Value = technic[i].Storage.Name;
                metroGrid2[2, i].Value = technic[i].Count;
            }

        }

        private void FillFertilizers()
        {
            metroGrid1.Rows.Clear();
            fertilizers = Db.GetAllFertilizers(Field.Id);
            for (int i = 0; i < fertilizers.Count; i++)
            {
                metroGrid1.Rows.Add();
                metroGrid1[0, i].Value = fertilizers[i].Name;
                metroGrid1[1, i].Value = fertilizers[i].Storage.Name;
                metroGrid1[2, i].Value = fertilizers[i].Count;
            }

        }

        private void FillInventory()
        {
            metroGrid3.Rows.Clear();
            inventories = Db.GetAllInventory(Field.Id);
            for (int i = 0; i < inventories.Count; i++)
            {
                metroGrid3.Rows.Add();
                metroGrid3[0, i].Value = inventories[i].Name;
                metroGrid3[1, i].Value = inventories[i].Storage.Name;
                metroGrid3[2, i].Value = inventories[i].Count;
            }

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            FillDataForm fillDataForm = new FillDataForm(Field);
            fillDataForm.ShowDialog();
            FillTechnic();
            FillFertilizers();
            FillInventory();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < inventories.Count; i++)
                Db.UpdateInventory(new Inventory(inventories[i].Id, inventories[i].Name, Convert.ToInt32(metroGrid3[2, i].Value), inventories[i].Storage));
            for (int k = 0; k < fertilizers.Count; k++)
                Db.UpdateFertilizers(new Fertilizers(fertilizers[k].Id, fertilizers[k].Name, Convert.ToInt32(metroGrid1[2, k].Value), fertilizers[k].Storage));
            for (int j = 0; j < technic.Count; j++)
                Db.UpdateTechnics(new Technic(technic[j].Id, technic[j].Name, Convert.ToInt32(metroGrid2[2, j].Value), technic[j].Storage));
            MetroMessageBox.Show(this, "Данные успешно изменены", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FillTechnic();
            FillFertilizers();
            FillInventory();
        }
    }
}
