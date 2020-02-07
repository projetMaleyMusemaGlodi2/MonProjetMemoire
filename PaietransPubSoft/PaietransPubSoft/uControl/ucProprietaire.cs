using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using PaietransPubSoft.Formulaires;
using DevExpress.XtraEditors;
using PaietransPubSoft.Rapports;
using DevExpress.XtraReports.UI;

namespace PaietransPubSoft.uControl
{
    public partial class ucProprietaire : UserControl
    {
        SplashScreenManager spl;
        int rowHandle;
        int IDPers;
        public ucProprietaire(SplashScreenManager spl)
        {
            InitializeComponent();
            this.spl = spl;
        }

        //id,noms,adresse,contact,mail,typepieceid,numeropieceid,image,username,password,usersession
        public void ChargerGrid()
        {

            try
            {
                gridPersonnel.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetTable("tproprietaire");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void Modifier(int index)
        {
            spl.ShowWaitForm();
            rowHandle = gridView1.FocusedRowHandle;

            if (index == 1)
            {
                object[] data = new object[]
                {
                    gridView1.GetRowCellValue(rowHandle, "id").ToString(),
                    gridView1.GetRowCellValue(rowHandle, "noms").ToString(),
                    gridView1.GetRowCellValue(rowHandle, "adresse").ToString(),
                    gridView1.GetRowCellValue(rowHandle, "contact").ToString(),
                    gridView1.GetRowCellValue(rowHandle, "mail").ToString(),
                    gridView1.GetRowCellValue(rowHandle, "typepieceid").ToString(),
                    gridView1.GetRowCellValue(rowHandle, "numeropieceid").ToString(),
                    gridView1.GetRowCellValue(rowHandle, "image").ToString(),
                    gridView1.GetRowCellValue(rowHandle, "username").ToString(),
                    gridView1.GetRowCellValue(rowHandle, "password").ToString(),
                    gridView1.GetRowCellValue(rowHandle, "usersession").ToString()
                };

                if (index == 1) new fmr_AddProprietaire(spl, this, data).ShowDialog();
            }
            else
            {
                object[] data = new object[]
                {
                    gridView1.GetRowCellValue(rowHandle, "id").ToString(),
                    gridView1.GetRowCellValue(rowHandle, "noms").ToString(),                    
                };
                if (index == 2) new frm_AddEngin(spl, data).ShowDialog();
            }
            
            

        }


        void Supprimer()
        {
            rowHandle = gridView1.FocusedRowHandle;

            IDPers = int.Parse(gridView1.GetRowCellValue(rowHandle, "id").ToString());

            if (MessageBox.Show("Voulez-vous vraiement supprimer cette Information?", "SUPPRESSION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().delete_Parametre("tproprietaire", "id", IDPers);
                XtraMessageBox.Show("Suppression reussie!");
                ChargerGrid();
            }


        }

        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                switch (e.ClickedItem.Name.ToString())
                {
                    case "Modifier":
                        this.Modifier(1);
                        break;
                    case "Supprimer":
                        this.Supprimer();
                        break;
                    case "Engin":
                        this.Modifier(2);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            spl.ShowWaitForm();
            new fmr_AddProprietaire(spl, this).ShowDialog();
        }

        private void ucProprietaire_Load(object sender, EventArgs e)
        {
            try
            {
                ChargerGrid();
                spl.CloseWaitForm();

            }
            catch (Exception ex)
            {
                if (spl.IsSplashFormVisible)
                {
                    spl.CloseWaitForm();
                }
                MessageBox.Show(ex.Message);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Aperçu & Modification").Name = "Modifier";
                menu.Items.Add("Suppression").Name = "Supprimer";
                menu.Items.Add("Ajouter les Engins").Name = "Engin";
                menu.Show(gridPersonnel, new Point(e.X, e.Y));
                menu.ItemClicked += Menu_ItemClicked;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                rpt_ListeProprietaire rpt = new rpt_ListeProprietaire();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaire.GetInstance().get_Report_S("vrapportproprietaire");
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
