using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSQL {
	public class Connection {
		public SqlConnection sqlconnection { get; set; }

		public void Connect(string database) {
			var connStr = $"server=localhost\\sqlexpress;" +
				$"database={database};" +
				$"trusted_connection=true;";
			sqlconnection = new SqlConnection(connStr);
			sqlconnection.Open();
			if (sqlconnection.State != System.Data.ConnectionState.Open) {
				throw new Exception("Connection is not open! ...Or is it!?\n ...It's NOT!! You have messed something up!\n...Or someone that worked on this code messed up.");

			}
		}

		public void Disconnect() {
			sqlconnection.Close();
		}

	}
}
