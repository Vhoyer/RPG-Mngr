namespace RpgMngr
{
    partial class frmConfig
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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Load/Save");
            this.sptConfig = new System.Windows.Forms.SplitContainer();
            this.trvMenu = new System.Windows.Forms.TreeView();
            this.flpBackup = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.pnl1LoadeSave = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCdp = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.sptConfig)).BeginInit();
            this.sptConfig.Panel1.SuspendLayout();
            this.sptConfig.Panel2.SuspendLayout();
            this.sptConfig.SuspendLayout();
            this.flpBackup.SuspendLayout();
            this.pnl1LoadeSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // sptConfig
            // 
            this.sptConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptConfig.Location = new System.Drawing.Point(0, 0);
            this.sptConfig.Name = "sptConfig";
            // 
            // sptConfig.Panel1
            // 
            this.sptConfig.Panel1.Controls.Add(this.trvMenu);
            // 
            // sptConfig.Panel2
            // 
            this.sptConfig.Panel2.Controls.Add(this.flpBackup);
            this.sptConfig.Panel2.Controls.Add(this.pnl1LoadeSave);
            this.sptConfig.Size = new System.Drawing.Size(676, 417);
            this.sptConfig.SplitterDistance = 152;
            this.sptConfig.TabIndex = 0;
            // 
            // trvMenu
            // 
            this.trvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvMenu.Location = new System.Drawing.Point(0, 0);
            this.trvMenu.Name = "trvMenu";
            treeNode3.Name = "ndLoadeSave";
            treeNode3.Text = "Load/Save";
            this.trvMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.trvMenu.ShowRootLines = false;
            this.trvMenu.Size = new System.Drawing.Size(152, 417);
            this.trvMenu.TabIndex = 0;
            this.trvMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvCmenu_AfterSelect);
            // 
            // flpBackup
            // 
            this.flpBackup.Controls.Add(this.btnSalvar);
            this.flpBackup.Controls.Add(this.btnClose);
            this.flpBackup.Controls.Add(this.btnAplicar);
            this.flpBackup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpBackup.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpBackup.Location = new System.Drawing.Point(0, 373);
            this.flpBackup.Name = "flpBackup";
            this.flpBackup.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.flpBackup.Size = new System.Drawing.Size(520, 44);
            this.flpBackup.TabIndex = 4;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(427, 3);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(346, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Cancelar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(265, 3);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 23);
            this.btnAplicar.TabIndex = 2;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // pnl1LoadeSave
            // 
            this.pnl1LoadeSave.Controls.Add(this.button1);
            this.pnl1LoadeSave.Controls.Add(this.txtCdp);
            this.pnl1LoadeSave.Controls.Add(this.label1);
            this.pnl1LoadeSave.Location = new System.Drawing.Point(3, 3);
            this.pnl1LoadeSave.Name = "pnl1LoadeSave";
            this.pnl1LoadeSave.Size = new System.Drawing.Size(514, 367);
            this.pnl1LoadeSave.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pasta padrão para novas campanhas:";
            // 
            // txtCdp
            // 
            this.txtCdp.Location = new System.Drawing.Point(15, 32);
            this.txtCdp.Name = "txtCdp";
            this.txtCdp.Size = new System.Drawing.Size(403, 20);
            this.txtCdp.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(424, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Procurar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 417);
            this.Controls.Add(this.sptConfig);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(692, 456);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(692, 456);
            this.Name = "frmConfig";
            this.Text = "Configurações";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            this.sptConfig.Panel1.ResumeLayout(false);
            this.sptConfig.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptConfig)).EndInit();
            this.sptConfig.ResumeLayout(false);
            this.flpBackup.ResumeLayout(false);
            this.pnl1LoadeSave.ResumeLayout(false);
            this.pnl1LoadeSave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sptConfig;
        private System.Windows.Forms.TreeView trvMenu;
        private System.Windows.Forms.FlowLayoutPanel flpBackup;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Panel pnl1LoadeSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCdp;
        private System.Windows.Forms.FolderBrowserDialog fbd;
    }
}