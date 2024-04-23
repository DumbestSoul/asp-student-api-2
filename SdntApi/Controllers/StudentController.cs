using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SdntApi.Business;
using SdntApi.Data;
using SdntApi.Models.DTO;

namespace SdntApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		public StudentBusiness bmo;
		public StudentController(SdntDbContext dbContext)
		{
			this.bmo = new StudentBusiness(dbContext);
		}

		/************************************************************
		 *						GET METHODS							*
		 ***********************************************************/
		[HttpGet("Students")]
		public IActionResult GetStudents() => Ok(bmo.GetStudents());

		[HttpGet("Students/{id}")]
		public IActionResult GetStudentById(int id)
		{
			var res = bmo.GetStudentById(id);
			if (res == null) return NotFound();
			return Ok("ITS GOOD");
		}


		[HttpGet("Marksheets")]
		public IActionResult GetMarksheets() => Ok(bmo.GetMarksheets());

		[HttpGet("Marksheets/{id}")]
		public IActionResult GetMarksheetById(int id)
		{
			var res = bmo.GetMarkseetById(id);
			if (res == null) return NotFound();
			return Ok(res);
		}

		[HttpGet("Marksheets/TotalMarksObtained/{id}")]
		public  ActionResult<double> TotalMarksObtained(int id)
		{
			double res = bmo.TotalMarksObtained(id);
			if (res == -1) return NotFound();
			return res;
		}

		[HttpGet("Marksheets/TotalPercentageObtained/{id}")]
		public ActionResult<double> TotalPercentageObtained(int id)
		{
			double res = bmo.TotalPercentageObtained(id);
			if (res == -1) return NotFound();
			return res;
		}

		[HttpGet("Marksheets/AllMarksObtained/{id}")]
		public IActionResult GetAllMarks(int id)
		{
			var res = bmo.GetAllMarks(id);
			if (res == null) return NotFound();
			return Ok(res);
		}

		/************************************************************
		 *						POST METHODS						*
		 ***********************************************************/
		[HttpPost("NewStudent")]
		public ActionResult AddStudent(StudentDto student)
		{
			bmo.AddStudent(student);
			return CreatedAtAction("AddStudent", student);
		}

		[HttpPost("NewMarksheet")]
		public ActionResult AddMarksheet(MarksheetDto marksheet)
		{
			bmo.AddMarksheet(marksheet);
			return CreatedAtAction("AddMarksheet", marksheet);
		}

		/************************************************************
		 *						PUT METHODS							*
		 ***********************************************************/
		[HttpPut("UpdateMarks")]
		public ActionResult UpdateMarks(UpdateMark u)
		{
			bmo.UpdateMarks(u);
			return Ok("Marks Updated");
		}
	}
}
