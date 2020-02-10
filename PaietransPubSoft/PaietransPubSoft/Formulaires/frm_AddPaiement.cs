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
    public partial class frm_AddPaiement : Form
    {
        SplashScreenManager spl;
        int rowHandle;
        int IDPaie= -1;
        int IDClient = -1;
        int IDEngin = -1;
        object[] data;
        public frm_AddPaiement(SplashScreenManager spl,object[] data)
        {
            InitializeComponent();
            this.spl = spl;
            if (data != null) this.data = data;
        }

        void RefreshHosp(String index = null)
        {
            IDClient = int.Parse(data[0].ToString());
            IDEngin = -1;
            IDPaie = -1;
            txtnomClient.Text = "";
            txtnomEngin.Text = "";
            txtmontant.Text = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().retourId("prix", "tparametreprix");
            txtdate.Text = "";

        }
        private Boolean CheckHospFields()
        {
            if (!String.IsNullOrEmpty(txtnomClient.Text) && !String.IsNullOrEmpty(txtmontant.Text) && !String.IsNullOrEmpty(txtnomEngin.Text))
            {
                return true;
            }
            return false;
        }
        void SetData()
        {
            try
            {
                IDClient = int.Parse(data[0].ToString());
                labelpatient.Text = data[1].ToString();
                txtnomClient.Text = data[1].ToString();               
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
                int Prix = int.Parse(ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().retourId("prix", "tparametreprix"));
                if (this.CheckHospFields())
                {
                    object[] values = new object[]
                       {
                           IDPaie,
                           Prix,
                           IDClient,
                           IDEngin,
                           ""+ALLProjetctdll.Classes.UserSession.GetInstance().UserName
                       };

                    if (MessageBox.Show("Voulez-vous enregistrer?", "ENREGISTREMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().saveData("savePaiement", Constantes.PaiementBusrDBChamps, values);
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
        void Modifier()
        {
            rowHandle = gridView1.FocusedRowHandle;

            IDPaie = int.Parse(gridView1.GetRowCellValue(rowHandle, "id").ToString());
            IDEngin = int.Parse(gridView1.GetRowCellValue(rowHandle, "refAffectChauffeur").ToString());
            IDClient = int.Parse(gridView1.GetRowCellValue(rowHandle, "refClient").ToString());
            txtnomClient.Text = gridView1.GetRowCellValue(rowHandle, "Client").ToString();
            labelpatient.Text = gridView1.GetRowCellValue(rowHandle, "Client").ToString();
            txtmontant.Text = gridView1.GetRowCellValue(rowHandle, "montant").ToString();
            txtnomEngin.Text = gridView1.GetRowCellValue(rowHandle, "detailEngin").ToString();
            txtdate.Text = gridView1.GetRowCellValue(rowHandle, "datepaiement").ToString();
        }

        void Supprimer()
        {
            rowHandle = gridView1.FocusedRowHandle;

            IDPaie = int.Parse(gridView1.GetRowCellValue(rowHandle, "id").ToString());

            if (MessageBox.Show("Voulez-vous vraiement supprimer cette Information?", "SUPPRESSION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().delete_Parametre("tpaiement", "id", IDPaie);
                XtraMessageBox.Show("Suppression reussie!");
                this.RefreshHosp();
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
                        //Appercu et modification
                        Modifier();
                        break;
                    case "Supprimer":
                        //Suppression
                        Supprimer();
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
            gridControl1.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().ChargerTable("vpaiementtransport", "refClient", data[0].ToString());
        }


        private void frm_AddPaiement_Load(object sender, EventArgs e)
        {
            try
            {
                spl.CloseWaitForm();
                ChargerGrid();
                if (data != null) this.SetData();
                txtmontant.Text = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().retourId("prix", "tparametreprix");
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

        bool testeCompteClient(string IdClientTeste, string montant)
        {
            bool teste = false;
            bool valueTeste=ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().teste_QuantiteSotock("id", "Compte", "tClient", IdClientTeste.ToString(), montant);
            if (valueTeste == true)
            {
                teste = true;
            }
            else
            {
                teste = false;
            }
            
            return teste;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(IDClient.ToString()) || String.IsNullOrEmpty(txtmontant.Text))
                {
                    MessageBox.Show("Il y a des champs Requis", "INFOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (testeCompteClient(IDClient.ToString(), txtmontant.Text) == true)
                    {
                        Save(0);
                    }
                    else
                    {
                        MessageBox.Show("Ce Compte est insuffisant pour faire cette course svp !!!", "Compte Insuffisant", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    }
                }
                
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
            clsGetInfoPersonne.GetInstance().NomTable = "vsearchaffectation";
            frm_SearchPersonne f = new frm_SearchPersonne();
            f.ShowDialog();
            txtnomEngin.Text = clsGetInfoPersonne.GetInstance().Nom;
            IDEngin = clsGetInfoPersonne.GetInstance().Id;
        }
    }
}
