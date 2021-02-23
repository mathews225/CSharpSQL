using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSQL {
	public class Student {

		public int Id { get; set; }
		public string StateCode { get; set; }
		public string Lastname { get; set; }
		public string Firstname { get; set; }
		public decimal GPA { get; set; }
		public int SAT { get; set; }
		//public int? MajorId { get; set; } // int? allows int to be null
		public string Major { get; set; }

	}
}
