using System.Linq;
using ProjectOne.Repository;

namespace ProjectOne.Business
{
    public interface IStudentClassManager
    {
        UserClassModel[] UserClasses { get; }
    }

    public class UserClassModel
    {
        public int ClassId { get; set; }
        public int UserId { get; set; }
    }

    public class StudentClassManager : IStudentClassManager
    {
        private readonly IStudentClassRepository studentClassRepository;

        public StudentClassManager(IStudentClassRepository studentClassRepository)
        {
            this.studentClassRepository = studentClassRepository;
        }

        public UserClassModel[] UserClasses
        {
            get
            {
                return studentClassRepository
                        .UserClasses
                        .Select(t => new UserClassModel
                        { 
                            ClassId = t.ClassId,
                            UserId = t.UserId
                        })
                        .ToArray();
            }
        }
    }
}
