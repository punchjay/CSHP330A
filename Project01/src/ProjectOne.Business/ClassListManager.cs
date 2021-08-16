using ProjectOne.Repository;
using System.Linq;

namespace ProjectOne.Business
{
    public class ClassListManager : IClassListManager
    {
        private readonly IClassListRepository classListRepository;

        public ClassListManager(IClassListRepository classListRepository)
        {
            this.classListRepository = classListRepository;
        }

        public ClassListModel[] ClassList
        {
            get
            {
                return classListRepository
                    .ClassList
                    .Select(t => new ClassListModel
                    {
                        ClassId = t.ClassId,
                        ClassDescription = t.ClassDescription,
                        ClassName = t.ClassName,
                        ClassPrice = t.ClassPrice,
                    })
                    .ToArray();
            }
        }
    }
}
