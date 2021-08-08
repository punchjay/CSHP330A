using System.Linq;

namespace ProjectOne.Repository
{
    public interface IClassListRepository
    {
        ClassListModel[] ClassList { get; }
    }

    public class ClassListModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassPrice { get; set; }
    }

    public class ClassListRepository : IClassListRepository
    {
        public ClassListModel[] ClassList
        {
            get
            {
                return DatabaseAccessor
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
            }
        }
    }
}