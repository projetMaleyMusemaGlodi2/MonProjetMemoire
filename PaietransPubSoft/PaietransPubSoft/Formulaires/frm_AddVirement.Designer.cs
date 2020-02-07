namespace PaietransPubSoft.Formulaires
{
    partial class frm_AddVirement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AddVirement));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.labelpatient = new System.Windows.Forms.Label();
            this.lblNoms = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnomChauffeur = new System.Windows.Forms.TextBox();
            this.txtlibelle = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtmontant = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdate = new DevExpress.XtraEditors.DateEdit();
            this.txtnomEngin = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtnomEnginDon = new System.Windows.Forms.TextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtdate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(916, 33);
            this.panel1.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(866, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 33);
            this.button2.TabIndex = 244;
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
            this.labelpatient.Location = new System.Drawing.Point(298, 8);
            this.labelpatient.Name = "labelpatient";
            this.labelpatient.Size = new System.Drawing.Size(202, 19);
            this.labelpatient.TabIndex = 243;
            this.labelpatient.Text = "Les Presences des Personnels";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.label1.Location = new System.Drawing.Point(263, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 393;
            this.label1.Text = "Chauffeur*";
            // 
            // txtnomChauffeur
            // 
            this.txtnomChauffeur.Enabled = false;
            this.txtnomChauffeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnomChauffeur.Location = new System.Drawing.Point(259, 107);
            this.txtnomChauffeur.Name = "txtnomChauffeur";
            this.txtnomChauffeur.Size = new System.Drawing.Size(565, 24);
            this.txtnomChauffeur.TabIndex = 392;
            // 
            // txtlibelle
            // 
            this.txtlibelle.Location = new System.Drawing.Point(261, 255);
            this.txtlibelle.Multiline = true;
            this.txtlibelle.Name = "txtlibelle";
            this.txtlibelle.Size = new System.Drawing.Size(397, 80);
            this.txtlibelle.TabIndex = 391;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.label16.Location = new System.Drawing.Point(259, 233);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 19);
            this.label16.TabIndex = 390;
            this.label16.Text = "Libellé*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.label4.Location = new System.Drawing.Point(265, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 19);
            this.label4.TabIndex = 389;
            this.label4.Text = "Montant*";
            // 
            // txtmontant
            // 
            this.txtmontant.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmontant.Location = new System.Drawing.Point(261, 206);
            this.txtmontant.Name = "txtmontant";
            this.txtmontant.Size = new System.Drawing.Size(397, 24);
            this.txtmontant.TabIndex = 388;
            this.txtmontant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmontant_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.label3.Location = new System.Drawing.Point(265, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 19);
            this.label3.TabIndex = 387;
            this.label3.Text = "Engin*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.label2.Location = new System.Drawing.Point(264, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 386;
            this.label2.Text = "Date*";
            // 
            // txtdate
            // 
            this.txtdate.EditValue = null;
            this.txtdate.Location = new System.Drawing.Point(261, 359);
            this.txtdate.Name = "txtdate";
            this.txtdate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdate.Properties.Appearance.Options.UseFont = true;
            this.txtdate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtdate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtdate.Size = new System.Drawing.Size(397, 24);
            this.txtdate.TabIndex = 385;
            // 
            // txtnomEngin
            // 
            this.txtnomEngin.Enabled = false;
            this.txtnomEngin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnomEngin.Location = new System.Drawing.Point(261, 60);
            this.txtnomEngin.Name = "txtnomEngin";
            this.txtnomEngin.Size = new System.Drawing.Size(563, 24);
            this.txtnomEngin.TabIndex = 384;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.button1.Location = new System.Drawing.Point(261, 413);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(397, 34);
            this.button1.TabIndex = 383;
            this.button1.Text = "Enregistrer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.Location = new System.Drawing.Point(0, 464);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(916, 205);
            this.gridControl1.TabIndex = 394;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.label5.Location = new System.Drawing.Point(263, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 19);
            this.label5.TabIndex = 396;
            this.label5.Text = "Engin donnateur*";
            // 
            // txtnomEnginDon
            // 
            this.txtnomEnginDon.Enabled = false;
            this.txtnomEnginDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnomEnginDon.Location = new System.Drawing.Point(259, 157);
            this.txtnomEnginDon.Name = "txtnomEnginDon";
            this.txtnomEnginDon.Size = new System.Drawing.Size(565, 24);
            this.txtnomEnginDon.TabIndex = 395;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new System.Drawing.Point(824, 150);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(33, 34);
            this.simpleButton1.TabIndex = 397;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frm_AddVirement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 669);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtnomEnginDon);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtnomChauffeur);
            this.Controls.Add(this.txtlibelle);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtmontant);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtdate);
            this.Controls.Add(this.txtnomEngin);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_AddVirement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_AddVirement";
            this.Load += new System.EventHandler(this.frm_AddVirement_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtdate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelpatient;
        private System.Windows.Forms.Label lblNoms;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnomChauffeur;
        private System.Windows.Forms.TextBox txtlibelle;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtmontant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit txtdate;
        private System.Windows.Forms.TextBox txtnomEngin;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtnomEnginDon;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}