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
    public partial class FormConsultarAcomodacao : Form
    {
        public FormConsultarAcomodacao()
        {
            InitializeComponent();
        }

        private void FormConsultarAcomodacao_Load(object sender, EventArgs e)
        {
            popularDataGrid();
        }

        private void popularDataGrid() {
            Conexao con = new Conexao();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT a.id"+
                ",cq.descricao" +
                ",cq.quantidade_camas" +
                ",a.numero" +
                ",a.andar" +
                ",a.ocupado " +
                "FROM acomodacao a " +
                "JOIN categoria_quarto cq " +
                "ON a.id_categoria_quarto = cq.id";

            try
            {
                cmd.Connection = con.conectar();

                reader = cmd.ExecuteReader();

                dataGrid.ColumnCount = 6;
                dataGrid.Columns[0].Name = "ID  ";
                dataGrid.Columns[1].Name = "Categoria";
                dataGrid.Columns[2].Name = "Camas";
                dataGrid.Columns[3].Name = "N° quarto";
                dataGrid.Columns[4].Name = "Andar";
                dataGrid.Columns[5].Name = "Ocupação";
                var rows = new List<string[]>();

                while (reader.Read())
                {
                    bool ocupado = reader.GetBoolean(reader.GetOrdinal("ocupado"));

                    string[] row1 = new string[] {
                        reader.GetInt32(reader.GetOrdinal("id")).ToString()
                        ,reader.GetString(reader.GetOrdinal("descricao"))
                        ,reader.GetInt32(reader.GetOrdinal("quantidade_camas")).ToString()
                        ,reader.GetInt32(reader.GetOrdinal("numero")).ToString()
                        ,reader.GetInt32(reader.GetOrdinal("andar")).ToString()
                        ,(ocupado ? "Ocupado" : "Livre")};

                    rows.Add(row1);
                }

                foreach (string[] rowArray in rows)
                {
                    this.dataGrid.Rows.Add(rowArray);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro ao buscar acomodações: " + ex.Message);
                MessageBox.Show("Erro ao buscar acomodações!");
            }
            finally
            {
                this.dataGrid.AllowUserToAddRows = false;
                con.desconectar();
            }
        }

    }
}
