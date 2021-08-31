namespace ProjectOne.Repository
{
    public interface IEnrollClassRepository
    {
        EnrollClassModel[] EnrollClassList { get; }

        UserClassModel EnrollNewClass(int userId, int classId);
    }
}