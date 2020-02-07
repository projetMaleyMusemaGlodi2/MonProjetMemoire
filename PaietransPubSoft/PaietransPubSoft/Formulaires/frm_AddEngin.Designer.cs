namespace PaietransPubSoft.Formulaires
{
    partial class frm_AddEngin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AddEngin));
            this.txtCategorie = new MetroFramework.Controls.MetroComboBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnomPersonne = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.labelpatient = new System.Windows.Forms.Label();
            this.lblNoms = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtcouleur = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtnumeroplaque = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMarque = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtnombrePlace = new System.Windows.Forms.TextBox();
            this.txtCompte = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCategorie
            // 
            this.txtCategorie.DropDownHeight = 100;
            this.txtCategorie.FormattingEnabled = true;
            this.txtCategorie.IntegralHeight = false;
            this.txtCategorie.ItemHeight = 23;
            this.txtCategorie.Items.AddRange(new object[] {
            "EXPIRATIONS",
            "PERTES DIVERSES"});
            this.txtCategorie.Location = new System.Drawing.Point(250, 113);
            this.txtCategorie.Name = "txtCategorie";
            this.txtCategorie.Size = new System.Drawing.Size(301, 29);
            this.txtCategorie.Style = MetroFramework.MetroColorStyle.Black;
            this.txtCategorie.TabIndex = 300;
            this.txtCategorie.UseSelectable = true;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.Location = new System.Drawing.Point(0, 390);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(814, 195);
            this.gridControl1.TabIndex = 299;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.gridView1.Appearance.Empty.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.gridView1.Appearance.Preview.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "Flat";
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.label2.Location = new System.Drawing.Point(249, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 19);
            this.label2.TabIndex = 298;
            this.label2.Text = "Propriétaire*";
            // 
            // txtnomPersonne
            // 
            this.txtnomPersonne.Enabled = false;
            this.txtnomPersonne.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnomPersonne.Location = new System.Drawing.Point(250, 65);
            this.txtnomPersonne.Name = "txtnomPersonne";
            this.txtnomPersonne.Size = new System.Drawing.Size(301, 24);
            this.txtnomPersonne.TabIndex = 297;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.label3.Location = new System.Drawing.Point(253, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 19);
            this.label3.TabIndex = 296;
            this.label3.Text = "Catégorie*";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.button1.Location = new System.Drawing.Point(213, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(364, 34);
            this.button1.TabIndex = 295;
            this.button1.Text = "Enregistrer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.labelpatient);
            this.panel1.Controls.Add(this.lblNoms);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 33);
            this.panel1.TabIndex = 294;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(764, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 33);
            this.button2.TabIndex = 245;
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelpatient
            // 
            this.labelpatient.AutoSize = true;
            this.labelpatient.BackColor = System.Drawing.Color.Transparent;
            this.labelpatient.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelpatient.ForeColor = System.Drawing.Color.White;
            this.labelpatient.Location = new System.Drawing.Point(278, 9);
            this.labelpatient.Name = "labelpatient";
            this.labelpatient.Size = new System.Drawing.Size(187, 19);
            this.labelpatient.TabIndex = 243;
            this.labelpatient.Text = "Affectation des Personnels";
            // 
            // lblNoms
            // 
            this.lblNoms.AutoSize = true;
            this.lblNoms.BackColor = System.Drawing.Color.Transparent;
            this.lblNoms.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblNoms.ForeColor = System.Drawing.Color.White;
            this.lblNoms.Location = new System.Drawing.Point(83, 6);
            this.lblNoms.Name = "lblNoms";
            this.lblNoms.Size = new System.Drawing.Size(0, 19);
            this.lblNoms.TabIndex = 242;
            // 
            // button10
            // 
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(495, 4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(36, 24);
            this.button10.TabIndex = 6;
            this.button10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button10.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.label4.Location = new System.Drawing.Point(249, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 304;
            this.label4.Text = "Couleur*";
            // 
            // txtcouleur
            // 
            this.txtcouleur.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcouleur.Location = new System.Drawing.Point(250, 215);
            this.txtcouleur.Name = "txtcouleur";
            this.txtcouleur.Size = new System.Drawing.Size(301, 24);
            this.txtcouleur.TabIndex = 303;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.label5.Location = new System.Drawing.Point(249, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 19);
            this.label5.TabIndex = 306;
            this.label5.Text = "Numéro de la Plaque*";
            // 
            // txtnumeroplaque
            // 
            this.txtnumeroplaque.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnumeroplaque.Location = new System.Drawing.Point(250, 264);
            this.txtnumeroplaque.Name = "txtnumeroplaque";
            this.txtnumeroplaque.Size = new System.Drawing.Size(301, 24);
            this.txtnumeroplaque.TabIndex = 305;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.label1.Location = new System.Drawing.Point(249, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 19);
            this.label1.TabIndex = 308;
            this.label1.Text = "Marque*";
            // 
            // txtMarque
            // 
            this.txtMarque.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarque.Location = new System.Drawing.Point(250, 167);
            this.txtMarque.Name = "txtMarque";
            this.txtMarque.Size = new System.Drawing.Size(301, 24);
            this.txtMarque.TabIndex = 307;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.label6.Location = new System.Drawing.Point(618, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 19);
            this.label6.TabIndex = 310;
            this.label6.Text = "Compte";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.label7.Location = new System.Drawing.Point(249, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 19);
            this.label7.TabIndex = 312;
            this.label7.Text = "Nombre de Place*";
            // 
            // txtnombrePlace
            // 
            this.txtnombrePlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombrePlace.Location = new System.Drawing.Point(250, 314);
            this.txtnombrePlace.Name = "txtnombrePlace";
            this.txtnombrePlace.Size = new System.Drawing.Size(301, 24);
            this.txtnombrePlace.TabIndex = 311;
            // 
            // txtCompte
            // 
            this.txtCompte.Enabled = false;
            this.txtCompte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompte.Location = new System.Drawing.Point(615, 167);
            this.txtCompte.Multiline = true;
            this.txtCompte.Name = "txtCompte";
            this.txtCompte.Size = new System.Drawing.Size(168, 72);
            this.txtCompte.TabIndex = 313;
            // 
            // frm_AddEngin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 585);
            this.Controls.Add(this.txtCompte);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtnombrePlace);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMarque);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtnumeroplaque);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtcouleur);
            this.Controls.Add(this.txtCategorie);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtnomPersonne);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_AddEngin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_AddEngin";
            this.Load += new System.EventHandler(this.frm_AddEngin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroComboBox txtCategorie;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnomPersonne;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelpatient;
        private System.Windows.Forms.Label lblNoms;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtcouleur;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtnumeroplaque;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMarque;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtnombrePlace;
        private System.Windows.Forms.TextBox txtCompte;
    }
}