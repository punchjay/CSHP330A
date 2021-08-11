using System.Linq;

namespace ProjectOne.Repository
{
    public interface IStudentClassRepository
    {
        UserClassModel[] UserClasses { get; }
    }

    public class UserClassModel
    {
        public int ClassId { get; set; }
        public int UserId { get; set; }
    }

    public class StudentClassRepository : IStudentClassRepository
    {
        public UserClassModel[] UserClasses
        {
            get
            {
                return DatabaseAccessor
                     .Instance
                     .UserClass
                     .Select(t => new UserClassModel
                     {
                         ClassId = t.ClassId,
                         UserId = t.UserId,
                     })
                     .ToArray();
            }
        }
    }
}
