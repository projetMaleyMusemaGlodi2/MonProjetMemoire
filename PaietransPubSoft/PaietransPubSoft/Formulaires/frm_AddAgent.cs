using DevExpress.XtraSplashScreen;
using PaietransPubSoft.Classes;
using PaietransPubSoft.uControl;
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
    public partial class frm_AddAgent : Form
    {
        ucAgent personne = null;
        clsImabar codage = new clsImabar();
        int IDMalade = -1;
        object[] data;
        SplashScreenManager spl;
        public frm_AddAgent(SplashScreenManager spl, ucAgent personne, object[] data = null)
        {
            InitializeComponent();
            this.spl = spl;
            this.personne = personne;
            if (data != null) this.data = data;
        }

        
        void RefreshMalade(String index = null)
        {
            IDMalade = -1;
            txtid.Text = "";
            txtNom.Text = "";
            txtadresse.Text = "";
            txtContact.Text = "";
            txtmail.Text = "";
            txtsexe.SelectedIndex = -1;
            txtdatenaissance.Text = "";
            txtlieunaissance.Text = "";
            txtEtatCivil.SelectedIndex = -1;
            txtniveauEtude.Text = "";
            txtFonction.SelectedIndex = -1;
            picPhoto.Image = Image.FromFile(Environment.CurrentDirectory + @"\library\elementary_school.png");
            txtusername.Text = "";
            txtpassword.Text = "";
            personne.ChargerGrid();

        }
        //id,noms,adresse,contact,mail,sexe,datenaissance,lieunaissance,etatcivil,niveauetude,fonction,image,qrCode,username,password,usersession
        void SetData()
        {
            try
            {
                IDMalade = int.Parse(data[0].ToString());
                txtid.Text = data[0].ToString();
                txtNom.Text = data[1].ToString();
                txtadresse.Text = data[2].ToString();
                txtContact.Text = data[3].ToString();
                txtmail.Text = data[4].ToString();
                txtsexe.SelectedItem = data[5].ToString();
                txtdatenaissance.Text = data[6].ToString();
                txtlieunaissance.Text = data[7].ToString();
                txtEtatCivil.SelectedItem= data[8].ToString();
                txtniveauEtude.Text = data[9].ToString();
                txtFonction.SelectedItem = data[10].ToString();
                txtusername.Text = data[13].ToString();
                txtpassword.Text = data[14].ToString();
                picPhoto.Image = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().getImageByte((byte[])data[11]);
                picQrcode.Image = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().getImageByte((byte[])data[12]);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private Boolean CheckMaladeFields()
        {
            if (!String.IsNullOrWhiteSpace(txtNom.Text.Trim())
                && !String.IsNullOrWhiteSpace(txtadresse.Text.Trim()) && !String.IsNullOrWhiteSpace(txtContact.Text.Trim())
                && !String.IsNullOrWhiteSpace(txtmail.Text.Trim()) && !String.IsNullOrWhiteSpace(txtsexe.Text.Trim()) 
                && !String.IsNullOrWhiteSpace(txtdatenaissance.Text.Trim()) && !String.IsNullOrWhiteSpace(txtlieunaissance.Text.Trim()) 
                && !String.IsNullOrWhiteSpace(txtEtatCivil.Text.Trim()) && !String.IsNullOrWhiteSpace(txtniveauEtude.Text.Trim())
                && !String.IsNullOrWhiteSpace(txtFonction.Text.Trim()) && !String.IsNullOrWhiteSpace(txtusername.Text.Trim())
                && !String.IsNullOrWhiteSpace(txtpassword.Text.Trim())
                )
            {
                return true;
            }
            return false;
        }
        //noms,adresse,contact,mail,typepieceid,numeropieceid,username,usersession,qrCode
        private void Save(int index)
        {
            if (index == 0)
            {
                if (this.CheckMaladeFields())
                {


                    object[] values = new object[]
                        {

                           IDMalade,
                           txtNom.Text,
                           txtadresse.Text,
                           txtContact.Text,
                           txtmail.Text,
                           txtsexe.Text,
                           DateTime.Parse(txtdatenaissance.Text),
                           txtlieunaissance.Text,
                           txtEtatCivil.Text,
                           txtniveauEtude.Text,
                           txtFonction.Text,
                           ALLProjetctdll.Classes.clsGlossiaire.GetInstance().getByteImage(picPhoto),
                           ALLProjetctdll.Classes.clsGlossiaire.GetInstance().getByteImage(picQrcode),
                           txtusername.Text,
                           txtpassword.Text,
                           ""+ALLProjetctdll.Classes.UserSession.GetInstance().UserName
                        };

                    if (MessageBox.Show("Voulez-vous enregistrer?", "ENREGISTREMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().saveData("saveAgent", Constantes.AgentDBChamps, values);
                        this.RefreshMalade();
                        personne.ChargerGrid();
                    }

                }
                else
                {
                    MessageBox.Show("Il y a des champs Requis", "INFOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (index == 1) { }

        }




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Save(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void frm_AddAgent_Load(object sender, EventArgs e)
        {
            try
            {
                
                spl.CloseWaitForm();
                ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().chargeCombo(txtFonction, "designation", "tfonction");
                if (data != null) this.SetData();

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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtid.Text))
                {
                    codage.QRCode(picQrcode, txtid.Text);
                    Save(0);
                }
                else
                {
                    MessageBox.Show("Il y a des champs Requis", "INFOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
    }
}
