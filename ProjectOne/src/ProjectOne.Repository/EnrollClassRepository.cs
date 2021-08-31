using System.Linq;

namespace ProjectOne.Repository
{
    public class EnrollClassRepository : IEnrollClassRepository
    {
        public EnrollClassModel[] EnrollClassList
        {
            get
            {
                var classList = DatabaseAccessor
                    .Instance
                    .Class
                    .Select(t => new EnrollClassModel
                    {
                        ClassId = t.ClassId,
                        ClassName = t.ClassName,
                    })
                    .ToArray();

                return classList;
            }
        }

        public UserClassModel EnrollNewClass(int userId, int classId)
        {
            var dupEnrollClass = DatabaseAccessor
                .Instance
                .UserClass
                .FirstOrDefault(t => t.UserId == userId && t.ClassId == classId);

            if (dupEnrollClass != null)
            {
                return null;
            }

            var enrollNewClass = DatabaseAccessor
                .Instance
                .Add(new Database.UserClass
                {
                    UserId = userId,
                    ClassId = classId,
                });

            DatabaseAccessor.Instance.SaveChanges();

            var userClass = new UserClassModel
            {
                ClassId = enrollNewClass.Entity.ClassId,
                UserId = enrollNewClass.Entity.UserId,
            };

            return userClass;
        }
    }
}