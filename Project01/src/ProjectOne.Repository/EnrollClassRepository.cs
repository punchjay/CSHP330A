using System.Linq;

namespace ProjectOne.Repository
{
    public interface IEnrollClassRepository
    {
        EnrollClassModel[] ClassList { get; }
    }

    public class EnrollClassModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassPrice { get; set; }
    }

    public class EnrollClassRepository : IEnrollClassRepository
    {
        public EnrollClassModel[] ClassList
        {
            get
            {
                return DatabaseAccessor
                    .Instance
                    .Class
                    .Select(t => new EnrollClassModel
                    {
                        ClassId = t.ClassId,
                        ClassDescription = t.ClassDescription,
                        ClassName = t.ClassName,
                        ClassPrice = t.ClassPrice,
                    })
                    .ToArray();
            }
        }

        //public EnrollClassModel EnrollNewClass(int userId, int classId)
        //{
        //    //var userFound = DatabaseAccessor.Instance.UserClass
        //    //.FirstOrDefault(t => t.UserEmail.ToLower() == email.ToLower());

        //    //if (userFound != null)
        //    //{
        //    //    return null;
        //    //}

        //    var enrollNewClass = DatabaseAccessor.Instance.UserClass
        //            .Add(new Database.UserClass
        //            {
        //                UserId = userId,
        //                ClassId = classId
        //            });

        //    DatabaseAccessor.Instance.SaveChanges();

        //    return new EnrollClassModel { ClassId = user.Entity.UserId, Name = user.Entity.UserEmail };
        //}
    }
}