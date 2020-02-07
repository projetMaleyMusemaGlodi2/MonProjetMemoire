using ALLProjetctdll.Classes;
using DevExpress.XtraSplashScreen;
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
    public partial class frm_Login : Form
    {
        //SplashScreenManager MysplashScreen;
        public frm_Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MysplashScreen.ShowWaitForm();           
            try
            {
                pubCon.testlog = ALLProjetctdll.Classes.pubCon.testlog = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().loginTest(txtUsername.Text, txtPassword.Text, "SP_Login", "nom", "pass", "niveau");

                if (pubCon.testlog == 1)
                {
                    new Form1(MysplashScreen).Show();
                    this.Hide();
                    //this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void txtUsername_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {            
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            panel2.ForeColor = Color.FromArgb(78, 184, 206);
            txtPassword.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            panel1.ForeColor = Color.FromArgb(78, 184, 206);
            txtUsername.ForeColor = Color.FromArgb(78, 184, 206);
        }
    }
}
