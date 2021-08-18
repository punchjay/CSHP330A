using System.Linq;

namespace ProjectOne.Repository
{
    public class ClassListRepository : IClassListRepository
    {
        public ClassListModel[] ClassList
        {
            get
            {
                var ClassList = DatabaseAccessor
                    .Instance
                    .Class
                    .Select(t => new ClassListModel
                    {
                        ClassId = t.ClassId,
                        ClassDescription = t.ClassDescription,
                        ClassName = t.ClassName,
                        ClassPrice = t.ClassPrice,
                    })
                    .ToArray();

                return ClassList;
            }
        }
    }
}