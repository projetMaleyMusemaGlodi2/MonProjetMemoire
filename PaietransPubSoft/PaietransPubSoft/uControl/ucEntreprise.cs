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
using PaietransPubSoft.Classes;

namespace PaietransPubSoft.uControl
{
    public partial class ucEntreprise : UserControl
    {
        //SplashScreenManager spl;
        int rowHandle;
        int IDHopital = -1;
        public ucEntreprise()
        {
            InitializeComponent();            
        }

        public void ChargerGrid()
        {

            try
            {
                gridControl1.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetTable("tEntreprise");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void RefreshHopital(String index = null)
        {
            IDHopital = -1;
            txtNom.Text = "";
            txtAdresse.Text = "";
            txtTelephone.Text = "";
            txtMail.Text = "";
            txtSiteWeb.Text = "";
            txtBoitePostale.Text = "";
            txtRccm.Text = "";
            txtIDnat.Text = "";
            txtNumImpot.Text = "";
            pictureEdit1.Image = null;
            this.ChargerGrid();

        }
        void Modifier()
        {
            rowHandle = gridView1.FocusedRowHandle;

            IDHopital = int.Parse(gridView1.GetRowCellValue(rowHandle, "id").ToString());
            txtNom.Text = gridView1.GetRowCellValue(rowHandle, "nom").ToString();
            txtAdresse.Text = gridView1.GetRowCellValue(rowHandle, "adresse").ToString();
            txtTelephone.Text = gridView1.GetRowCellValue(rowHandle, "telephone").ToString();
            txtMail.Text = gridView1.GetRowCellValue(rowHandle, "mail").ToString();
            txtSiteWeb.Text = gridView1.GetRowCellValue(rowHandle, "siteweb").ToString();
            txtBoitePostale.Text = gridView1.GetRowCellValue(rowHandle, "boitePostal").ToString();
            txtRccm.Text = gridView1.GetRowCellValue(rowHandle, "rccm").ToString();
            txtIDnat.Text = gridView1.GetRowCellValue(rowHandle, "idNat").ToString();
            txtNumImpot.Text = gridView1.GetRowCellValue(rowHandle, "NumImpot").ToString();
            pictureEdit1.Image = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().getImageByte((byte[])gridView1.GetRowCellValue(rowHandle, "photo"));
        }

        int IDEse;
        void Supprimer()
        {
            rowHandle = gridView1.FocusedRowHandle;

            IDEse = int.Parse(gridView1.GetRowCellValue(rowHandle, "id").ToString());

            if (MessageBox.Show("Voulez-vous vraiement supprimer cette Information?", "SUPPRESSION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().delete_Parametre("tEntreprise", "id", IDEse);
                DevExpress.XtraEditors.XtraMessageBox.Show("Suppression reussie!");
                ChargerGrid();
            }


        }

        private Boolean CheckMyFields()
        {
            if (!String.IsNullOrWhiteSpace(txtNom.Text.Trim()) && txtNom.Text != ""
                && !String.IsNullOrWhiteSpace(txtAdresse.Text.Trim())
                && !String.IsNullOrWhiteSpace(txtMail.Text.Trim())
                && !String.IsNullOrWhiteSpace(txtTelephone.Text.Trim())
                )
            {
                return true;
            }
            return false;
        }
        private void Save(int index)
        {
            if (index == 0)
            {
                if (this.CheckMyFields())
                {


                    object[] values = new object[]
                        {
                            IDHopital,
                            txtNom.Text,
                            txtAdresse.Text,
                            txtTelephone.Text,
                            txtMail.Text,
                            ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().getByteImage(pictureEdit1),
                            txtSiteWeb.Text,
                            txtBoitePostale.Text,
                            txtRccm.Text,
                            txtIDnat.Text,
                            txtNumImpot.Text
                        };

                    if (MessageBox.Show("Voulez-vous enregistrer?", "ENREGISTREMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().saveData("saveEntreprise", Constantes.EntrepriseDBChamps, values);
                        this.RefreshHopital();

                    }

                }
                else
                {
                    MessageBox.Show("Il y a des champs Requis", "INFOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                switch (e.ClickedItem.Name.ToString())
                {
                    case "Modifier":
                        //Appercu et modification
                        Modifier();
                        break;
                    case "Supprimer":
                        this.Supprimer();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Save(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ucEntreprise_Load(object sender, EventArgs e)
        {
            try
            {
                ChargerGrid();
            }
            catch { }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Aperçu & Modification").Name = "Modifier";
                menu.Items.Add("Suppression").Name = "Supprimer";
                menu.Show(gridControl1, new Point(e.X, e.Y));
                menu.ItemClicked += Menu_ItemClicked;
            }
        }
    }
}
