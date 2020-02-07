using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaietransPubSoft.Classes;
using DevExpress.XtraEditors;

namespace PaietransPubSoft.Formulaires
{
    public partial class frm_AddAffectationChauffeur : Form
    {
        int rowHandle;
        int IDAffect = -1;
        int IDEngin = -1;
        int IDChauffeur = -1;
        object[] data;
        public frm_AddAffectationChauffeur(object[] data)
        {
            InitializeComponent();
            if (data != null) this.data = data;
        }

        void RefreshHosp(String index = null)
        {
            IDEngin = int.Parse(data[0].ToString());
            IDChauffeur = -1;
            IDEngin = -1;
            txtnomProprietaire.Text = "";
            txtnomChauffeur.Text = "";
            txtnomEngin.Text = "";
            txtdate.Text = "";

        }
        private Boolean CheckHospFields()
        {
            if (IDAffect != -1 && !String.IsNullOrEmpty(txtnomProprietaire.Text) && !String.IsNullOrEmpty(txtnomEngin.Text) && !String.IsNullOrEmpty(txtnomChauffeur.Text))
            {
                return true;
            }
            return false;
        }
        void SetData()
        {
            try
            {
                IDEngin = int.Parse(data[0].ToString());
                labelpatient.Text = data[1].ToString();
                txtnomProprietaire.Text = data[1].ToString();
                txtnomEngin.Text= data[2].ToString();

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
                            IDEngin,
                            IDChauffeur,
                            ""+ALLProjetctdll.Classes.UserSession.GetInstance().UserName
                       };

                    if (MessageBox.Show("Voulez-vous enregistrer?", "ENREGISTREMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().saveData("saveAffectationChauffeur", Constantes.AffectChauffeurDBChamps, values);
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
                IDEngin = int.Parse(gridView1.GetRowCellValue(rowHandle, "refEngin").ToString());
                IDChauffeur = int.Parse(gridView1.GetRowCellValue(rowHandle, "refChauffeur").ToString());
                txtnomProprietaire.Text = gridView1.GetRowCellValue(rowHandle, "Proprietaire").ToString();
                labelpatient.Text = gridView1.GetRowCellValue(rowHandle, "Proprietaire").ToString();
                txtnomEngin.Text = gridView1.GetRowCellValue(rowHandle, "numeroplaque").ToString();
                txtnomChauffeur.Text = gridView1.GetRowCellValue(rowHandle, "Chauffeur").ToString();
                txtdate.Text = gridView1.GetRowCellValue(rowHandle, "dateAffectation").ToString();
            }
            else if (index == 2 || index == 3)
            {
                object[] data = new object[]
                {
                    gridView1.GetRowCellValue(rowHandle, "id").ToString(),
                    gridView1.GetRowCellValue(rowHandle, "Proprietaire").ToString(),
                    gridView1.GetRowCellValue(rowHandle, "detailEngin").ToString(),
                    gridView1.GetRowCellValue(rowHandle, "Chauffeur").ToString(),
                    gridView1.GetRowCellValue(rowHandle, "refProprietaire").ToString()
                };
                if (index == 2) new frm_AddRetraitBus(data).ShowDialog();
                else if (index == 3) new frm_AddVirement(data).ShowDialog();
            }
            
        }

        void Supprimer()
        {
            rowHandle = gridView1.FocusedRowHandle;

            IDAffect = int.Parse(gridView1.GetRowCellValue(rowHandle, "id").ToString());

            if (MessageBox.Show("Voulez-vous vraiement supprimer cette Information?", "SUPPRESSION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().delete_Parametre("taffectationchauffeur", "id", IDAffect);
                XtraMessageBox.Show("Suppression reussie!");
                this.RefreshHosp();
                ChargerGrid();
            }


        }
        //Retrait
        //Virement
        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
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
                    case "Retrait":
                        //Suppression
                        Modifier(2);
                        break;
                    case "Virement":
                        //Suppression
                        Modifier(3);
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
            //chargement condition
            gridControl1.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().ChargerTable("vaffectationchauffeur", "refProprietaire", data[3].ToString());
        }



        private void frm_AddAffectationChauffeur_Load(object sender, EventArgs e)
        {
            try
            {
                ChargerGrid();
                if (data != null) this.SetData();

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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Aperçu & Modification").Name = "Modifier";
                menu.Items.Add("Suppression").Name = "Supprimer";
                menu.Items.Add("Retrait dans le Compte").Name = "Retrait";
                menu.Items.Add("Virement des Comptes(Permitation des Recettes)").Name = "Virement";
                menu.Show(gridControl1, new Point(e.X, e.Y));
                menu.ItemClicked += Menu_ItemClicked;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            clsGetInfoPersonne.GetInstance().NomTable = "vSeachChauffeur";
            frm_SearchPersonne f = new frm_SearchPersonne();
            f.ShowDialog();           
            txtnomChauffeur.Text = clsGetInfoPersonne.GetInstance().Nom;
            IDChauffeur = clsGetInfoPersonne.GetInstance().Id;          
        }
    }
}
