namespace PaietransPubSoft.Formulaires
{
    partial class frm_SearchPersonne
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelpatient = new System.Windows.Forms.Label();
            this.lblNoms = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.labelpatient);
            this.panel1.Controls.Add(this.lblNoms);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 33);
            this.panel1.TabIndex = 11;
            // 
            // labelpatient
            // 
            this.labelpatient.AutoSize = true;
            this.labelpatient.BackColor = System.Drawing.Color.Transparent;
            this.labelpatient.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelpatient.ForeColor = System.Drawing.Color.White;
            this.labelpatient.Location = new System.Drawing.Point(98, 9);
            this.labelpatient.Name = "labelpatient";
            this.labelpatient.Size = new System.Drawing.Size(154, 19);
            this.labelpatient.TabIndex = 243;
            this.labelpatient.Text = "Recherche Personnel";
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
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 33);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(436, 466);
            this.gridControl1.TabIndex = 10;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            // 
            // frm_SearchPersonne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 500);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_SearchPersonne";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_SearchPersonne";
            this.Load += new System.EventHandler(this.frm_SearchPersonne_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelpatient;
        private System.Windows.Forms.Label lblNoms;
        private System.Windows.Forms.Button button10;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}