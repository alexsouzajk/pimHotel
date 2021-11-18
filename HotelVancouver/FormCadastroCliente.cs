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
    public partial class FormCadastroCliente : Form
    {
        public FormCadastroCliente()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = textBoxNome.Text;
            string rg = maskedTextBoxRg.Text.Replace(".","").Replace("-", "");
            string cpf = maskedTextBoxCpf.Text.Replace(".", "").Replace("-", "");
            string email = textBoxEmail.Text;
            string telefone = maskedTextBoxTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string dataNascimento = maskedTextBoxDataNascimento.Text;

            Conexao con = new Conexao();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO cliente(nome, rg, cpf_cnpj, email, telefone, data_nascimento) values(" +
                "@nome," +
                "@rg," +
                "@cpf," +
                "@email," +
                "@telefone," +
                "@dataNascimento" +
                ")";

            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@rg", rg);
            cmd.Parameters.AddWithValue("@cpf", cpf);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@telefone", telefone);
            cmd.Parameters.AddWithValue("@dataNascimento", dataNascimento);

            try {

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

        private void maskedTextBoxRg_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBoxCpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
