using ProjectOne.Repository;
using System.Linq;

namespace ProjectOne.Business
{
    public interface IEnrollClassManager
    {
        EnrollClassModel[] EnrollClass { get; }
    }

    public class EnrollClassModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }

    public class EnrollClassManager : IEnrollClassManager
    {
        private readonly IEnrollClassRepository enrollClassRepository;

        public EnrollClassManager(IEnrollClassRepository enrollClassRepository)
        {
            this.enrollClassRepository = enrollClassRepository;
        }

        public EnrollClassModel[] EnrollClass
        {
            get
            {
                return enrollClassRepository
                    .EnrollClass
                    .Select(t => new EnrollClassModel
                    {
                        ClassId = t.ClassId,
                        ClassName = t.ClassName,
                    })
                    .ToArray();
            }
        }
    }
}
