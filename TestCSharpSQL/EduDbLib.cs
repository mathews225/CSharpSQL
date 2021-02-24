using System;
using Microsoft.Data.SqlClient;

namespace CSharpSQL {
	public class EduDbLib {

		public SqlConnection connection { get; set; }

		public void SelectClass() {
			var classTbl = "SELECT * From Class;";
			var cmd = new SqlCommand(classTbl, connection);
			var reader = cmd.ExecuteReader();
			while (reader.Read()) {
				var Id = Convert.ToInt32(reader["Id"]);
				var Code = reader["Code"].ToString(); 
				var Subject = reader["Subject"].ToString(); 
				var Section = Convert.ToInt32(reader["Section"]);
				//var InstructorId = Convert.ToInt32(reader["InstuctorId"]);
				Console.WriteLine($"Id: {Id}\t Code: {Code}\t Section: {Section}\t Subject: {Subject}");
			};
			reader.Close();
		}

		public void SelectStudent() {
			var sql = "select * from Student;";
			var cmd = new SqlCommand(sql, connection);
			var reader = cmd.ExecuteReader();
			while (reader.Read()) {
				var StateCode = reader["StateCode"].ToString();
				var Lastname = reader["Lastname"].ToString();
				var Firstname = reader["Firstname"].ToString();
				var GPA = Convert.ToDecimal(reader["GPA"]);
				var SAT = Convert.ToInt32(reader["SAT"]);
				var MajorId = Convert.ToInt32(reader["MajorId"]);
				Console.WriteLine($" StateCode: {StateCode},\t Lastname: {Lastname},\t Firstname: {Firstname},\t GPA: {GPA},\t SAT: {SAT}");

				/*
				var description = reader["description"].ToString();
				Console.WriteLine($"id: {id},\tdescription: {description}");
				*/
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
