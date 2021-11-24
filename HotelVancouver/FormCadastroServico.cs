using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelVancouver
{
    public partial class FormCadastroServico : Form
    {
        public FormCadastroServico()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cnpj = textBoxCnpj.Text;
            string nome =  textBoxNome.Text;
            string servico = textBoxServico.Text;

            Conexao con = new Conexao();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO servico(nome, rg, cpf_cnpj, email, telefone, data_nascimento) values(" +
                "@nome," +
                "@rg," +
                "@cpf," +
                "@email," +
                "@telefone," +
                "@dataNascimento" +
                ")";

            cmd.Parameters.AddWithValue("@nome", nome);

            try
            {

                cmd.Connection = con.conectar();

                cmd.ExecuteNonQuery();

                MessageBox.Show("Cliente dastrado com sucesso!");

                this.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro ao cadastrar cliente: " + ex.Message);
                MessageBox.Show("Erro ao cadastrar cliente!");
            }
            finally
            {
                con.desconectar();
            }
        }
    }
}
