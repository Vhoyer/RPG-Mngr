namespace RpgMngr
{
    partial class frmMain
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
            this.cbSistema = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mspMain = new System.Windows.Forms.MenuStrip();
            this.tsmiRpgMngr = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewC = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenC = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRecentC = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpMesa = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeMesa = new System.Windows.Forms.TextBox();
            this.btnCriar = new System.Windows.Forms.Button();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mspMain.SuspendLayout();
            this.grpMesa.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbSistema
            // 
            this.cbSistema.DisplayMember = "SystemsSupported";
            this.cbSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSistema.FormattingEnabled = true;
            this.cbSistema.Location = new System.Drawing.Point(61, 55);
            this.cbSistema.Name = "cbSistema";
            this.cbSistema.Size = new System.Drawing.Size(121, 21);
            this.cbSistema.TabIndex = 0;
            this.cbSistema.ValueMember = "SystemsSupported";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sistema: ";
            // 
            // mspMain
            // 
            this.mspMain.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mspMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRpgMngr,
            this.editarToolStripMenuItem,
            this.visualizarToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.mspMain.Location = new System.Drawing.Point(0, 0);
            this.mspMain.Name = "mspMain";
            this.mspMain.Size = new System.Drawing.Size(734, 24);
            this.mspMain.TabIndex = 2;
            this.mspMain.Text = "menuStrip1";
            // 
            // tsmiRpgMngr
            // 
            this.tsmiRpgMngr.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewC,
            this.tsmiOpenC,
            this.tsmiRecentC,
            this.toolStripMenuItem1,
            this.tsmiQuit});
            this.tsmiRpgMngr.Name = "tsmiRpgMngr";
            this.tsmiRpgMngr.Size = new System.Drawing.Size(73, 20);
            this.tsmiRpgMngr.Text = "RPG Mngr";
            // 
            // tsmiNewC
            // 
            this.tsmiNewC.Name = "tsmiNewC";
            this.tsmiNewC.Size = new System.Drawing.Size(163, 22);
            this.tsmiNewC.Text = "Nova Campanha";
            // 
            // tsmiOpenC
            // 
            this.tsmiOpenC.Name = "tsmiOpenC";
            this.tsmiOpenC.Size = new System.Drawing.Size(163, 22);
            this.tsmiOpenC.Text = "Abrir Campanha";
            this.tsmiOpenC.Click += new System.EventHandler(this.abrirMesaToolStripMenuItem_Click);
            // 
            // tsmiRecentC
            // 
            this.tsmiRecentC.Name = "tsmiRecentC";
            this.tsmiRecentC.Size = new System.Drawing.Size(163, 22);
            this.tsmiRecentC.Text = "Recentes";
            this.tsmiRecentC.DropDownOpening += new System.EventHandler(this.tsmiRecentC_DropDownOpening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            // 
            // tsmiQuit
            // 
            this.tsmiQuit.Name = "tsmiQuit";
            this.tsmiQuit.Size = new System.Drawing.Size(163, 22);
            this.tsmiQuit.Text = "Sair";
            this.tsmiQuit.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.configuraçõesToolStripMenuItem});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // visualizarToolStripMenuItem
            // 
            this.visualizarToolStripMenuItem.Name = "visualizarToolStripMenuItem";
            this.visualizarToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.visualizarToolStripMenuItem.Text = "Visualizar";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.sobreToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(101, 6);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // grpMesa
            // 
            this.grpMesa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMesa.Controls.Add(this.label2);
            this.grpMesa.Controls.Add(this.txtNomeMesa);
            this.grpMesa.Controls.Add(this.btnCriar);
            this.grpMesa.Controls.Add(this.label1);
            this.grpMesa.Controls.Add(this.cbSistema);
            this.grpMesa.Location = new System.Drawing.Point(447, 27);
            this.grpMesa.Name = "grpMesa";
            this.grpMesa.Size = new System.Drawing.Size(275, 88);
            this.grpMesa.TabIndex = 3;
            this.grpMesa.TabStop = false;
            this.grpMesa.Text = "Nova Campanha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nome \r\nda campanha: ";
            // 
            // txtNomeMesa
            // 
            this.txtNomeMesa.Location = new System.Drawing.Point(88, 21);
            this.txtNomeMesa.Name = "txtNomeMesa";
            this.txtNomeMesa.Size = new System.Drawing.Size(181, 20);
            this.txtNomeMesa.TabIndex = 3;
            // 
            // btnCriar
            // 
            this.btnCriar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCriar.Location = new System.Drawing.Point(194, 53);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(75, 23);
            this.btnCriar.TabIndex = 2;
            this.btnCriar.Text = "Criar";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.configuraçõesToolStripMenuItem.Text = "Configurações...";
            this.configuraçõesToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(157, 6);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 441);
            this.Controls.Add(this.grpMesa);
            this.Controls.Add(this.mspMain);
            this.MainMenuStrip = this.mspMain;
            this.Name = "frmMain";
            this.Text = "RPG Mngr!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mspMain.ResumeLayout(false);
            this.mspMain.PerformLayout();
            this.grpMesa.ResumeLayout(false);
            this.grpMesa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSistema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip mspMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiRpgMngr;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewC;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenC;
        private System.Windows.Forms.ToolStripMenuItem tsmiRecentC;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuit;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpMesa;
        private System.Windows.Forms.Button btnCriar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeMesa;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
    }
}

