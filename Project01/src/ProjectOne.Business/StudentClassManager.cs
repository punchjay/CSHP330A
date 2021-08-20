using ProjectOne.Repository;
using System.Linq;

namespace ProjectOne.Business
{
    public class StudentClassManager : IStudentClassManager
    {
        private readonly IStudentClassRepository studentClassRepository;
        //private readonly IClassListRepository classListRepository;

        public StudentClassManager(IStudentClassRepository studentClassRepository,
            IClassListRepository classListRepository)
        {
            this.studentClassRepository = studentClassRepository;
            //this.classListRepository = classListRepository;
        }

        public ClassListModel[] GetUser(int userId)
        {
            var studentClass = studentClassRepository.GetUser(userId)
                .Select(t =>
                {
                    //var classList = classListRepository.GetClassList(t.ClassId);

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
