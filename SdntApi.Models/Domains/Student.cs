using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdntApi.Models.Domains
{
	public class Student
	{
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public int Standard { get; set; }
    }
}
