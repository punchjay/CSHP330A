using System.Linq;

namespace ProjectOne.Repository
{
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