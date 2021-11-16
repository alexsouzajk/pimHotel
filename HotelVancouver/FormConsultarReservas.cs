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
    public partial class FormConsultarReservas : Form
    {
        public FormConsultarReservas()
        {
            InitializeComponent();
        }

        private void FormConsultarReservas_Load(object sender, EventArgs e)
        {
            popularDataGrid();
        }

        private void popularDataGrid() {
            Conexao con = new Conexao();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT r.id"
                + ",c.nome"
                + ",r.cpf_cliente"
                + ",cq.descricao"
                + ",r.forma_pagamento"
                + ",r.checkin"
                + ",r.checkout"
                + " FROM reservas r"
                + " JOIN cliente c"
                + " ON r.cpf_cliente = c.cpf_cnpj"
                + " JOIN acomodacao a"
                + " ON r.id_acomodacao = a.id"
                + " JOIN categoria_quarto cq"
                + " ON a.id_categoria_quarto = cq.id"
                + " WHERE a.ocupado = 1";

            try
            {
                cmd.Connection = con.conectar();

                reader = cmd.ExecuteReader();

                dataGrid.ColumnCount = 6;
                dataGrid.Columns[0].Name = "Nome Cliente";
                dataGrid.Columns[1].Name = "CPF Cliente";
                dataGrid.Columns[2].Name = "Quarto";
                dataGrid.Columns[3].Name = "Pagamento";
                dataGrid.Columns[4].Name = "Data check-in";
                dataGrid.Columns[5].Name = "Data check-out";
                var rows = new List<string[]>();

                while (reader.Read())
                {
                    /* DataGridViewRow row = (DataGridViewRow)this.dataGrid.Rows[0].Clone();
                    //row.Cells[0].Value = reader.GetInt32(reader.GetOrdinal("id"));
                    row.Cells[0].Value = reader.GetString(reader.GetOrdinal("nome"));
                    row.Cells[1].Value = formataCpf(reader.GetString(reader.GetOrdinal("cpf_cliente")));
                    row.Cells[2].Value = reader.GetString(reader.GetOrdinal("descricao"));
                    row.Cells[3].Value = reader.GetString(reader.GetOrdinal("forma_pagamento"));
                    row.Cells[4].Value = reader.GetDateTime(reader.GetOrdinal("checkin"));
                    row.Cells[5].Value = reader.GetDateTime(reader.GetOrdinal("checkout"));*/

                    string[] row1 = new string[] { //reader.GetInt32(reader.GetOrdinal("id")).ToString()
                        reader.GetString(reader.GetOrdinal("nome"))
                        ,formataCpf(reader.GetString(reader.GetOrdinal("cpf_cliente")))
                        ,reader.GetString(reader.GetOrdinal("descricao"))
                        ,reader.GetString(reader.GetOrdinal("forma_pagamento"))
                        ,reader.GetDateTime(reader.GetOrdinal("checkin")).ToString()
                        ,reader.GetDateTime(reader.GetOrdinal("checkout")).ToString()};

                    rows.Add(row1);
                }

                foreach (string[] rowArray in rows) {
                    this.dataGrid.Rows.Add(rowArray);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro ao buscar reservas: " + ex.Message);
                MessageBox.Show("Erro ao buscar reservas!");
            }
            finally
            {
                this.dataGrid.AllowUserToAddRows = false;
                con.desconectar();
            }
        }

        private string formataCpf(string cpf) {
            /*string parte1 = cpf.Substring(1, 3);
            string parte2 = cpf.Substring(4, 6);
            string parte3 = cpf.Substring(7, 9);
            string parte4 = cpf.Substring(10, 11);*/
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }

    }
}
