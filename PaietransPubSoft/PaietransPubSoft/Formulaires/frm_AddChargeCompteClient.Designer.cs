namespace PaietransPubSoft.Formulaires
{
    partial class frm_AddChargeCompteClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AddChargeCompteClient));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.labelpatient = new System.Windows.Forms.Label();
            this.lblNoms = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtmontant = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdate = new DevExpress.XtraEditors.DateEdit();
            this.txtnomClient = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.panel1.TabIndex = 13;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.label4.Location = new System.Drawing.Point(270, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 19);
            this.label4.TabIndex = 370;
            this.label4.Text = "Montant*";
            // 
            // txtmontant
            // 
            this.txtmontant.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmontant.Location = new System.Drawing.Point(266, 144);
            this.txtmontant.Name = "txtmontant";
            this.txtmontant.Size = new System.Drawing.Size(397, 24);
            this.txtmontant.TabIndex = 369;
            this.txtmontant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmontant_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.label3.Location = new System.Drawing.Point(270, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 368;
            this.label3.Text = "Client*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.label2.Location = new System.Drawing.Point(265, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 367;
            this.label2.Text = "Date*";
            // 
            // txtdate
            // 
            this.txtdate.EditValue = null;
            this.txtdate.Location = new System.Drawing.Point(266, 199);
            this.txtdate.Name = "txtdate";
            this.txtdate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdate.Properties.Appearance.Options.UseFont = true;
            this.txtdate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtdate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtdate.Size = new System.Drawing.Size(397, 24);
            this.txtdate.TabIndex = 366;
            // 
            // txtnomClient
            // 
            this.txtnomClient.Enabled = false;
            this.txtnomClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnomClient.Location = new System.Drawing.Point(266, 95);
            this.txtnomClient.Name = "txtnomClient";
            this.txtnomClient.Size = new System.Drawing.Size(397, 24);
            this.txtnomClient.TabIndex = 365;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(126)))));
            this.button1.Location = new System.Drawing.Point(266, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(390, 34);
            this.button1.TabIndex = 364;
            this.button1.Text = "Enregistrer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.Location = new System.Drawing.Point(0, 338);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(916, 237);
            this.gridControl1.TabIndex = 373;
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
            // frm_AddChargeCompteClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 575);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtmontant);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtdate);
            this.Controls.Add(this.txtnomClient);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_AddChargeCompteClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_AddChargeCompteClient";
            this.Load += new System.EventHandler(this.frm_AddChargeCompteClient_Load);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtmontant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit txtdate;
        private System.Windows.Forms.TextBox txtnomClient;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}