using ProjectOne.Repository;
using System.Linq;

namespace ProjectOne.Business
{
    public class EnrollClassManager : IEnrollClassManager
    {
        private readonly IEnrollClassRepository enrollClassRepository;

        public EnrollClassManager(IEnrollClassRepository enrollClassRepository)
        {
            this.enrollClassRepository = enrollClassRepository;
        }

        public EnrollClassModel[] EnrolledClass
        {
            get
            {
                var enrollClass = enrollClassRepository
                    .EnrollClassList
                    .Select(t => new EnrollClassModel
                    {
                        ClassId = t.ClassId,
                        ClassName = t.ClassName,
                    })
                    .ToArray();

                return enrollClass;
            }
        }

        public UserClassModel EnrollClass(int userId, int classId)
        {
            var newUserClass = enrollClassRepository.EnrollNewClass(userId, classId);

            if (newUserClass == null)
            {
                return null;
            }

            var userClass = new UserClassModel
            {
                ClassId = newUserClass.ClassId,
                UserId = newUserClass.UserId,
            };

            return userClass;
        }
    }
}