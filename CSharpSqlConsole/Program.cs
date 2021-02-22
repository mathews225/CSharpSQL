using System;
using CSharpSQL;

namespace CSharpSqlConsole {
	class Program {
		static void Main(string[] args) {

			var sql = new EduDbLib();
			sql.Connect("EdDb");
			Console.WriteLine("Con...\n   nect..\n\t.ion is..\n\t\t weak.\n\t\t\t...J/k the connection is fine.");
			sql.ExecSelect();
			sql.Disconnect();

		}
	}
}
