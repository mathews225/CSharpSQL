using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Data.SqlClient;

namespace CSharpSQL {
	public class StudentsController {

		private Connection connection { get; set; }


		public bool Create(Student student) {
			var sql = $"INSERT into Student "+
				" (StateCode, Lastname, Firstname, GPA, SAT) "+
				$"VALUES ('{student.StateCode}','{student.Lastname}','{student.Firstname}',{student.GPA},{student.SAT});";
			var cmd = new SqlCommand(sql, connection.sqlconnection);
			var rowsAffected = cmd.ExecuteNonQuery();
			return (rowsAffected == 1);
		}



		public Student GetByPKey(int id) {
			var sql = $"SELECT * From Student WHERE Id = {id};";
			var cmd = new SqlCommand(sql, connection.sqlconnection);
			var reader = cmd.ExecuteReader();
			var hasRow = reader.Read();
			if (!hasRow) { return null; }
			var student = new Student();
			student.Id = Convert.ToInt32(reader["Id"]);
			student.StateCode = reader["StateCode"].ToString();
			student.Lastname = reader["Lastname"].ToString();
			student.Firstname = reader["Firstname"].ToString();
			student.GPA = Convert.ToDecimal(reader["GPA"]);
			student.SAT = Convert.ToInt32(reader["SAT"]);
			//student.MajorId = null;
			//student.Major = null;
			//if (reader["MajorId"] != null) {
			//	student.MajorId = Convert.ToInt32(reader["MajorId"]);
			//}
			//if (reader["Description"] != System.DBNull.Value) {
			//	student.Major = reader["Description"].ToString();
			//}

			reader.Close();
			return student;
		}

		public List<Student> GetAll() {
			var sql = "SELECT * From Student s "+
					"LEFT JOIN Major m on s.MajorId = m.Id " +
					"ORDER BY s.Lastname; ";
			var cmd = new SqlCommand(sql, connection.sqlconnection);
			var reader = cmd.ExecuteReader();
			var students = new List<Student>();
			while (reader.Read()) {
				var student = new Student();
				student.Id = Convert.ToInt32(reader["Id"]);
				student.StateCode = reader["StateCode"].ToString();
				student.Lastname = reader["Lastname"].ToString();
				student.Firstname = reader["Firstname"].ToString();
				student.GPA = Convert.ToDecimal(reader["GPA"]);
				student.SAT = Convert.ToInt32(reader["SAT"]);
				//student.MajorId = null;
				student.Major = null;
				//if (reader["MajorId"] != null) {
				//	student.MajorId = Convert.ToInt32(reader["MajorId"]);
				//}
				if (reader["Description"] != System.DBNull.Value) {
					student.Major = reader["Description"].ToString();
				}
				students.Add(student);
			}
			reader.Close();
			return students;
		}

		public StudentsController(Connection connection) {
			this.connection = connection;
		}

	}
}
