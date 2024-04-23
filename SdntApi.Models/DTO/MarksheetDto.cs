using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdntApi.Models.DTO
{
	public class MarksheetDto
	{
		public int StudentId { get; set; }
		public string Subject { get; set; }
		public double TotalMarks { get; set; }
		public double ObtainedMarks { get; set; }
	}
}
