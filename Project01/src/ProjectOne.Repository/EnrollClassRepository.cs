using System.Linq;

namespace ProjectOne.Repository
{
    public interface IEnrollClassRepository
    {
        EnrollClassModel[] EnrollClassList { get; }
        UserClassModel EnrollNewClass(int userId, int classId);
    }

    public class EnrollClassModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }

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
            var enrollNewClass = DatabaseAccessor.Instance
                .Add(new Database.UserClass
                {
                    UserId = userId,
                    ClassId = classId,
                });

            DatabaseAccessor.Instance.SaveChanges();

            return new UserClassModel
            {
                ClassId = enrollNewClass.Entity.ClassId,
                UserId = enrollNewClass.Entity.UserId,
            };
        }
    }
}