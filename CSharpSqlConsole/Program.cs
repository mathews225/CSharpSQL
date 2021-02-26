using System;
using CSharpSQL;
using System.Linq;

namespace CSharpSqlConsole {
	class Program {
		static void Main(string[] args) {

			var conn = new Connection();
			conn.Connect("EdDb");

			var sctrl = new StudentsController(conn);
			var students = sctrl.GetAll();
			var mctrl = new MajorsController(conn);
			var majors = mctrl.GetAll();

			var sm = from s in students
							 join m in majors
							 on s.MajorId equals m.Id
							 select new {
								 s.Id,
								 Name = s.Firstname+" "+s.Lastname,
								 m.Description
							 };

			foreach (var s in sm) {
				Console.WriteLine($"{s.Id}\t{s.Name}\t{s.Description}");
			}


			#region hide

			// var studentController = new StudentsController(conn);
			// var majorController = new MajorsController(conn);
			// var classController = new ClassesController(conn);



			/*

			var majors = majorController.GetAll();
			foreach (var m in majors) {
				Console.WriteLine($"{m.Id}:\t {m.Description}\t {m.MinSAT}");
			}

			var newMajor = new Major {
				Id = 0,
				Code = "CRP",
				Description = "City and Regional Planning",
				MinSAT = 1200
			};

			var major = majorController.GetByPKey(6);
			Console.WriteLine($"{major.Id}:\t {major.Code}\t {major.Description}\t {major.MinSAT}");



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
			var newClass = new Class {
				Id = 0,
				Code = "MAT151",
				Subject = "Math",
				Section = 151,
				InstructorId = 8 
			};

			var insert = classController.Create(newClass);
			newClass.Id = 38;
			var success = classController.Update(newClass);

			var classes = classController.ReadAll();
			foreach (var c in classes) {
				Console.WriteLine($"{ c.Id}:\t {c.Code}, {c.Section}\t {c.InstructorId}\t {c.Subject}");
			}

			/*
			var insert = studentController.Create(newStudent);
			newStudent.Id = 61;
			var success = studentController.Update(newStudent);

			var cl = classController.GetByPKey(40);
			Console.WriteLine($"{ cl.Id}:\t {cl.Code}, {cl.Section}\t {cl.InstructorId}\t {cl.Subject}");

			*/

			/*

			success = studentController.Delete(61);
			Console.WriteLine($"Remove Success: {success}");

			success = studentController.DeleteRange(59,60);
			Console.WriteLine($"Remove Success: {success}");
			*/


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

			#endregion
			var xxcvbnm = 1;
		}
	}
}
