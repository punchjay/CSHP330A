using ProjectOne.Database;
using System.Linq;

namespace ProjectOne.Repository
{
    public interface IStudentClassRepository
    {
        UserClassModel[] GetUser(int userId);
    }

    public class UserClassModel
    {
        public int ClassId { get; set; }
        public int UserId { get; set; }
        public Class Class { get; set; }
        public User User { get; set; }
    }

    public class StudentClassRepository : IStudentClassRepository
    {
        public UserClassModel[] GetUser(int userId)
        {
            var userClass = DatabaseAccessor
                .Instance
                .UserClass
                .Where(t => t.UserId == userId)
                    .Select(t => new UserClassModel
                    {
                        ClassId = t.ClassId,
                        UserId = t.UserId,
                        Class = t.Class,
                        User = t.User,
                    })
                    .ToArray();

            return userClass;
        }
    }
}
