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

        //public ClassListModel GetClassList(int classId)
        //{
        //    var classes = DatabaseAccessor.Instance.Class.First(t => t.ClassId == classId);

        //    return new ClassListModel
        //    {
        //        ClassId = classes.ClassId,
        //        ClassDescription = classes.ClassDescription,
        //        ClassName = classes.ClassName,
        //        ClassPrice = classes.ClassPrice,
        //    };
        //}

        public ClassListModel GetClassList(int classId)
        {
            var classes = DatabaseAccessor.Instance.Class.First(t => t.ClassId == classId);

            return new ClassListModel
            {
                ClassId = classes.ClassId,
                ClassDescription = classes.ClassDescription,
                ClassName = classes.ClassName,
                ClassPrice = classes.ClassPrice,
            };
        }
    }
}