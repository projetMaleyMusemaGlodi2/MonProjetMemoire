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
    public partial class ucUser : UserControl
    {
        //SplashScreenManager spl;
        int rowHandle;
        int IDHopital = -1;
        public ucUser()
        {
            InitializeComponent();           
        }

        public void ChargerGrid()
        {

            try
            {
                gridControl1.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetTable("tuser");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void RefreshHopital(String index = null)
        {
            IDHopital = -1;
            txtUsername.Text = "";
            txtpassword.Text = "";
            txtniveau.Text = "";

            this.ChargerGrid();

        }
        void Modifier()
        {
            rowHandle = gridView1.FocusedRowHandle;

            IDHopital = int.Parse(gridView1.GetRowCellValue(rowHandle, "id").ToString());
            txtUsername.Text = gridView1.GetRowCellValue(rowHandle, "nom").ToString();
            txtpassword.Text = gridView1.GetRowCellValue(rowHandle, "pass").ToString();
            txtniveau.Text = gridView1.GetRowCellValue(rowHandle, "niveau").ToString();
        }

        int IDEse;
        void Supprimer()
        {
            rowHandle = gridView1.FocusedRowHandle;

            IDEse = int.Parse(gridView1.GetRowCellValue(rowHandle, "id").ToString());

            if (MessageBox.Show("Voulez-vous vraiement supprimer cette Information?", "SUPPRESSION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().delete_Parametre("tuser", "id", IDEse);
                DevExpress.XtraEditors.XtraMessageBox.Show("Suppression reussie!");
                ChargerGrid();
            }


        }

        private Boolean CheckMyFields()
        {
            if (
                !String.IsNullOrWhiteSpace(txtUsername.Text.Trim())
                && !String.IsNullOrWhiteSpace(txtpassword.Text.Trim())
                && !String.IsNullOrWhiteSpace(txtniveau.Text.Trim())
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
                            txtUsername.Text,
                            txtpassword.Text,
                            txtniveau.Text

                        };

                    if (MessageBox.Show("Voulez-vous enregistrer?", "ENREGISTREMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().saveData("saveUser", Constantes.UtilisateurDBChamps, values);
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

        private void ucUser_Load(object sender, EventArgs e)
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
