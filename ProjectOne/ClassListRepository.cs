using ProjectOne.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectOne
{
    public interface IClassListRepository
    {
        IEnumerable<ClassListModel> ClassList { get; }
    }

    public class ClassListRepository : IClassListRepository
    {
        public IEnumerable<ClassListModel> ClassList
        {
            get
            {
                IEnumerable<ClassListModel> items;

                var database = new Db.minicstructorContext();

                items = database.Class
                .Select(t => new ClassListModel
                {
                    ClassId = t.ClassId,
                    ClassDescription = t.ClassDescription,
                    ClassName = t.ClassName,
                    ClassPrice = t.ClassPrice,
                })
                .ToArray();

                return items;
            }
        }
    }
}