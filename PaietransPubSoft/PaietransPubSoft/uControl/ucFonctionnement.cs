using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaietransPubSoft.uControl
{
    public partial class ucFonctionnement : UserControl
    {
        public ucFonctionnement()
        {
            InitializeComponent();
        }

        void Nouveau()
        {
            txtID.Text = "";
            txtDesignation.Text = "";            
        }
        void chargement()
        {
            if (radioFonction.Checked == true)
            {
                gridCat.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetTable("tfonction");
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
            else if (radioDescription.Checked == true)
            {
                gridCat.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetTable("tdescriptionese");
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
            else if (radioCategorie.Checked == true)
            {
                gridCat.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetTable("tcategorieengin");
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
            else if (radioAide.Checked == true)
            {
                gridCat.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetTable("taide");
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
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

                        if (radioFonction.Checked == true)
                        {
                            ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().insert_Parametre(paramtre, "tfonction","designation");
                            chargement();
                        }
                        else if (radioDescription.Checked == true)
                        {
                            ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().insert_Parametre(paramtre, "tdescriptionese","message");
                            chargement();
                        }
                        else if (radioCategorie.Checked == true)
                        {
                            ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().insert_Parametre(paramtre, "tcategorieengin","designation");
                            chargement();
                        }
                        else if (radioAide.Checked == true)
                        {
                            ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().insert_Parametre(paramtre, "taide","message");
                            chargement();
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

                        if (radioFonction.Checked == true)
                        {
                            paramtre.Id = int.Parse(txtID.Text);
                            ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().update_Parametre(paramtre, "tfonction", "id", "designation");
                            chargement();
                        }
                        //tTypePaiement
                        else if (radioDescription.Checked == true)
                        {
                            paramtre.Id = int.Parse(txtID.Text);
                            ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().update_Parametre(paramtre, "tdescriptionese", "id", "message");
                            chargement();
                        }
                        else if (radioCategorie.Checked == true)
                        {
                            paramtre.Id = int.Parse(txtID.Text);
                            ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().update_Parametre(paramtre, "tcategorieengin", "id", "designation");
                            chargement();
                        }
                        else if (radioAide.Checked == true)
                        {
                            paramtre.Id = int.Parse(txtID.Text);
                            ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().update_Parametre(paramtre, "taide", "id", "message");
                            chargement();
                        }
                        
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
                        if (radioFonction.Checked == true)
                        {
                            ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().delete_Parametre("tfonction", "id", int.Parse(txtID.Text));
                            chargement();
                        }
                        else if (radioDescription.Checked == true)
                        {
                            ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().delete_Parametre("tdescriptionese", "id", int.Parse(txtID.Text));
                            chargement();
                        }
                        else if (radioCategorie.Checked == true)
                        {
                            ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().delete_Parametre("tcategorieengin", "id", int.Parse(txtID.Text));
                            chargement();
                        }
                        else if (radioAide.Checked == true)
                        {
                            ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().delete_Parametre("taide", "id", int.Parse(txtID.Text));
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

        private void gridCat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            grid_clic();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            insertUpdateDelete(2);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            insertUpdateDelete(3);
        }

        private void simpleButton45_Click(object sender, EventArgs e)
        {
            Nouveau();
        }

        private void ucFonctionnement_Load(object sender, EventArgs e)
        {
            radioFonction.Checked = true;
        }

        private void radioFonction_CheckedChanged(object sender, EventArgs e)
        {
            chargement();
        }

        private void radioDescription_CheckedChanged(object sender, EventArgs e)
        {
            chargement();
        }

        private void radioCategorie_CheckedChanged(object sender, EventArgs e)
        {
            chargement();
        }

        private void radioAide_CheckedChanged(object sender, EventArgs e)
        {
            chargement();
        }
    }
}
