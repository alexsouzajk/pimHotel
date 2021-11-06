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
    public partial class FormCadastroReservas : Form
    {
        public FormCadastroReservas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexao con = new Conexao();
            SqlCommand cmd = new SqlCommand();

            string cpf = maskedTextBoxCpf.Text.Replace(".", "").Replace("-", "");
            string acomodacao = comboBoxAcomodacao.SelectedItem.ToString().Substring(0, 4).Trim();
            string meioPagamento = comboBoxMeioPagamento.SelectedItem.ToString().Trim();
            DateTime dataCheckin = dateTimeCheckin.Value;
            DateTime dataCheckout = dateTimeCheckout.Value;


            cmd.CommandText = "INSERT INTO reservas(cpf_cliente, id_acomodacao, forma_pagamento, checkin, checkout) VALUES(" +
                "@cpf," +
                "@acomodacao," +
                "@meioPagamento," +
                "@dataCheckin," +
                "@dataCheckout" +
                ")";

            cmd.Parameters.AddWithValue("@cpf", cpf);
            cmd.Parameters.AddWithValue("@acomodacao", acomodacao);
            cmd.Parameters.AddWithValue("@meioPagamento", meioPagamento);
            cmd.Parameters.AddWithValue("@dataCheckin", dataCheckin);
            cmd.Parameters.AddWithValue("@dataCheckout", dataCheckout);

            cmd.Connection = con.conectar();

            cmd.ExecuteNonQuery();

            cmd.CommandText = "UPDATE acomodacao SET ocupado = 1 WHERE id = @id";

            cmd.Parameters.AddWithValue("@id", acomodacao);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Reserva cadastrada com sucesso");

            this.Close();

        }

        private void maskedTextBoxCpf_TextChanged(object sender, EventArgs e)
        {
            string cpf = maskedTextBoxCpf.Text;
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");
            cpf = cpf.Replace("_", "");
            cpf = cpf.Replace(" ", "");

            if (cpf.Length == 11)
            {
                buscaCliente(maskedTextBoxCpf.Text);
            }
        }

        private void FormCadastroReservas_Load(object sender, EventArgs e)
        {
            popularComboBoxAcomodacao();
            popularComboBoxMeioPagamento();
        }

        private void popularComboBoxMeioPagamento() {
            Conexao con = new Conexao();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM meio_pagamento";

            try
            {
                cmd.Connection = con.conectar();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string tipo = reader.GetString(reader.GetOrdinal("tipo"));
                    Int32 id = reader.GetInt32(reader.GetOrdinal("id"));

                    comboBoxMeioPagamento.Items.Add(tipo);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro ao buscar acomodacoes: " + ex.Message);
                MessageBox.Show("Erro ao buscar acomodacoes!");
            }
            finally
            {
                con.desconectar();
            }
        }

        private void popularComboBoxAcomodacao(){
            Conexao con = new Conexao();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT a.id, a.numero, a.andar, c.quantidade_camas, c.descricao FROM acomodacao a JOIN categoria_quarto c ON a.id_categoria_quarto = c.id WHERE ocupado = 0";

            try
            {
                cmd.Connection = con.conectar();

                reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    Int32 id = reader.GetInt32(reader.GetOrdinal("id"));
                    Int32 numero = reader.GetInt32(reader.GetOrdinal("numero"));
                    Int32 andar = reader.GetInt32(reader.GetOrdinal("andar"));
                    Int32 quantidadeCamas = reader.GetInt32(reader.GetOrdinal("quantidade_camas"));
                    string descricao = reader.GetString(reader.GetOrdinal("descricao"));

                    comboBoxAcomodacao.Items.Add(id + "    " + numero + " - " + andar + "° andar - " + descricao.ToUpper() + " - " + quantidadeCamas + " camas");
                }

            }catch (SqlException ex) {
                Console.WriteLine("Erro ao buscar acomodacoes: " + ex.Message);
                MessageBox.Show("Erro ao buscar acomodacoes!");
            }finally
            {
                con.desconectar();
            }
        }

        private void buscaCliente(string cpf)
        {

            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");

            Conexao con = new Conexao();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT TOP 1 * FROM cliente WHERE cpf_cnpj = @cpf";

            cmd.Parameters.AddWithValue("@cpf", cpf);

            try
            {
                Cliente cliente = new Cliente();

                cmd.Connection = con.conectar();

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    MessageBox.Show("Cliente encontrado!\nNome: " + reader.GetString(reader.GetOrdinal("nome")));
                }
                else
                {
                    MessageBox.Show("Cliente nao encontrado!\nAbrindo tela de cadastro de cliente.");
                    FormCadastroCliente formCliente = new FormCadastroCliente();
                    formCliente.Show();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro ao buscar cliente: " + ex.Message);
                MessageBox.Show("Erro ao buscar cliente!");
            }
            finally
            {
                con.desconectar();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormReservas().Show();
        }
    }
}
