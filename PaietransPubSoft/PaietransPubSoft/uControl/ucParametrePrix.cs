using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaietransPubSoft.Classes;

namespace PaietransPubSoft.uControl
{
    public partial class ucParametrePrix : UserControl
    {
        public ucParametrePrix()
        {
            InitializeComponent();
        }
        int IDPrix;

        void Nouveau()
        {
            txtID.Text = "";
            txtDesignation.Text = "";
        }
        void chargement()
        {
            if (radioPrix.Checked == true)
            {
                gridCat.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetTable("tparametreprix");
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
            }            
        }
        void grid_clic()
        {
            try
            {
                int i;
                i = gridCat.CurrentRow.Index;
                txtID.Text = gridCat[0, i].Value.ToString();
                txtDesignation.Text = gridCat[1, i].Value.ToString();
                //if (radioTypeRecette.Checked == true)
                //{
                //    cmbRef.Text = gridCat[2, i].Value.ToString();
                //}
                //else
                //{
                //    //txtRefAdresse.Text = gridAdresse[2, i].Value.ToString();

                //}
            }
            catch (Exception)
            { }
        }
        void insertUpdateDelete(int i)
        {
            try
            {

                if (i == 1)
                {
                    ALLProjetctdll.Classes.clsConfiguration paramtre = new ALLProjetctdll.Classes.clsConfiguration();

                    if (txtDesignation.Text == "")
                    {
                        MessageBox.Show("Completez tous les champs svp !!!", "Champs requis", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        paramtre.Designation = txtDesignation.Text;
                        //tAnnee

                        if (radioPrix.Checked == true)
                        {

                            object[] values = new object[]
                               {
                                    IDPrix,
                                    txtDesignation.Text,                                   
                                    ""+ALLProjetctdll.Classes.UserSession.GetInstance().UserName
                               };
                            if (MessageBox.Show("Voulez-vous enregistrer?", "ENREGISTREMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().saveData("savePrix", Constantes.ParametrePrixDBChamps, values);
                                chargement();
                            }
                        }
                       

                    }
                }
                else if (i == 2)
                {
                    ALLProjetctdll.Classes.clsConfiguration paramtre = new ALLProjetctdll.Classes.clsConfiguration();

                    if (txtDesignation.Text == "" || txtID.Text == "")
                    {
                        MessageBox.Show("Completez tous les champs svp !!!", "Champs requis", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        paramtre.Designation = txtDesignation.Text;
                        //tFonction

                        if (radioPrix.Checked == true)
                        {
                            object[] values = new object[]
                               {
                                    int.Parse(txtID.Text),
                                    txtDesignation.Text,
                                    ""+ALLProjetctdll.Classes.UserSession.GetInstance().UserName
                               };
                            if (MessageBox.Show("Voulez-vous enregistrer?", "ENREGISTREMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().saveData("savePrix", Constantes.ParametrePrixDBChamps, values);
                                chargement();
                            }
                        }
                        //tTypePaiement
                        
                    }
                }

                else if (i == 3)
                {

                    if (txtID.Text == "")
                    {
                        MessageBox.Show("Veillez selectionner la ligne à supprimer svp !!!", "Attention!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (radioPrix.Checked == true)
                        {
                            ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().delete_Parametre("tparametreprix", "id", int.Parse(txtID.Text));
                            chargement();
                        }                        

                    }
                }
                Nouveau();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            insertUpdateDelete(1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            insertUpdateDelete(2);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            insertUpdateDelete(3);
        }

        private void gridCat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            grid_clic();
        }

        private void simpleButton45_Click(object sender, EventArgs e)
        {
            Nouveau();
        }

        private void radioFonction_CheckedChanged(object sender, EventArgs e)
        {
            chargement();
        }

        private void ucParametrePrix_Load(object sender, EventArgs e)
        {
            radioPrix.Checked = true;
        }

        private void txtDesignation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
