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
    public partial class frm_AddPasser : Form
    {
        ucPassager personne = null;
        clsImabar codage = new clsImabar();
        int IDMalade = -1;
        object[] data;
        SplashScreenManager spl;
        public frm_AddPasser(SplashScreenManager spl, ucPassager personne, object[] data = null)
        {
            InitializeComponent();
            this.spl = spl;
            this.personne = personne;
            if (data != null) this.data = data;
        }
        ///*id,noms,adresse,contact,mail,typepieceid,numeropieceid,image,username,password,usersession*/
        void RefreshMalade(String index = null)
        {
            IDMalade = -1;
            txtid.Text = "";
            txtNom.Text = "";
            txtadresse.Text = "";
            txtContact.Text="";
            txtmail.Text = "";
            txttypepieceid.Text = "";
            txtnumeropiece.Text = "";
            picPhoto.Image = Image.FromFile(Environment.CurrentDirectory + @"\library\elementary_school.png");
            txtusername.Text = "";
            txtpassword.Text = "";
            personne.ChargerGrid();

        }
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
                txttypepieceid.Text = data[5].ToString();
                txtnumeropiece.Text = data[6].ToString();
                string nomImage= data[7].ToString();
                txtusername.Text = data[8].ToString();
                txtpassword.Text = data[9].ToString();
                picPhoto.Image = Image.FromFile(@"C:\xampp\htdocs\transpaie_php\images\" + nomImage+"");
                picQrcode.Image = ALLProjetctdll.Classes.clsGlossiaire.GetInstance().getImageByte((byte[])data[11]);

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
                && !String.IsNullOrWhiteSpace(txtmail.Text.Trim()) && !String.IsNullOrWhiteSpace(txttypepieceid.Text.Trim())
                && !String.IsNullOrWhiteSpace(txtnumeropiece.Text.Trim()) && !String.IsNullOrWhiteSpace(txtusername.Text.Trim())
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
                            txttypepieceid.Text,
                            txtnumeropiece.Text,
                            txtusername.Text,
                            ""+ALLProjetctdll.Classes.UserSession.GetInstance().UserName,
                            ALLProjetctdll.Classes.clsGlossiaire.GetInstance().getByteImage(picQrcode),
                            ALLProjetctdll.Classes.clsGlossiaire.GetInstance().getByteImage(picPhoto)
                        };

                    if (MessageBox.Show("Voulez-vous enregistrer?", "ENREGISTREMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().saveData("saveClient", Constantes.PassagerDBChamps, values);
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
                MessageBox.Show("Error : "+ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_AddPasser_Load(object sender, EventArgs e)
        {
            try
            {
                spl.CloseWaitForm();
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
