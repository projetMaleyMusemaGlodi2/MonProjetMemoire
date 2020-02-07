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
using PaietransPubSoft.Classes;
using PaietransPubSoft.Rapports;
using DevExpress.XtraReports.UI;

namespace PaietransPubSoft.uControl
{
    public partial class ucPassager : UserControl
    {
        SplashScreenManager spl;
        int rowHandle;
        int IDPers;        
        public ucPassager(SplashScreenManager spl)
        {
            InitializeComponent();
            this.spl = spl;
        }
        //id,noms,adresse,contact,mail,typepieceid,numeropieceid,image,username,password,usersession
        public void ChargerGrid()
        {

            try
            {
                gridPersonnel.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetTable("tclient");
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
                gridView1.GetRowCellValue(rowHandle, "usersession").ToString(),
                gridView1.GetRowCellValue(rowHandle, "qrCode")

            };

            if (index == 1) new frm_AddPasser(spl, this, data).ShowDialog();
            else if (index == 2) new frm_AddPaiement(spl, data).ShowDialog();
            else if (index == 3) new frm_AddChargeCompteClient(spl, data).ShowDialog();
        }


        void Supprimer()
        {
            rowHandle = gridView1.FocusedRowHandle;

            IDPers = int.Parse(gridView1.GetRowCellValue(rowHandle, "id").ToString());

            if (MessageBox.Show("Voulez-vous vraiement supprimer cette Information?", "SUPPRESSION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().delete_Parametre("tclient", "id", IDPers);
                XtraMessageBox.Show("Suppression reussie!");
                ChargerGrid();
            }


        }
        void ImprimerCarte()
        {

            int rowHandle = gridView1.FocusedRowHandle;
            String id = gridView1.GetRowCellValue(rowHandle, "id").ToString();
            String noms = gridView1.GetRowCellValue(rowHandle, "noms").ToString();

            try
            {
                rpt_Carteclient rpt = new rpt_Carteclient();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().get_Report_X("vrapportclient", "id", id);
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

        //Recharge
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
                    case "info":
                        ImprimerCarte();
                        break;
                    case "Paiement":
                        this.Modifier(2);
                        break;
                    case "Recharge":
                        this.Modifier(3);
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
            new frm_AddPasser(spl, this).ShowDialog();
        }

        private void ucPassager_Load(object sender, EventArgs e)
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
                menu.Items.Add("Imprimer Carte").Name = "info";
                menu.Items.Add("Paiement Transport").Name = "Paiement";
                menu.Items.Add("Recharge du Compte").Name = "Recharge";
                menu.Show(gridPersonnel, new Point(e.X, e.Y));
                menu.ItemClicked += Menu_ItemClicked;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                rpt_ListeClient rpt = new rpt_ListeClient();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaire.GetInstance().get_Report_S("vrapportclient");
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
