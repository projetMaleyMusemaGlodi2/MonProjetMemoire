using DevExpress.XtraSplashScreen;
using PaietransPubSoft.Formulaires;
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

namespace PaietransPubSoft
{
    public partial class Form1 : Form
    {
        SplashScreenManager spl;
        public Form1(SplashScreenManager spl)
        {
            InitializeComponent();
            this.spl = spl;
            switchClic(new ucHome(), btnHome);
        }
        
        void switchClic(Control uc, Button b)
        {
            //move indicator
            SidePanel.Height = b.Height;
            SidePanel.Top = b.Top;
            //change control
            PanelPrincipal.Controls.Clear();
            uc.Dock = PanelPrincipal.Dock;
            PanelPrincipal.Controls.Add(uc);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            spl.CloseWaitForm();
        }

        private void btnPersonnel_Click(object sender, EventArgs e)
        {
            spl.ShowWaitForm();
            switchClic(new ucPassager(spl), btnPassager);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPaiement_Click(object sender, EventArgs e)
        {
            spl.ShowWaitForm();
            switchClic(new ucProprietaire(spl), btnProprietaire);
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            spl.ShowWaitForm();
            switchClic(new ucChauffeur(spl), btnChauffeur);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            spl.ShowWaitForm();
            switchClic(new ucAgent(spl), btnPersonnel);
        }

        private void btnRapport_Click_1(object sender, EventArgs e)
        {
            //spl.ShowWaitForm();
            switchClic(new ucAlerte(spl), btnAlerte);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //spl.ShowWaitForm();
            switchClic(new uc_Configuration(spl), btnParametre);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void btnDeconnexion_Click(object sender, EventArgs e)
        {
            new frm_Login().Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            switchClic(new ucRapport(spl), btnRapport);
        }
    }
}
