using System;
using Microsoft.Data.SqlClient;

namespace CSharpSQL {
	public class EduDbLib {

		public SqlConnection connection { get; set; }

		public void ExecSelect() {
			var sql = "SELECT * From Student;";

			var cmd = new SqlCommand(sql, connection);
			var reader = cmd.ExecuteReader();
			while (reader.Read()) {
				var id = Convert.ToInt32(reader["Id"]);
				var lastname = reader["lastname"].ToString();
				Console.WriteLine($"id-{id},\tlastname={lastname}");
			}
			reader.Close();
		}



		public void Connect(string database) {
			var connStr = $"server=localhost\\sqlexpress;" +
				$"database={database};" +
				$"trusted_connection=true;";
			connection = new SqlConnection(connStr);
			connection.Open();
			if(connection.State != System.Data.ConnectionState.Open) {
				throw new Exception("Connection is not open! ...Or is it!? ...It isn't.");
			}
		}


		public void Disconnect() {
			connection.Close();
		}




	}
}
