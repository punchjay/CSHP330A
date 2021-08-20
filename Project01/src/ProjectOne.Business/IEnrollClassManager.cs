namespace ProjectOne.Business
{
    public interface IEnrollClassManager
    {
        EnrollClassModel[] EnrolledClass { get; }
        UserClassModel EnrollClass(int userId, int classId);
    }
}
