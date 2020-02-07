using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace PaietransPubSoft.uControl
{
    public partial class uc_Configuration : UserControl
    {
        SplashScreenManager spl;
        public uc_Configuration(SplashScreenManager spl)
        {
            InitializeComponent();
            this.spl = spl;
        }
        public uc_Configuration()
        {
            InitializeComponent();            
        }

        private void switchUC(UserControl uc)
        {
            spl.ShowWaitForm();
            panelConf.Controls.Clear();
            uc.Dock = panelConf.Dock;
            panelConf.Controls.Add(uc);
            spl.CloseWaitForm();

        }

        private void panelConf_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            switchUC(new ucFonctionnement());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ALLProjetctdll.Formulaires.FormBackup f = new ALLProjetctdll.Formulaires.FormBackup();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switchUC(new ucParametrePrix());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switchUC(new ucEntreprise());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            switchUC(new ucUser());
        }
    }
}
