namespace ProjectOne.Business
{
    public interface IEnrollClassManager
    {
        EnrollClassModel[] EnrollClass { get; }
        UserClassModel EnrollClassForm(int userId, int classId);
    }
}
