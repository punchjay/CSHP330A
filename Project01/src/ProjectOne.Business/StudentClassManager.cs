using ProjectOne.Repository;
using System.Linq;

namespace ProjectOne.Business
{
    public class StudentClassManager : IStudentClassManager
    {
        private readonly IStudentClassRepository studentClassRepository;

        public StudentClassManager(IStudentClassRepository studentClassRepository)
        {
            this.studentClassRepository = studentClassRepository;
        }

        public ClassListModel[] GetUser(int userId)
        {
            var studentClass = studentClassRepository.GetUser(userId)
                .Select(t =>
                {
                    return new ClassListModel
                    {
                        ClassId = t.ClassId,
                        ClassName = t.Class.ClassName,
                        ClassDescription = t.Class.ClassDescription,
                        ClassPrice = t.Class.ClassPrice,
                    };
                })
                .ToArray();

            return studentClass;
        }
    }
}
