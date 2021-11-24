using System;
using System.Data.SqlClient;

public class Conexao
{
	SqlConnection con = new SqlConnection();

	public Conexao()
	{
		con.ConnectionString = @"Data Source=DESKTOP-UMA4OB1;Initial Catalog=hotelaria;Persist Security Info=True;User ID=sa;Password=12345678";
	}

	public SqlConnection conectar() {
		if (con.State == System.Data.ConnectionState.Closed) {
			con.Open();
		}

		return con;
	}

	public void desconectar()
	{
		if (con.State == System.Data.ConnectionState.Open)
		{
			con.Close();
		}
	}

}
