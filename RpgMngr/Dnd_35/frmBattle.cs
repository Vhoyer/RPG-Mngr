using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RpgMngr.Dnd_35
{
    public partial class frmBattle : Form
    {
        DataTable EntityTable = new DataTable();
        DataTable BattleTable = new DataTable("battle");

        public frmBattle()
        {
            InitializeComponent();
            EntityTable.Columns.AddRange(new DataColumn[] 
            {
                new DataColumn("Nome", typeof(string)),
                new DataColumn("Iniciativa", typeof(int)),
                new DataColumn("Hp", typeof(int)),
                new DataColumn("CA", typeof(int)),
            });
            dgvEntities.DataSource = EntityTable;

            #region "configBoxControls"
            boxBtnAtacar.Click += new System.EventHandler(boxBtnAtacar_Click);
            flp.Controls.Add(boxBtnAtacar);
            boxFrm.Controls.Add(lblText);
            boxFrm.Controls.Add(lblDano);
            boxFrm.Controls.Add(boxNumDano);
            boxFrm.Controls.Add(flp);
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                EntityTable.Rows.Add(textBox1.Text, nudIni.Value, nudHp.Value, nudCa.Value);
                textBox1.Text = "";
                nudIni.Value = 0;
                nudHp.Value = 0;
                nudCa.Value = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer soundDice = new System.Media.SoundPlayer(Properties.Resources.dices);
            soundDice.Play();
            btnEndAction.Enabled = true;
            btnBattleStart.Enabled = false;
            btnAdd.Enabled = false;

            Random rnd = new Random();
            BattleTable.Reset();
            BattleTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Nome", typeof(string)),
                new DataColumn("Iniciativa_Total", typeof(int)),
                new DataColumn("Hp", typeof(int)),
                new DataColumn("CA", typeof(int))
            });

            for (int i = 0; i < EntityTable.Rows.Count; i++)
            {
                int d20 = rnd.Next(20) + 1;

                int iniTotal = Convert.ToInt32(EntityTable.Rows[i]["Iniciativa"].ToString()) + d20;
                string nome = EntityTable.Rows[i]["Nome"].ToString();
                int hp = Convert.ToInt32(EntityTable.Rows[i]["Hp"].ToString());
                int CA = Convert.ToInt32(EntityTable.Rows[i]["CA"].ToString());

                BattleTable.Rows.Add(nome, iniTotal, hp, CA);
            }

            List<string> lst = new List<string>();
            List<string> lst2 = new List<string>();
            List<int> valor = new List<int>();

            foreach (DataRow row in BattleTable.Rows)
            {
                lst2.Add(row[0].ToString());
                valor.Add(int.Parse(row[1].ToString()));
            }
            int l = valor.Count;
            for (int i = 0; i < l; i++)
            {
                int index = valor.IndexOf(valor.Max());
                lst.Add(i + 1 + ". " + lst2[index]);
                lst2.RemoveAt(index);
                valor.RemoveAt(index);
            }

            dgvEntities.DataSource = BattleTable;
            lstActionOrder.DataSource = lst;
            dgvEntities.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> lst = new List<string>();
            foreach (string str in lstActionOrder.Items)
            {
                lst.Add(str.Split('.')[str.Split('.').Length - 1].Remove(0, 1));
            }
            string firstToLast = lst[0];
            lst.RemoveAt(0);
            lst.Add(firstToLast);

            int l = lst.Count;
            for (int i = 0; i < l; i++)
            {
                lst[i] = i + 1 + ". " + lst[i];
            }

            lstActionOrder.DataSource = lst;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ctxDataGrid.Show(MousePosition);
        }
        int valorAtk;
        #region "spawnBox"
        NumericUpDown boxNumDano = new NumericUpDown()
        {
            Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right))),
            Location = new System.Drawing.Point(266, 12),
            Size = new System.Drawing.Size(66, 20),
            Minimum = -100,
            TabIndex = 1
        };
        Button boxBtnAtacar = new Button()
        {
            Location = new System.Drawing.Point(266, 3),
            Size = new System.Drawing.Size(75, 23),
            TabIndex = 0,
            Text = "Ok",
            UseVisualStyleBackColor = true,
        };
        FlowLayoutPanel flp = new FlowLayoutPanel()
        {
            Dock = System.Windows.Forms.DockStyle.Bottom,
            FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft,
            Location = new System.Drawing.Point(0, 76),
            Size = new System.Drawing.Size(344, 35),
            TabIndex = 0
        };
        Label lblDano = new Label()
        {
            Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right))),
            Location = new System.Drawing.Point(263, 35),
            Size = new System.Drawing.Size(69, 38),
            TabIndex = 2,
            Text = "Dano/Cura da ação"
        };
        Label lblText = new Label()
        {
            Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right))),
            Location = new System.Drawing.Point(13, 12),
            Size = new System.Drawing.Size(244, 61),
            TabIndex = 3,
            Text = "Um número positivo performa uma ação de ataque, reduzindo os pontos de vida do alvo, já um número negativo, performa uma ação de cura, aumentando os pontos de vida do alvo"
        };
        Form boxFrm = new Form()
        {
            Text = "Atacar!",
            Size = new Size(360, 150),
            AutoScaleDimensions = new SizeF(6F, 13F),
            AutoScaleMode = AutoScaleMode.Font,
            MaximizeBox = false,
            MinimizeBox = false,
            FormBorderStyle = FormBorderStyle.FixedSingle,
            ClientSize = new Size(344, 111)
        };
        #endregion

        private void boxBtnAtacar_Click(object sender, EventArgs e)
        {
            valorAtk = Convert.ToInt32(boxNumDano.Value);

            boxFrm.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void atacarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((dgvEntities.DataSource as DataTable).TableName == "battle")
            {
                int hp;
                int.TryParse(dgvEntities.CurrentRow.Cells["Hp"].Value.ToString(), out hp);

                boxFrm.ShowDialog();

                dgvEntities.CurrentRow.Cells["Hp"].Value = hp - valorAtk;
                valorAtk = 0;
            }
            else
            {
                MessageBox.Show("Inicie a batalha primeiro", "Falha");
            }
        }

        private void realizarAtaqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(new NotImplementedException().Message);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void matarRemoverDaTableaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (dgvEntities.DataSource as DataTable).Rows.RemoveAt(dgvEntities.CurrentRow.Index);
        }

        private void editarCélulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvEntities.BeginEdit(true);
        }

        private void restaurarBatalhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnBattleStart.Enabled = true;
            btnEndAction.Enabled = false;
            btnAdd.Enabled = true;
            lstActionOrder.DataSource = null;
            dgvEntities.DataSource = EntityTable;
        }

        private void finalizarBatalhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnBattleStart.Enabled = true;
            btnEndAction.Enabled = false;
            btnAdd.Enabled = true;
            lstActionOrder.DataSource = null;

            for (int i = 0; i < EntityTable.Rows.Count; i++)
            {
                EntityTable.Rows[i]["Hp"] = BattleTable.Rows[i]["Hp"];
            }
            dgvEntities.DataSource = EntityTable;
        }
    }
}
