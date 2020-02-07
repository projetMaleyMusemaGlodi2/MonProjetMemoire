namespace PaietransPubSoft.uControl
{
    partial class ucParametrePrix
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucParametrePrix));
            this.label1 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.radioPrix = new System.Windows.Forms.RadioButton();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.panel13 = new System.Windows.Forms.Panel();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.gridCat = new System.Windows.Forms.DataGridView();
            this.label32 = new System.Windows.Forms.Label();
            this.simpleButton45 = new DevExpress.XtraEditors.SimpleButton();
            this.panel14.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.flowLayoutPanel11.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCat)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(976, 10);
            this.label1.TabIndex = 161;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel14
            // 
            this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel14.Controls.Add(this.radioPrix);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 10);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(976, 40);
            this.panel14.TabIndex = 162;
            // 
            // radioPrix
            // 
            this.radioPrix.AutoSize = true;
            this.radioPrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPrix.Location = new System.Drawing.Point(377, 5);
            this.radioPrix.Name = "radioPrix";
            this.radioPrix.Size = new System.Drawing.Size(195, 28);
            this.radioPrix.TabIndex = 7;
            this.radioPrix.TabStop = true;
            this.radioPrix.Text = "Paramétre du Prix";
            this.radioPrix.UseVisualStyleBackColor = true;
            this.radioPrix.CheckedChanged += new System.EventHandler(this.radioFonction_CheckedChanged);
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.flowLayoutPanel11);
            this.groupBox21.Controls.Add(this.panel13);
            this.groupBox21.Controls.Add(this.simpleButton45);
            this.groupBox21.Controls.Add(this.gridCat);
            this.groupBox21.Controls.Add(this.label32);
            this.groupBox21.Location = new System.Drawing.Point(42, 83);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(892, 487);
            this.groupBox21.TabIndex = 163;
            this.groupBox21.TabStop = false;
            // 
            // flowLayoutPanel11
            // 
            this.flowLayoutPanel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel11.Controls.Add(this.groupBox22);
            this.flowLayoutPanel11.Location = new System.Drawing.Point(118, 219);
            this.flowLayoutPanel11.Name = "flowLayoutPanel11";
            this.flowLayoutPanel11.Size = new System.Drawing.Size(620, 51);
            this.flowLayoutPanel11.TabIndex = 161;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.btnDelete);
            this.groupBox22.Controls.Add(this.btnSave);
            this.groupBox22.Controls.Add(this.btnUpdate);
            this.groupBox22.Location = new System.Drawing.Point(3, 3);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(606, 46);
            this.groupBox22.TabIndex = 0;
            this.groupBox22.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.BackColor = System.Drawing.Color.Maroon;
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Appearance.Options.UseBackColor = true;
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.btnDelete.Location = new System.Drawing.Point(412, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(155, 28);
            this.btnDelete.TabIndex = 153;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.BackColor = System.Drawing.Color.Teal;
            this.btnSave.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.btnSave.Location = new System.Drawing.Point(73, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(155, 28);
            this.btnSave.TabIndex = 152;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.BackColor = System.Drawing.Color.Teal;
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Appearance.Options.UseBackColor = true;
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.btnUpdate.Location = new System.Drawing.Point(240, 10);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(155, 28);
            this.btnUpdate.TabIndex = 151;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panel13
            // 
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel13.Controls.Add(this.txtID);
            this.panel13.Controls.Add(this.label31);
            this.panel13.Controls.Add(this.txtDesignation);
            this.panel13.Location = new System.Drawing.Point(6, 45);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(880, 168);
            this.panel13.TabIndex = 160;
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtID.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtID.Location = new System.Drawing.Point(301, 18);
            this.txtID.Multiline = true;
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(296, 28);
            this.txtID.TabIndex = 154;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(259, 54);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(39, 19);
            this.label31.TabIndex = 153;
            this.label31.Text = "Prix :";
            // 
            // txtDesignation
            // 
            this.txtDesignation.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtDesignation.Location = new System.Drawing.Point(301, 51);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(296, 24);
            this.txtDesignation.TabIndex = 155;
            this.txtDesignation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesignation_KeyPress);
            // 
            // gridCat
            // 
            this.gridCat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCat.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridCat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridCat.Location = new System.Drawing.Point(3, 345);
            this.gridCat.Name = "gridCat";
            this.gridCat.Size = new System.Drawing.Size(886, 139);
            this.gridCat.TabIndex = 158;
            this.gridCat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCat_CellClick);
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.Teal;
            this.label32.Dock = System.Windows.Forms.DockStyle.Top;
            this.label32.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label32.ForeColor = System.Drawing.Color.White;
            this.label32.Location = new System.Drawing.Point(3, 16);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(886, 20);
            this.label32.TabIndex = 150;
            this.label32.Text = "Parameters";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // simpleButton45
            // 
            this.simpleButton45.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.simpleButton45.Appearance.Options.UseFont = true;
            this.simpleButton45.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.simpleButton45.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton45.Image")));
            this.simpleButton45.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton45.Location = new System.Drawing.Point(118, 276);
            this.simpleButton45.Name = "simpleButton45";
            this.simpleButton45.Size = new System.Drawing.Size(620, 50);
            this.simpleButton45.TabIndex = 159;
            this.simpleButton45.Click += new System.EventHandler(this.simpleButton45_Click);
            // 
            // ucParametrePrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox21);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.label1);
            this.Name = "ucParametrePrix";
            this.Size = new System.Drawing.Size(976, 653);
            this.Load += new System.EventHandler(this.ucParametrePrix_Load);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.flowLayoutPanel11.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.RadioButton radioPrix;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel11;
        private System.Windows.Forms.GroupBox groupBox22;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtDesignation;
        private DevExpress.XtraEditors.SimpleButton simpleButton45;
        private System.Windows.Forms.DataGridView gridCat;
        private System.Windows.Forms.Label label32;
    }
}
