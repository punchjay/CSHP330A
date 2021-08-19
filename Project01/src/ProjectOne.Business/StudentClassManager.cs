using ProjectOne.Repository;
using System.Linq;

namespace ProjectOne.Business
{
    public class StudentClassManager : IStudentClassManager
    {
        private readonly IStudentClassRepository studentClassRepository;
        private readonly IClassListRepository classListRepository;

        public StudentClassManager(IStudentClassRepository studentClassRepository,
            IClassListRepository classListRepository)
        {
            this.studentClassRepository = studentClassRepository;
            this.classListRepository = classListRepository;
        }

        public UserClassModel[] GetUser(int userId)
        {
            var studentClass = studentClassRepository.GetUser(userId)
                .Select(t =>
                {
                    var classList = classListRepository.GetClassList(t.ClassId);

                    return new UserClassModel
                    {
                        ClassId = t.ClassId,
                        ClassName = classList.ClassName,
                        ClassDescription = classList.ClassDescription,
                        ClassPrice = classList.ClassPrice,
                    };
                })
                .ToArray();

            return studentClass;
        }
    }
}
