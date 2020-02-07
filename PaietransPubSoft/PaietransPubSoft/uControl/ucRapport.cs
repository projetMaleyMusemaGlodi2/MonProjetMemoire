using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using PaietransPubSoft.Rapports;
using DevExpress.XtraSplashScreen;

namespace PaietransPubSoft.uControl
{
    public partial class ucRapport : UserControl
    {
        SplashScreenManager spl;
        public ucRapport(SplashScreenManager spl)
        {
            InitializeComponent();
            this.spl = spl;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                rpt_ListeClient rpt = new rpt_ListeClient();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().get_Report_S("vrapportclient");
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                rpt_ListeProprietaire rpt = new rpt_ListeProprietaire();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().get_Report_S("vrapportproprietaire");
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                rpt_ListeChauffeur rpt = new rpt_ListeChauffeur();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().get_Report_S("vrapportchauffeur");
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                rpt_ListeEngin rpt = new rpt_ListeEngin();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().get_Report_S("vrapportengin");
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                rpt_ListeAffectation rpt = new rpt_ListeAffectation();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().get_Report_S("vrapportaffectation");
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                rpt_RapportRetrait rpt = new rpt_RapportRetrait();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().get_Report_Trier("vrapportretraitcompte", "dateretrait", DateTime.Parse(txtdate1.Text),DateTime.Parse(txtdate2.Text));
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                rpt_RapportVirement rpt = new rpt_RapportVirement();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().get_Report_Trier("vrapportvirementcompte", "datevirement", DateTime.Parse(txtdate1.Text), DateTime.Parse(txtdate2.Text));
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                rpt_RapportPaiement rpt = new rpt_RapportPaiement();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().get_Report_Trier("vrapportpaiement", "datepaiement", DateTime.Parse(txtdate1.Text), DateTime.Parse(txtdate2.Text));
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                rpt_HistoriqueAffect rpt = new rpt_HistoriqueAffect();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().get_Report_Trier("vrapporthistoriqueaffect", "dateAffectation", DateTime.Parse(txtdate1.Text), DateTime.Parse(txtdate2.Text));
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                string idProprietaire = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetID("id", "tproprietaire", "noms", txtProprietaire.Text);
                rpt_RapportRetrait rpt = new rpt_RapportRetrait();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().get_Report_Trier("vrapportretraitcompte", "dateretrait", DateTime.Parse(txtdate1.Text), DateTime.Parse(txtdate2.Text),"refProprietaire", idProprietaire);
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string idProprietaire = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetID("id", "tproprietaire", "noms", txtProprietaire.Text);
                rpt_RapportVirement rpt = new rpt_RapportVirement();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().get_Report_Trier("vrapportvirementcompte", "datevirement", DateTime.Parse(txtdate1.Text), DateTime.Parse(txtdate2.Text), "refProprietaire", idProprietaire);
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string idProprietaire = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetID("id", "tproprietaire", "noms", txtProprietaire.Text);
                rpt_RapportPaiement rpt = new rpt_RapportPaiement();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().get_Report_Trier("vrapportpaiement", "datepaiement", DateTime.Parse(txtdate1.Text), DateTime.Parse(txtdate2.Text), "refProprietaire", idProprietaire);
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string idProprietaire = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetID("id", "tproprietaire", "noms", txtProprietaire.Text);
                rpt_HistoriqueAffect rpt = new rpt_HistoriqueAffect();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().get_Report_Trier("vrapporthistoriqueaffect", "dateAffectation", DateTime.Parse(txtdate1.Text), DateTime.Parse(txtdate2.Text), "refProprietaire", idProprietaire);
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                rpt_RapportPaiement rpt = new rpt_RapportPaiement();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().get_Report_Trier("vrapportpaiement", "datepaiement", DateTime.Parse(txtdate12.Text), DateTime.Parse(txtdate22.Text));
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                rpt_ChargementCompte rpt = new rpt_ChargementCompte();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().get_Report_Trier("vrapportchargecompte", "datecharge", DateTime.Parse(txtdate12.Text), DateTime.Parse(txtdate22.Text));
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                string idClient = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetID("id", "tclient", "noms", txtPassager.Text);
                rpt_RapportPaiement rpt = new rpt_RapportPaiement();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().get_Report_Trier("vrapportpaiement", "datepaiement", DateTime.Parse(txtdate12.Text), DateTime.Parse(txtdate22.Text), "refClient", idClient);
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                string idClient = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().GetID("id", "tclient", "noms", txtPassager.Text);
                rpt_ChargementCompte rpt = new rpt_ChargementCompte();
                rpt.DataSource = ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().get_Report_Trier("vrapportchargecompte", "datecharge", DateTime.Parse(txtdate12.Text), DateTime.Parse(txtdate22.Text), "refClient", idClient);
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ucRapport_Load(object sender, EventArgs e)
        {
            try
            {
                txtProprietaire.Items.Clear();
                txtPassager.Items.Clear();
                ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().chargeCombo(txtProprietaire, "noms", "tproprietaire");
                ALLProjetctdll.Classes.clsGlossiaireMYSQL.GetInstance().chargeCombo(txtPassager, "noms", "tAnnee");
            }
            catch
            {

            }
        }
    }
}
