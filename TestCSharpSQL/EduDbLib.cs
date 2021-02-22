using System;
using Microsoft.Data.SqlClient;

namespace CSharpSQL {
	public class EduDbLib {

		public SqlConnection connection { get; set; }

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
