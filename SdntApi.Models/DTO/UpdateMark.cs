using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdntApi.Models.DTO
{
	public class UpdateMark
	{
		public int MarksheetId { get; set; }
		public double UpdatedMarks { get; set; }
	}
}
