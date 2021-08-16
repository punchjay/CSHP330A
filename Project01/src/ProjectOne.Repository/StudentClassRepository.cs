using System.Linq;

namespace ProjectOne.Repository
{
    public interface IStudentClassRepository
    {
        UserClassModel[] UserClasses { get; }
        UserClassModel User(int userId);
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

        public UserClassModel User(int userId)
        {
            var user = DatabaseAccessor
                .Instance
                .UserClass
                .Where(t => t.UserId == userId)
                    .Select(t => new UserClassModel
                    {
                        ClassId = t.ClassId,
                        UserId = t.UserId
                    })
                    .First();

            return user;
        }
    }
}
