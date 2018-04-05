using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesafioCompLine
{
    public partial class Pesquisar : Form
    {
        public Pesquisar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao = new SqlConnection("Integrated Security = SSPI; Persist Security Info=False;Initial Catalog = BDDesafio; Data Source = NATANAEL\\SQLSERVER14");

                SqlDataAdapter instrucao = new SqlDataAdapter("select * from Tbfuncionario where nome like '" + txtPesquisa.Text + "%'", conexao);

                DataTable tabela = new DataTable();

                instrucao.Fill(tabela);
                tabela.Columns[0].ColumnName = "nome";
                tabela.Columns[1].ColumnName = "sobrenome";
                tabela.Columns[2].ColumnName = "dtnasc";
                tabela.Columns[3].ColumnName = "email";
                tabela.Columns[4].ColumnName = "endereco";
                tabela.Columns[5].ColumnName = "salario";

                dataGridView1.DataSource = tabela;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection("Integrated Security = SSPI; Persist Security Info=False;Initial Catalog = BDDesafio; Data Source = NATANAEL\\SQLSERVER14");

            SqlCommand instrucao = new SqlCommand("delete from Tbfuncionario where nome=@nome", conexao);

            instrucao.Parameters.Add("@nome", SqlDbType.NChar).Value = txtPesquisa.Text;

            try
            {
                conexao.Open();
                instrucao.ExecuteNonQuery();
                MessageBox.Show("Funcionario Deletado!");
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                MessageBox.Show("Conexão Finalizada");
            }
        }
    }
}
