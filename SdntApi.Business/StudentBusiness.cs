using SdntApi.Data;
using SdntApi.Models.Domains;
using SdntApi.Models.DTO;

namespace SdntApi.Business
{
	public class StudentBusiness
	{
		private readonly SdntDbContext dbContext;
		private int s_id, m_id;
		public StudentBusiness(SdntDbContext dbContext)
        {
			this.dbContext = dbContext;
			s_id = this.dbContext.Students.Count();
			m_id = this.dbContext.Marksheets.Count();
		}

		//GET METHODS
		//Returns all the students
		public List<Student> GetStudents() => dbContext.Students.ToList();

		//Returns all the marksheets
		public List<Marksheet> GetMarksheets() => dbContext.Marksheets.ToList();

		//Returns student by Id
		public Student? GetStudentById(int id) => dbContext.Students.Find(id);

		//Returns Marksheet by Id
		public Marksheet? GetMarkseetById(int m_id) => dbContext.Marksheets.Find(m_id);

		//QUESTION 1 : TOTAL MARK OBTAINED
		public double TotalMarksObtained(int id)
		{
			var stu = dbContext.Students.Find(id);
			if (stu == null) return -1;
			double res = 0;
			var marksheets = dbContext.Marksheets;
			foreach(Marksheet mrk in marksheets)
			{
				if(mrk.StudentId==id) res += mrk.ObtainedMarks;
			}
			return res;
		}
		//QUESTION 2 : TOTAL PERCENTAGE OBTAINED
		public double TotalPercentageObtained(int id)
		{
			var stu = dbContext.Students.Find(id);
			if (stu == null) return -1;

			double mo = 0, tmo = 0;
			var marksheets = dbContext.Marksheets;
			if (marksheets.Count() == 0) return -1;
			foreach(Marksheet mrk in marksheets)
			{
				if (mrk.StudentId == id)
				{
					mo += mrk.ObtainedMarks;
					tmo += mrk.TotalMarks;
				}
			}
			return (mo / tmo) * 100;
		}

		//QUESTION 3 : GET ALL MARKS BY ID
		public List<SubjectMarkDto>? GetAllMarks(int id)
		{
			var res = dbContext.Students.Find(id);
			if (res == null) return null;

			List<SubjectMarkDto> ls = new List<SubjectMarkDto>();
			var mrks = dbContext.Marksheets;
			foreach(Marksheet mrk in mrks)
			{
				if (mrk.StudentId == id)
				{
					ls.Add(new SubjectMarkDto { Subject = mrk.Subject, Marks = mrk.ObtainedMarks });
				}
			}
			return ls;
		}

		//POST METHODS
		public void AddMarksheet(MarksheetDto marksheet)
		{
			//Convert the dto into domains
			Marksheet newmarks = new Marksheet
			{
				StudentId = marksheet.StudentId,
				Subject = marksheet.Subject,
				TotalMarks = marksheet.TotalMarks,
				ObtainedMarks = marksheet.ObtainedMarks
			};

			dbContext.Marksheets.Add(newmarks);
			dbContext.SaveChanges();
		}

		public void AddStudent(StudentDto student)
		{
			Student newstudent = new Student
			{
				Name = student.Name,
				JoinDate = student.JoinDate,
				Standard = student.Standard
			};

			dbContext.Students.Add(newstudent);
			dbContext.SaveChanges();
		}

		//PUT METHODS
		public void UpdateMarks(UpdateMark u)
		{
			Marksheet updatedmarksheet = dbContext.Marksheets.Find(u.MarksheetId)!;
			if (updatedmarksheet == null) return;

			updatedmarksheet.ObtainedMarks = u.UpdatedMarks;
			dbContext.Marksheets.Update(updatedmarksheet);
			dbContext.SaveChanges();
		}
    }
}
