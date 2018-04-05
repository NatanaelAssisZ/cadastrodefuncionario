using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesafioCompLine
{
    public partial class Painel_Principal : Form
    {
        public Painel_Principal()
        {
            InitializeComponent();
        }

        private Form CadastroFunc;
       

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroFunc?.Close();

            CadastroFunc = new Cadastro_Funcionario
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            panel1.Controls.Add(CadastroFunc);
            CadastroFunc.Show();
        }

        private void Painel_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            var resultado = MessageBox.Show(this, "Você deseja realmente sair?", "Confirmação", MessageBoxButtons.YesNo);
            if(resultado != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void Painel_Principal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void funcionárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CadastroFunc?.Close();

            CadastroFunc = new Pesquisar
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            panel1.Controls.Add(CadastroFunc);
            CadastroFunc.Show();
        }
    }
}
