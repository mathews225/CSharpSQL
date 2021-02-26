using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace CSharpSQL {
	public class StudentsController {

		/// <summary>
		///  Contains the Sql connection that every class will need.
		///  Must be passed to the constructor of the controller.
		/// </summary>
		private Connection connection { get; set; }
		public bool Create(Student student) {
			var sql = $"INSERT into Student "+
				" (StateCode, Lastname, Firstname, GPA, SAT) "+
				$"VALUES ('{student.StateCode}','{student.Lastname}','{student.Firstname}',{student.GPA},{student.SAT});";
			var cmd = new SqlCommand(sql, connection.sqlconnection); 
			var rowsAffected = cmd.ExecuteNonQuery();
			return (rowsAffected == 1);
		}
		public bool Update(Student student) {
			var sql = $"UPDATE Student Set "+
				" StateCode = @statecode, " +
				" Lastname = @lastname, " +
				" Firstname = @firstname, " +
				" GPA = @gpa, " +
				" SAT = @sat " +
				" WHERE Id = @id;";
			var cmd = new SqlCommand(sql, connection.sqlconnection);
			cmd.Parameters.AddWithValue ("@statecode", student.StateCode);
			cmd.Parameters.AddWithValue ("@lastname", student.Lastname);
			cmd.Parameters.AddWithValue ("@firstname", student.Firstname);
			cmd.Parameters.AddWithValue ("@gpa", student.GPA);
			cmd.Parameters.AddWithValue("@sat", student.SAT);
			cmd.Parameters.AddWithValue ("@id", student.Id);
			var recsAffected = cmd.ExecuteNonQuery();
			return (recsAffected == 1);
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
			reader.Close();
			return student;
		}
		public List<Student> GetAll() {
			var sql = "SELECT * From Student s ";
					//"LEFT JOIN Major m on s.MajorId = m.Id " +
					//"ORDER BY s.Lastname; ";
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
				student.MajorId = null;
				//if (reader["MajorId"] != null) {
				//	student.MajorId = Convert.ToInt32(reader["MajorId"]);
				//}
				if (reader["MajorId"] != System.DBNull.Value) {
					student.MajorId = Convert.ToInt32(reader["MajorId"]);
				}
				students.Add(student);
			}
			reader.Close();
			return students;
		}
		public bool Delete(int id) {
			var sql = $"DELETE From Student WHERE id = @id;";
			var cmd = new SqlCommand(sql, connection.sqlconnection);
			cmd.Parameters.AddWithValue("@id", id);
			var recsAffected = cmd.ExecuteNonQuery();
			return (recsAffected == 1);
		}
		public bool DeleteRange(params int[] ids) {
			var success = true;
			foreach (var id in ids) {
				success &= Delete(id);
			}
			return success;
		}
		public StudentsController(Connection connection) {
			this.connection = connection;
		}
	}
}