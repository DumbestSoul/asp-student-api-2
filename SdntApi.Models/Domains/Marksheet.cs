using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdntApi.Models.Domains
{
	public class Marksheet
	{
        public int MarksheetId { get; set; }
		public int StudentId { get; set; }
		public string Subject { get; set; }
		public double TotalMarks { get; set; }
		public double ObtainedMarks { get; set; }

		public Student Student { get; set; }

	}
}
