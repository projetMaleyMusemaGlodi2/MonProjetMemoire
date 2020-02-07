using PaietransPubSoft.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaietransPubSoft.Formulaires
{
    public partial class frm_SearchPersonne : Form
    {
        public frm_SearchPersonne()
        {
            InitializeComponent();
        }

        public void ChargerGrid()
        {
            try
            {
                gridControl1.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetTable(clsGetInfoPersonne.GetInstance().NomTable);
                //gridControl1.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetTable("vSeachChauffeur");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {

                if (gridView1.RowCount < 1)
                {
                }
                else
                {
                    clsGetInfoPersonne.GetInstance().Id = int.Parse(gridView1.GetFocusedRowCellValue(gridView1.Columns["id"]).ToString());
                    clsGetInfoPersonne.GetInstance().Nom = gridView1.GetFocusedRowCellValue(gridView1.Columns["noms"]).ToString();                   
                    this.Close();

                }

            }
            catch (Exception)
            { }
        }

        private void frm_SearchPersonne_Load(object sender, EventArgs e)
        {
            ChargerGrid();
        }
    }
}
