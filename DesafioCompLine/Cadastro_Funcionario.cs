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
    public partial class Cadastro_Funcionario : Form
    {
        public Cadastro_Funcionario()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            SqlConnection conexao = new SqlConnection("Integrated Security = SSPI; Persist Security Info=False;Initial Catalog = BDDesafio; Data Source = NATANAEL\\SQLSERVER14");

            SqlCommand instrucoes = new SqlCommand("insert into Tbfuncionario(nome,sobrenome,dtnasc,email,endereco,salario) values(@nome,@sobrenome,@dtnasc,@email,@endereco,@salario)", conexao);

            instrucoes.Parameters.Add("@Nome", SqlDbType.NChar).Value = txtNome.Text;
            instrucoes.Parameters.Add("@Sobrenome", SqlDbType.NChar).Value = txtSobrenome.Text;
            instrucoes.Parameters.Add("@DtNasc", SqlDbType.Date).Value = dateTimePicker1.Text;
            instrucoes.Parameters.Add("@Email", SqlDbType.NChar).Value = txtEmail.Text;
            instrucoes.Parameters.Add("@Endereco", SqlDbType.NChar).Value = txtEndereco.Text;
            instrucoes.Parameters.Add("@Salario", SqlDbType.Float).Value = txtSalario.Text;

            try
            {
                conexao.Open();
                instrucoes.ExecuteNonQuery();
                MessageBox.Show("Cadastro realizado com sucesso!!!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                MessageBox.Show("Conexão finalizada!");
            }
        }
    }
}

