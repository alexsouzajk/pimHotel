using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelVancouver
{
    public partial class FormLogin : Form
    {
        Thread nt = null;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void botaoEntrar_Click_1(object sender, EventArgs e)
        {
            var email = textBoxEmail.Text;
            var senha = textBoxSenha.Text;

            Conexao con = new Conexao();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;

            if (true)
            {
                this.Close();

                FormMenu menu = new FormMenu();

                nt = new Thread(novoForm);
                nt.SetApartmentState(ApartmentState.STA);
                nt.Start();
            }

            cmd.CommandText = "SELECT * FROM login WHERE login = @email AND senha = @senha";

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                cmd.Connection = con.conectar();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    this.Close();

                    nt = new Thread(novoForm);
                    nt.SetApartmentState(ApartmentState.STA);
                    nt.Start();
                }
                else
                {
                    MessageBox.Show("Email ou senha invalidos!");
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("ERRO AO REALIZAR LOGIN: " + ex.Message);

                MessageBox.Show("Erro ao realizar login!");
            }
            finally {
                if (reader != null) { reader.Close(); }
                con.desconectar();
            }
        }

        private void novoForm() {
            Application.Run(new FormMenu());
        }


    }
}
