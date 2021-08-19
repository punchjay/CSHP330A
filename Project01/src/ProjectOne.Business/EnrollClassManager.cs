using ProjectOne.Repository;
using System.Linq;

namespace ProjectOne.Business
{
    public interface IEnrollClassManager
    {
        EnrollClassModel[] EnrollClass { get; }
        UserClassModel EnrollClassForm(int userId, int classId);
    }

    public class EnrollClassModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }

    public class EnrollClassManager : IEnrollClassManager
    {
        private readonly IEnrollClassRepository enrollClassRepository;

        public EnrollClassManager(IEnrollClassRepository enrollClassRepository)
        {
            this.enrollClassRepository = enrollClassRepository;
        }

        public EnrollClassModel[] EnrollClass
        {
            get
            {
                return enrollClassRepository
                    .EnrollClassList
                    .Select(t => new EnrollClassModel
                    {
                        ClassId = t.ClassId,
                        ClassName = t.ClassName,
                    })
                    .ToArray();
            }
        }

        public UserClassModel EnrollClassForm(int userId, int classId)
        {
            var newUserClass = enrollClassRepository.EnrollNewClass(userId, classId);

            return new UserClassModel
            {
                ClassId = newUserClass.ClassId,
                UserId = newUserClass.UserId,
            };
        }
    }
}
