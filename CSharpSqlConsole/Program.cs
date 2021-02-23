using System;
using CSharpSQL;

namespace CSharpSqlConsole {
	class Program {
		static void Main(string[] args) {

			var conn = new Connection();
			conn.Connect("EdDb");
			var studentController = new StudentsController(conn);

			var student = studentController.GetByPKey(3);
			Console.WriteLine($"{student.Id}, {student.Lastname}, {student.Firstname}");


			var students = studentController.GetAll();
			foreach (var s in students) {
				Console.WriteLine($"{ s.Id}:\t {s.Lastname}\t {s.Major}");
			}



			conn.Disconnect();

			/*
			var sql = new EduDbLib();
			sql.Connect("EdDb");
			Console.WriteLine("Con...\n   nect..\n\t.ion is..\n\t\t weak.\n\t\t\t...J/k the connection is fine.");
			sql.SelectStudent();
			// sql.SelectClass();
			sql.Disconnect();
			*/




		}
	}
}
