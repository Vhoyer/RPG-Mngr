namespace RpgMngr.Dnd_35
{
    partial class frmBattle
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.batalhaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batalharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finalizarBatalhaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.restaurarBatalhaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvEntities = new System.Windows.Forms.DataGridView();
            this.grpAdd = new System.Windows.Forms.GroupBox();
            this.nudCa = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudHp = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudIni = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBattleStart = new System.Windows.Forms.Button();
            this.lstActionOrder = new System.Windows.Forms.ListBox();
            this.btnEndAction = new System.Windows.Forms.Button();
            this.ctxDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.atacarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realizarAtaqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.editarCélulaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.matarRemoverDaTableaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nudNd = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntities)).BeginInit();
            this.grpAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIni)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.ctxDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNd)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.batalhaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MinimumSize = new System.Drawing.Size(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // batalhaToolStripMenuItem
            // 
            this.batalhaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.batalharToolStripMenuItem,
            this.finalizarBatalhaToolStripMenuItem,
            this.toolStripMenuItem4,
            this.restaurarBatalhaToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
            this.batalhaToolStripMenuItem.Name = "batalhaToolStripMenuItem";
            this.batalhaToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.batalhaToolStripMenuItem.Text = "Batalha";
            // 
            // batalharToolStripMenuItem
            // 
            this.batalharToolStripMenuItem.Name = "batalharToolStripMenuItem";
            this.batalharToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.batalharToolStripMenuItem.Text = "Batalhar";
            // 
            // finalizarBatalhaToolStripMenuItem
            // 
            this.finalizarBatalhaToolStripMenuItem.Name = "finalizarBatalhaToolStripMenuItem";
            this.finalizarBatalhaToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.finalizarBatalhaToolStripMenuItem.Text = "Finalizar Batalha";
            this.finalizarBatalhaToolStripMenuItem.Click += new System.EventHandler(this.finalizarBatalhaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(159, 6);
            // 
            // restaurarBatalhaToolStripMenuItem
            // 
            this.restaurarBatalhaToolStripMenuItem.Name = "restaurarBatalhaToolStripMenuItem";
            this.restaurarBatalhaToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.restaurarBatalhaToolStripMenuItem.Text = "Cancelar Batalha";
            this.restaurarBatalhaToolStripMenuItem.Click += new System.EventHandler(this.restaurarBatalhaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(159, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.AutoSize = true;
            this.btnAdd.Location = new System.Drawing.Point(425, 58);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvEntities
            // 
            this.dgvEntities.AllowUserToAddRows = false;
            this.dgvEntities.AllowUserToDeleteRows = false;
            this.dgvEntities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEntities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntities.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEntities.Location = new System.Drawing.Point(11, 133);
            this.dgvEntities.Name = "dgvEntities";
            this.dgvEntities.Size = new System.Drawing.Size(507, 261);
            this.dgvEntities.TabIndex = 3;
            this.dgvEntities.TabStop = false;
            this.dgvEntities.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // grpAdd
            // 
            this.grpAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAdd.Controls.Add(this.btnAdd);
            this.grpAdd.Controls.Add(this.flowLayoutPanel2);
            this.grpAdd.Location = new System.Drawing.Point(12, 39);
            this.grpAdd.Name = "grpAdd";
            this.grpAdd.Size = new System.Drawing.Size(506, 88);
            this.grpAdd.TabIndex = 4;
            this.grpAdd.TabStop = false;
            this.grpAdd.Text = "Adicionar Inimigo";
            // 
            // nudCa
            // 
            this.nudCa.Location = new System.Drawing.Point(6, 4);
            this.nudCa.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudCa.Name = "nudCa";
            this.nudCa.Size = new System.Drawing.Size(66, 20);
            this.nudCa.TabIndex = 4;
            this.nudCa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "CA";
            // 
            // nudHp
            // 
            this.nudHp.Location = new System.Drawing.Point(3, 3);
            this.nudHp.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudHp.Name = "nudHp";
            this.nudHp.Size = new System.Drawing.Size(83, 20);
            this.nudHp.TabIndex = 3;
            this.nudHp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ponto de vida";
            // 
            // nudIni
            // 
            this.nudIni.Location = new System.Drawing.Point(3, 3);
            this.nudIni.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudIni.Name = "nudIni";
            this.nudIni.Size = new System.Drawing.Size(69, 20);
            this.nudIni.TabIndex = 2;
            this.nudIni.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "iniciativa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome do Personagem";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnBattleStart);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 400);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(734, 41);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // btnBattleStart
            // 
            this.btnBattleStart.Location = new System.Drawing.Point(636, 3);
            this.btnBattleStart.Name = "btnBattleStart";
            this.btnBattleStart.Size = new System.Drawing.Size(75, 23);
            this.btnBattleStart.TabIndex = 0;
            this.btnBattleStart.Text = "Batalhar";
            this.btnBattleStart.UseVisualStyleBackColor = true;
            this.btnBattleStart.Click += new System.EventHandler(this.button2_Click);
            // 
            // lstActionOrder
            // 
            this.lstActionOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstActionOrder.FormattingEnabled = true;
            this.lstActionOrder.Location = new System.Drawing.Point(524, 39);
            this.lstActionOrder.Name = "lstActionOrder";
            this.lstActionOrder.Size = new System.Drawing.Size(198, 225);
            this.lstActionOrder.TabIndex = 6;
            this.lstActionOrder.TabStop = false;
            // 
            // btnEndAction
            // 
            this.btnEndAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEndAction.AutoSize = true;
            this.btnEndAction.Enabled = false;
            this.btnEndAction.Location = new System.Drawing.Point(640, 270);
            this.btnEndAction.Name = "btnEndAction";
            this.btnEndAction.Size = new System.Drawing.Size(82, 23);
            this.btnEndAction.TabIndex = 7;
            this.btnEndAction.Text = "Finalizar ação";
            this.btnEndAction.UseVisualStyleBackColor = true;
            this.btnEndAction.Click += new System.EventHandler(this.button3_Click);
            // 
            // ctxDataGrid
            // 
            this.ctxDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atacarToolStripMenuItem,
            this.realizarAtaqueToolStripMenuItem,
            this.toolStripMenuItem2,
            this.editarCélulaToolStripMenuItem,
            this.toolStripMenuItem3,
            this.matarRemoverDaTableaToolStripMenuItem});
            this.ctxDataGrid.Name = "ctxDataGrid";
            this.ctxDataGrid.Size = new System.Drawing.Size(173, 104);
            // 
            // atacarToolStripMenuItem
            // 
            this.atacarToolStripMenuItem.Name = "atacarToolStripMenuItem";
            this.atacarToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.atacarToolStripMenuItem.Text = "Atacar/Curar";
            this.atacarToolStripMenuItem.Click += new System.EventHandler(this.atacarToolStripMenuItem_Click);
            // 
            // realizarAtaqueToolStripMenuItem
            // 
            this.realizarAtaqueToolStripMenuItem.Name = "realizarAtaqueToolStripMenuItem";
            this.realizarAtaqueToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.realizarAtaqueToolStripMenuItem.Text = "Realizar Ataque";
            this.realizarAtaqueToolStripMenuItem.Click += new System.EventHandler(this.realizarAtaqueToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(169, 6);
            // 
            // editarCélulaToolStripMenuItem
            // 
            this.editarCélulaToolStripMenuItem.Name = "editarCélulaToolStripMenuItem";
            this.editarCélulaToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.editarCélulaToolStripMenuItem.Text = "Editar Célula";
            this.editarCélulaToolStripMenuItem.Click += new System.EventHandler(this.editarCélulaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(169, 6);
            // 
            // matarRemoverDaTableaToolStripMenuItem
            // 
            this.matarRemoverDaTableaToolStripMenuItem.Name = "matarRemoverDaTableaToolStripMenuItem";
            this.matarRemoverDaTableaToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.matarRemoverDaTableaToolStripMenuItem.Text = "Remover da tabela";
            this.matarRemoverDaTableaToolStripMenuItem.Click += new System.EventHandler(this.matarRemoverDaTableaToolStripMenuItem_Click);
            // 
            // nudNd
            // 
            this.nudNd.Location = new System.Drawing.Point(118, 3);
            this.nudNd.Name = "nudNd";
            this.nudNd.Size = new System.Drawing.Size(66, 20);
            this.nudNd.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Nível de Difículdade:";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.panel1);
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Controls.Add(this.panel3);
            this.flowLayoutPanel2.Controls.Add(this.panel4);
            this.flowLayoutPanel2.Controls.Add(this.panel5);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(6, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(494, 66);
            this.flowLayoutPanel2.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 42);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nudIni);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(174, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(79, 42);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.nudHp);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(253, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(91, 42);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nudCa);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(344, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(78, 42);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.nudNd);
            this.panel5.Location = new System.Drawing.Point(0, 42);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(190, 28);
            this.panel5.TabIndex = 4;
            // 
            // frmBattle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 441);
            this.Controls.Add(this.btnEndAction);
            this.Controls.Add(this.lstActionOrder);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.grpAdd);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dgvEntities);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(680, 365);
            this.Name = "frmBattle";
            this.Text = "RPG Mngr! - Batalha";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntities)).EndInit();
            this.grpAdd.ResumeLayout(false);
            this.grpAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIni)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ctxDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudNd)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvEntities;
        private System.Windows.Forms.GroupBox grpAdd;
        private System.Windows.Forms.NumericUpDown nudCa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudHp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudIni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnBattleStart;
        private System.Windows.Forms.ListBox lstActionOrder;
        private System.Windows.Forms.Button btnEndAction;
        private System.Windows.Forms.ContextMenuStrip ctxDataGrid;
        private System.Windows.Forms.ToolStripMenuItem atacarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realizarAtaqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batalhaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batalharToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restaurarBatalhaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem matarRemoverDaTableaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarCélulaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem finalizarBatalhaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudNd;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}