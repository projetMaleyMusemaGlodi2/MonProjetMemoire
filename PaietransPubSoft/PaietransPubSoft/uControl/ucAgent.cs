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
using DevExpress.XtraEditors;
using PaietransPubSoft.Formulaires;

namespace PaietransPubSoft.uControl
{
    public partial class ucAgent : UserControl
    {
        SplashScreenManager spl;
        int rowHandle;
        int IDPers;
        public ucAgent(SplashScreenManager spl)
        {
            InitializeComponent();
            this.spl = spl;
        }

        public void ChargerGrid()
        {

            try
            {
                gridPersonnel.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetTable("tagent");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //SELECT id, noms, adresse, contact, mail, sexe, datenaissance, lieunaissance, etatcivil, niveauetude, fonction, image, username FROM `tagent` WHERE 1
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
                gridView1.GetRowCellValue(rowHandle, "sexe").ToString(),
                gridView1.GetRowCellValue(rowHandle, "datenaissance").ToString(),
                gridView1.GetRowCellValue(rowHandle, "lieunaissance").ToString(),
                gridView1.GetRowCellValue(rowHandle, "etatcivil").ToString(),
                gridView1.GetRowCellValue(rowHandle, "niveauetude").ToString(),
                gridView1.GetRowCellValue(rowHandle, "fonction").ToString(),
                gridView1.GetRowCellValue(rowHandle, "image"),
                gridView1.GetRowCellValue(rowHandle, "qrCode"),
                gridView1.GetRowCellValue(rowHandle, "username").ToString(),
                gridView1.GetRowCellValue(rowHandle, "password").ToString(),
                gridView1.GetRowCellValue(rowHandle, "usersession").ToString()                
            };

            if (index == 1) new frm_AddAgent(spl, this, data).ShowDialog();            
        }


        void Supprimer()
        {
            rowHandle = gridView1.FocusedRowHandle;

            IDPers = int.Parse(gridView1.GetRowCellValue(rowHandle, "id").ToString());

            if (MessageBox.Show("Voulez-vous vraiement supprimer cette Information?", "SUPPRESSION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().delete_Parametre("tagent", "id", IDPers);
                XtraMessageBox.Show("Suppression reussie!");
                ChargerGrid();
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
                    //case "Paiement":
                    //    this.Modifier(2);
                    //    break;
                    //case "Recharge":
                    //    this.Modifier(3);
                    //    break;
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
            new frm_AddAgent(spl, this).ShowDialog();
        }

        private void ucAgent_Load(object sender, EventArgs e)
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
                //menu.Items.Add("Paiement Transport").Name = "Paiement";
                //menu.Items.Add("Recharge du Compte").Name = "Recharge";
                menu.Show(gridPersonnel, new Point(e.X, e.Y));
                menu.ItemClicked += Menu_ItemClicked;
            }
        }
    }
}
