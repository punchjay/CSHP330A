using ProjectOne.Repository;
using System.Linq;

namespace ProjectOne.Business
{
    public interface IStudentClassManager
    {
        UserClassModel[] UserClasses { get; }
        UserClassModel User(int userId);
    }

    public class UserClassModel
    {
        public int ClassId { get; set; }
        public int UserId { get; set; }

        public UserClassModel(int classId, int userId)
        {
            ClassId = classId;
            UserId = userId;
        }
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
                        .Select(t => new UserClassModel(t.ClassId, t.UserId))
                        .ToArray();
            }
        }

        public UserClassModel User(int userId)
        {
            var userClassModel = studentClassRepository.User(userId);

            return new UserClassModel(userClassModel.ClassId, userClassModel.UserId);
        }
    }
}
