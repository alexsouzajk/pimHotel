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
    public partial class FormConsultarClientes : Form
    {
        public FormConsultarClientes()
        {
            InitializeComponent();
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormConsultarClientes_Load(object sender, EventArgs e)
        {
            popularDataGrid();
        }

        private void popularDataGrid()
        {
            Conexao con = new Conexao();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT TOP(1000)[nome]"+
            ",[rg]" +
            ",[cpf_cnpj]" +
            ",[data_nascimento]" +
            ",[email]" +
            ",[telefone]" +
            "FROM[hotelaria].[dbo].[cliente]";

            try
            {
                cmd.Connection = con.conectar();

                reader = cmd.ExecuteReader();

                dataGrid.ColumnCount = 6;
                dataGrid.Columns[0].Name = "Nome Cliente";
                dataGrid.Columns[1].Name = "RG  ";
                dataGrid.Columns[2].Name = "CPF Cliente";
                dataGrid.Columns[3].Name = "Data de nascimento";
                dataGrid.Columns[4].Name = "Email";
                dataGrid.Columns[5].Name = "telefone";
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
                        ,reader.GetString(reader.GetOrdinal("rg"))
                        ,reader.GetString(reader.GetOrdinal("cpf_cnpj"))
                        ,reader.GetDateTime(reader.GetOrdinal("data_nascimento")).ToString()
                        ,reader.GetString(reader.GetOrdinal("email"))
                        ,reader.GetString(reader.GetOrdinal("telefone"))};

                    rows.Add(row1);
                }

                foreach (string[] rowArray in rows)
                {
                    this.dataGrid.Rows.Add(rowArray);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro ao buscar clientes: " + ex.Message);
                MessageBox.Show("Erro ao buscar clientes!");
            }
            finally
            {
                this.dataGrid.AllowUserToAddRows = false;
                con.desconectar();
            }
        }
    }
}
