using System.Linq;

namespace ProjectOne.Repository
{
    public class ClassListRepository : IClassListRepository
    {
        public ClassListModel[] ClassList
        {
            get
            {
                var classList = DatabaseAccessor
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

                return classList;
            }
        }

        public ClassListModel GetClassList(int classId)
        {
            var classById = DatabaseAccessor
                .Instance
                .Class
                .First(t => t.ClassId == classId);

            var classList = new ClassListModel
            {
                ClassId = classById.ClassId,
                ClassDescription = classById.ClassDescription,
                ClassName = classById.ClassName,
                ClassPrice = classById.ClassPrice,
            };

            return classList;
        }
    }
}