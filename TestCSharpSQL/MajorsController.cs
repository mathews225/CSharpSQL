using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Data.SqlClient;

namespace CSharpSQL {
	public class MajorsController {

		private Connection connection { get; set; }

		/*

	C  
		sql
		cmd
		affects
		return

		*/

		public bool Create(Major major) {
			var sql = $"INSERT into Major" +
			$"(Id,Code,Description,MinSAT)" +
			$"VALUES ({major.Id}, '{major.Code}', '{major.Description}', {major.MinSAT});";
			var cmd = new SqlCommand(sql, connection.sqlconnection);
			var rowsAffected = cmd.ExecuteNonQuery();
			return (rowsAffected == 1);
		}

		/*
		Id
		Code
		Description
		MinSAT
		*/




		/*

	R 
		type
		sql
		cmd
		read
		while
		close
		return

		*/

		public List<Major> GetAll() {
			var sql = $"SELECT * FROM Major;";
			var cmd = new SqlCommand(sql, connection.sqlconnection);
			var reader = cmd.ExecuteReader();
			var majors = new List<Major>();
			while (reader.Read()) {
				var major = new Major();
				major.Id = Convert.ToInt32(reader["Id"]);
				major.Code = reader["Code"].ToString();
				major.Description = reader["Description"].ToString();
				major.MinSAT = Convert.ToInt32(reader["MinSAT"]);
				// cmd.Parameters.AddWithValue("@id", major.Id);
				// cmd.Parameters.AddWithValue("@code", major.Code);
				// cmd.Parameters.AddWithValue("@description", major.Description);
				// cmd.Parameters.AddWithValue("@minsat", major.MinSAT);
				majors.Add(major);
			}
			reader.Close();
			return majors;
		}

		public Major GetByPKey(int id) {
			var sql = $"SELECT * From Major WHERE Id = {id};";
			var cmd = new SqlCommand(sql, connection.sqlconnection);
			var reader = cmd.ExecuteReader();
			var hasRow = reader.Read();
			if (!hasRow) { return null; }
			var major = new Major();
			major.Id = Convert.ToInt32(reader["Id"]);
			major.Code = reader["Code"].ToString();
			major.Description = reader["Description"].ToString();
			major.MinSAT = Convert.ToInt32(reader["MinSAT"]);
			reader.Close();
			return major;
		}

		/*

	U
		sql
		cmd
		para
		affect
		return

		*/

		public bool Update(Major major) {
			var sql = $"UPDATE Major Set " +
				$"Code  = @code,  " +
				$"Description  = @description,  " +
				$"MinSAT  = @minsat  " +
				$"WHERE Id  = @id;  ";
			var cmd = new SqlCommand(sql, connection.sqlconnection);
			cmd.Parameters.AddWithValue("@id", major.Id);
			cmd.Parameters.AddWithValue("@code", major.Code);
			cmd.Parameters.AddWithValue("@description", major.Description);
			cmd.Parameters.AddWithValue("@minsat", major.MinSAT);
			var recAffected = cmd.ExecuteNonQuery();
			return (recAffected == 1);
		}

		/*

	D
		sql
		cmd
		para
		affect
		return

	*/

		public bool Delete(int id) {
			var sql = $"DELETE FROM Major WHERE id = @id;";
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

		public MajorsController(Connection connection) {
			this.connection = connection;
		}

	}
}
