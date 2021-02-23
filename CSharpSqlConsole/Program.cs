using System;
using CSharpSQL;

namespace CSharpSqlConsole {
	class Program {
		static void Main(string[] args) {

			var conn = new Connection();
			conn.Connect("EdDb");
			var studentController = new StudentsController(conn);

			var newStudent = new Student {
				Id = 0,
				Firstname = "Joseph",
				Lastname = "Biden",
				GPA = 3.5m,
				Major = null,
				SAT = 1300,
				StateCode = "PA"
			};

			/*
			var insert = studentController.Create(newStudent);
			*/

			newStudent.Id = 61;
			var success = studentController.Update(newStudent);


			var student = studentController.GetByPKey(61);
			Console.WriteLine($"{student.Id}, {student.Firstname} {student.Lastname}");

			/*
			
			var students = studentController.GetAll();
			foreach (var s in students) {
				Console.WriteLine($"{ s.Id}:\t {s.Lastname}\t {s.Major}");
			}

			*/

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
