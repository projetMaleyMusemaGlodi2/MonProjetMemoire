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
    public partial class frm_AddRetraitBus : Form
    {
        //SplashScreenManager spl;
        int rowHandle;
        int IDPaie = -1;
        int IDEngin = -1;
        object[] data;
        public frm_AddRetraitBus(object[] data)
        {
            InitializeComponent();           
            if (data != null) this.data = data;
        }


        private void ChargerGrid()
        {
            //chargement condition
            gridControl1.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().ChargerTable("vretraitcompte", "refProprietaire", data[4].ToString());
        }

        void RefreshHosp(String index = null)
        {
            IDEngin = int.Parse(data[0].ToString());
            IDPaie = -1;
            txtnomEngin.Text = "";
            txtmontant.Text = "";
            txtdate.Text = "";
            txtlibelle.Text = "";

        }
        private Boolean CheckHospFields()
        {
            if (!String.IsNullOrEmpty(txtnomEngin.Text) && !String.IsNullOrEmpty(txtmontant.Text) && !String.IsNullOrEmpty(txtlibelle.Text))
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
                txtnomEngin.Text = data[2].ToString();
                txtnomChauffeur.Text = data[3].ToString();
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
                           IDPaie,
                           IDEngin,
                           int.Parse(txtmontant.Text),
                           txtlibelle.Text,
                           ""+ALLProjetctdll.Classes.UserSession.GetInstance().UserName
                       };

                    if (MessageBox.Show("Voulez-vous enregistrer?", "ENREGISTREMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().saveData("saveRetraitCompte", Constantes.RetraitBusDBChamps, values);
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
            txtnomEngin.Text = gridView1.GetRowCellValue(rowHandle, "detailEngin ").ToString();
            labelpatient.Text = gridView1.GetRowCellValue(rowHandle, "Proprietaire").ToString();
            txtmontant.Text = gridView1.GetRowCellValue(rowHandle, "montant").ToString();
            txtdate.Text = gridView1.GetRowCellValue(rowHandle, "dateretrait").ToString();
            txtlibelle.Text = gridView1.GetRowCellValue(rowHandle, "libelle").ToString();
            txtnomChauffeur.Text = gridView1.GetRowCellValue(rowHandle, "Chauffeur").ToString();
        }

        void Supprimer()
        {
            rowHandle = gridView1.FocusedRowHandle;

            IDPaie = int.Parse(gridView1.GetRowCellValue(rowHandle, "id").ToString());

            if (MessageBox.Show("Voulez-vous vraiement supprimer cette Information?", "SUPPRESSION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().delete_Parametre("tretraitbus", "id", IDPaie);
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






        private void frm_AddRetraitBus_Load(object sender, EventArgs e)
        {
            try
            {
                //spl.CloseWaitForm();
                ChargerGrid();
                if (data != null) this.SetData();
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message);
            }
        }

        bool testeCompteClient(string IdClientTeste, string montant)
        {
            bool teste = false;
            bool valueTeste = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().teste_QuantiteSotock("id", "Compte", "tengin", IdClientTeste.ToString(), montant);
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
                if (String.IsNullOrEmpty(IDEngin.ToString()) || String.IsNullOrEmpty(txtmontant.Text))
                {
                    MessageBox.Show("Il y a des champs Requis", "INFOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (testeCompteClient(IDEngin.ToString(), txtmontant.Text) == true)
                    {
                        Save(0);
                    }
                    else
                    {
                        MessageBox.Show("Ce Compte est insuffisant pour faire cette Opération svp !!!", "Compte Insuffisant", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
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

        private void txtmontant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
