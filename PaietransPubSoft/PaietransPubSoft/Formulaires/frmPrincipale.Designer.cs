namespace PaietransPubSoft
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDeconnexion = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAlerte = new System.Windows.Forms.Button();
            this.btnPersonnel = new System.Windows.Forms.Button();
            this.btnParametre = new System.Windows.Forms.Button();
            this.btnChauffeur = new System.Windows.Forms.Button();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.btnProprietaire = new System.Windows.Forms.Button();
            this.btnPassager = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.PanelPrincipal = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(34)))), ((int)(((byte)(44)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnDeconnexion);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1319, 100);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, System.Drawing.FontStyle.Italic);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(530, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 45);
            this.label1.TabIndex = 19;
            this.label1.Text = "TAP AND LEAVE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // btnDeconnexion
            // 
            this.btnDeconnexion.BackColor = System.Drawing.Color.Transparent;
            this.btnDeconnexion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnDeconnexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeconnexion.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnDeconnexion.ForeColor = System.Drawing.Color.LightCoral;
            this.btnDeconnexion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeconnexion.Location = new System.Drawing.Point(1102, 3);
            this.btnDeconnexion.Name = "btnDeconnexion";
            this.btnDeconnexion.Size = new System.Drawing.Size(151, 35);
            this.btnDeconnexion.TabIndex = 17;
            this.btnDeconnexion.Text = "Deconnexion";
            this.btnDeconnexion.UseVisualStyleBackColor = false;
            this.btnDeconnexion.Click += new System.EventHandler(this.btnDeconnexion_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = global::PaietransPubSoft.Properties.Resources.cancel_30px;
            this.button5.Location = new System.Drawing.Point(1271, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(39, 35);
            this.button5.TabIndex = 16;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(34)))), ((int)(((byte)(44)))));
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenu.Controls.Add(this.button1);
            this.panelMenu.Controls.Add(this.btnAlerte);
            this.panelMenu.Controls.Add(this.btnPersonnel);
            this.panelMenu.Controls.Add(this.btnParametre);
            this.panelMenu.Controls.Add(this.btnChauffeur);
            this.panelMenu.Controls.Add(this.SidePanel);
            this.panelMenu.Controls.Add(this.btnProprietaire);
            this.panelMenu.Controls.Add(this.btnPassager);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 100);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(168, 653);
            this.panelMenu.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(14, 437);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 55);
            this.button1.TabIndex = 20;
            this.button1.Text = "     Rapports";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnAlerte
            // 
            this.btnAlerte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnAlerte.FlatAppearance.BorderSize = 0;
            this.btnAlerte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlerte.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlerte.ForeColor = System.Drawing.Color.Transparent;
            this.btnAlerte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlerte.Location = new System.Drawing.Point(14, 375);
            this.btnAlerte.Name = "btnAlerte";
            this.btnAlerte.Size = new System.Drawing.Size(153, 55);
            this.btnAlerte.TabIndex = 19;
            this.btnAlerte.Text = "     Alerte";
            this.btnAlerte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlerte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlerte.UseVisualStyleBackColor = true;
            this.btnAlerte.Click += new System.EventHandler(this.btnRapport_Click_1);
            // 
            // btnPersonnel
            // 
            this.btnPersonnel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnPersonnel.FlatAppearance.BorderSize = 0;
            this.btnPersonnel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonnel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPersonnel.ForeColor = System.Drawing.Color.Transparent;
            this.btnPersonnel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPersonnel.Location = new System.Drawing.Point(14, 313);
            this.btnPersonnel.Name = "btnPersonnel";
            this.btnPersonnel.Size = new System.Drawing.Size(153, 55);
            this.btnPersonnel.TabIndex = 18;
            this.btnPersonnel.Text = "     Personnels";
            this.btnPersonnel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPersonnel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPersonnel.UseVisualStyleBackColor = true;
            this.btnPersonnel.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnParametre
            // 
            this.btnParametre.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnParametre.FlatAppearance.BorderSize = 0;
            this.btnParametre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParametre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParametre.ForeColor = System.Drawing.Color.Transparent;
            this.btnParametre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParametre.Location = new System.Drawing.Point(14, 499);
            this.btnParametre.Name = "btnParametre";
            this.btnParametre.Size = new System.Drawing.Size(147, 55);
            this.btnParametre.TabIndex = 17;
            this.btnParametre.Text = "     Paramétres";
            this.btnParametre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParametre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnParametre.UseVisualStyleBackColor = true;
            this.btnParametre.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnChauffeur
            // 
            this.btnChauffeur.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnChauffeur.FlatAppearance.BorderSize = 0;
            this.btnChauffeur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChauffeur.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChauffeur.ForeColor = System.Drawing.Color.Transparent;
            this.btnChauffeur.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChauffeur.Location = new System.Drawing.Point(14, 251);
            this.btnChauffeur.Name = "btnChauffeur";
            this.btnChauffeur.Size = new System.Drawing.Size(153, 55);
            this.btnChauffeur.TabIndex = 16;
            this.btnChauffeur.Text = "     Chauffeurs";
            this.btnChauffeur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChauffeur.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChauffeur.UseVisualStyleBackColor = true;
            this.btnChauffeur.Click += new System.EventHandler(this.btnRapport_Click);
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(175)))), ((int)(((byte)(207)))));
            this.SidePanel.Location = new System.Drawing.Point(2, 65);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(10, 55);
            this.SidePanel.TabIndex = 11;
            // 
            // btnProprietaire
            // 
            this.btnProprietaire.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnProprietaire.FlatAppearance.BorderSize = 0;
            this.btnProprietaire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProprietaire.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProprietaire.ForeColor = System.Drawing.Color.Transparent;
            this.btnProprietaire.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProprietaire.Location = new System.Drawing.Point(14, 189);
            this.btnProprietaire.Name = "btnProprietaire";
            this.btnProprietaire.Size = new System.Drawing.Size(153, 55);
            this.btnProprietaire.TabIndex = 14;
            this.btnProprietaire.Text = "     Propriétaires";
            this.btnProprietaire.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProprietaire.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProprietaire.UseVisualStyleBackColor = true;
            this.btnProprietaire.Click += new System.EventHandler(this.btnPaiement_Click);
            // 
            // btnPassager
            // 
            this.btnPassager.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnPassager.FlatAppearance.BorderSize = 0;
            this.btnPassager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassager.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPassager.ForeColor = System.Drawing.Color.Transparent;
            this.btnPassager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPassager.Location = new System.Drawing.Point(12, 127);
            this.btnPassager.Name = "btnPassager";
            this.btnPassager.Size = new System.Drawing.Size(153, 55);
            this.btnPassager.TabIndex = 12;
            this.btnPassager.Text = "     Passagers";
            this.btnPassager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPassager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPassager.UseVisualStyleBackColor = true;
            this.btnPassager.Click += new System.EventHandler(this.btnPersonnel_Click);
            // 
            // btnHome
            // 
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.Transparent;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(12, 65);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(153, 55);
            this.btnHome.TabIndex = 11;
            this.btnHome.Text = "     Accueil";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // PanelPrincipal
            // 
            this.PanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPrincipal.Location = new System.Drawing.Point(168, 100);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Size = new System.Drawing.Size(1151, 653);
            this.PanelPrincipal.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 753);
            this.Controls.Add(this.PanelPrincipal);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDeconnexion;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnParametre;
        private System.Windows.Forms.Button btnChauffeur;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Button btnProprietaire;
        private System.Windows.Forms.Button btnPassager;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnAlerte;
        private System.Windows.Forms.Button btnPersonnel;
        private System.Windows.Forms.Panel PanelPrincipal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

