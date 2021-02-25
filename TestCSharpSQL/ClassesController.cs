using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Data.SqlClient;

namespace CSharpSQL {
	public class ClassesController {

		private Connection connection { get; set; }

		public bool Create(Class course) {
			var sql = $"INSERT into Class " +
				$"(Code, Subject, Section, InstructorID) " +
				$"VALUES(" + 
				$" '{course.Code}', " + 
				$" '{course.Subject}', " + 
				$" '{course.Section}', " + 
				$" {course.InstructorId});";
			var cmd = new SqlCommand(sql, connection.sqlconnection);
			var recAffected = cmd.ExecuteNonQuery();
			return (recAffected == 1);
		}

		public bool Update(Class course) {
			var sql = $"UPDATE Class SET " +
			" Code = @code, " +
			" Subject = @subject, " +
			" Section = @section, " +
			" InstructorId = @instructorid " +
			" WHERE Id = @id; ";
			var cmd = new SqlCommand(sql, connection.sqlconnection);
			cmd.Parameters.AddWithValue("@code", course.Code);
			cmd.Parameters.AddWithValue("@subject", course.Subject);
			cmd.Parameters.AddWithValue("@section", course.Section);
			cmd.Parameters.AddWithValue("@instructorid", course.InstructorId);
			cmd.Parameters.AddWithValue("@id", course.Id);
			var recAffected = cmd.ExecuteNonQuery();
			return (recAffected == 1);
		}

		public bool Delete(int id) {
			var sql = $"DELETE From Class WHERE Id = {id};";
			var cmd = new SqlCommand(sql, connection.sqlconnection);
			cmd.Parameters.AddWithValue("@id", id);
			var recAffected = cmd.ExecuteNonQuery();
			return (recAffected == 1);
		}



		public List<Class> ReadAll() {
			var sql = "SELECT * FROM Class";
			var cmd = new SqlCommand(sql, connection.sqlconnection);
			var reader = cmd.ExecuteReader();
			var classes = new List<Class>();
			while (reader.Read()) {
				var course = new Class();
				course.Id = Convert.ToInt32(reader["Id"]);
				course.Code = reader["Code"].ToString();
				course.Subject = reader["Subject"].ToString();
				course.Section = Convert.ToInt32(reader["Section"]);
				course.InstructorId = null;
				if (reader["InstructorId"] != System.DBNull.Value) {
					course.InstructorId = Convert.ToInt32(reader["InstructorId"]);
				}
				classes.Add(course);
			}
			reader.Close();
			return classes;
		}


		public Class GetByPK(int id) {
			var sql = $"SELECT * From Class WHERE Id = {id};";
			var cmd = new SqlCommand(sql, connection.sqlconnection);
			var reader = cmd.ExecuteReader();
			var hasRow = reader.Read();
			if (!hasRow) { return null; }
			var course = new Class();
			course.Id = Convert.ToInt32(reader["Id"]);
			course.Code = reader["Code"].ToString();
			course.Subject = reader["Subject"].ToString();
			course.Section = Convert.ToInt32(reader["Section"]);
			course.InstructorId = null;
			if (reader["InstructorId"] != System.DBNull.Value) {
				course.InstructorId = Convert.ToInt32(reader["InstructorId"]);
			}
			reader.Close();
			return course;
		}



		public ClassesController(Connection connection) {
			this.connection = connection;
		}


	}
}
