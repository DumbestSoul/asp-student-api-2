using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdntApi.Models.DTO
{
	public class StudentDto
	{
		public string Name { get; set; }
		public DateTime JoinDate { get; set; }
		public int Standard { get; set; }
	}
}
