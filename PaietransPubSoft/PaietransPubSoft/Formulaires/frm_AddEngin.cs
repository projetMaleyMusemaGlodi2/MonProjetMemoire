using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
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
    public partial class frm_AddEngin : Form
    {
        SplashScreenManager spl;
        int rowHandle;
        int IDPersonne = -1;
        int IDAffect = -1;
        object[] data;
        public frm_AddEngin(SplashScreenManager spl, object[] data)
        {
            InitializeComponent();
            this.spl = spl;
            if (data != null) this.data = data;
        }

        void RefreshHosp(String index = null)
        {
            IDPersonne = int.Parse(data[0].ToString());
            txtnomPersonne.Text = "";
            txtCategorie.SelectedIndex = -1;
            txtcouleur.Text = "";
            txtMarque.Text = "";
            txtnombrePlace.Text = "";
            txtnumeroplaque.Text = "";
            txtCompte.Text = "";
        }
        private Boolean CheckHospFields()
        {
            if (!String.IsNullOrEmpty(txtnomPersonne.Text) && !String.IsNullOrEmpty(txtCategorie.Text))
            {
                return true;
            }
            return false;
        }
        void SetData()
        {
            try
            {
                IDPersonne = int.Parse(data[0].ToString());
                labelpatient.Text = data[1].ToString();
                txtnomPersonne.Text = data[1].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Save(int index)
        {
            if (index == 0)
            {
                if (this.CheckHospFields())
                {


                    object[] values = new object[]
                        {
                            IDAffect,
                            txtMarque.Text,
                            txtcouleur.Text,
                            txtnumeroplaque.Text,
                            IDPersonne,
                            int.Parse(ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetID("id", "tcategorieengin", "designation", txtCategorie.Text)),
                            int.Parse(txtnombrePlace.Text),
                            int.Parse(txtCompte.Text),                           
                            ""+ALLProjetctdll.Classes.UserSession.GetInstance().UserName,
                        };

                    if (MessageBox.Show("Voulez-vous enregistrer?", "ENREGISTREMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().saveData("saveBus", Constantes.EnginDBChamps, values);
                        XtraMessageBox.Show("Enregistrement reussi!");
                        this.RefreshHosp();
                        ChargerGrid();
                    }

                }
                else
                {
                    MessageBox.Show("Il y a des champs Requis", "INFOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        void Modifier(int index)
        {
            rowHandle = gridView1.FocusedRowHandle;

            if (index == 1)
            {
                IDAffect = int.Parse(gridView1.GetRowCellValue(rowHandle, "id").ToString());
                IDPersonne = int.Parse(gridView1.GetRowCellValue(rowHandle, "refProprietaire").ToString());
                txtnomPersonne.Text = gridView1.GetRowCellValue(rowHandle, "noms").ToString();
                labelpatient.Text = gridView1.GetRowCellValue(rowHandle, "noms").ToString();
                txtCategorie.Text = gridView1.GetRowCellValue(rowHandle, "Categorie").ToString();
                txtcouleur.Text = gridView1.GetRowCellValue(rowHandle, "couleur").ToString();
                txtMarque.Text = gridView1.GetRowCellValue(rowHandle, "marque").ToString();
                txtnombrePlace.Text = gridView1.GetRowCellValue(rowHandle, "nombreplace").ToString();
                txtnumeroplaque.Text = gridView1.GetRowCellValue(rowHandle, "numeroplaque").ToString();
                txtCompte.Text = gridView1.GetRowCellValue(rowHandle, "compte").ToString();

            }
            else if (index == 2 || index == 3 )
            {
                object[] data = new object[]
                {
                    gridView1.GetRowCellValue(rowHandle, "id").ToString(),
                    gridView1.GetRowCellValue(rowHandle, "noms").ToString(),
                    gridView1.GetRowCellValue(rowHandle, "numeroplaque").ToString(),
                    gridView1.GetRowCellValue(rowHandle, "refProprietaire").ToString()
                };
                if (index == 2) new frm_AddAffectationChauffeur(data).ShowDialog();
                //if (index == 3) new frmAddRetenu(data).ShowDialog();                
            }
        }

        void Supprimer()
        {
            rowHandle = gridView1.FocusedRowHandle;

            IDAffect = int.Parse(gridView1.GetRowCellValue(rowHandle, "id").ToString());

            if (MessageBox.Show("Voulez-vous vraiement supprimer cette Information?", "SUPPRESSION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().delete_Parametre("tengin", "id", IDAffect);
                XtraMessageBox.Show("Suppression reussie!");
                this.RefreshHosp();
                ChargerGrid();
            }


        }
        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {//deces
                switch (e.ClickedItem.Name.ToString())
                {
                    case "Modifier":
                        //Appercu et modification
                        Modifier(1);
                        break;
                    case "Supprimer":
                        //Suppression
                        Supprimer();
                        break;
                    case "Chauffeur":
                        //Affectation Chauffeur
                        Modifier(2);
                        break;                                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ChargerGrid()
        {
            gridControl1.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().ChargerTable("vengin", "refProprietaire", IDPersonne.ToString());
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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Aperçu & Modification").Name = "Modifier";
                menu.Items.Add("Suppression").Name = "Supprimer";
                menu.Items.Add("Affecter un Chauffeur").Name = "Chauffeur";                
                menu.Show(gridControl1, new Point(e.X, e.Y));
                menu.ItemClicked += Menu_ItemClicked;
            }
        }

        private void frm_AddEngin_Load(object sender, EventArgs e)
        {

            try
            {
                spl.CloseWaitForm();
                txtCategorie.Items.Clear();
                ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().chargeCombo(txtCategorie, "designation", "tcategorieengin");
                if (data != null) this.SetData();
                ChargerGrid();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
