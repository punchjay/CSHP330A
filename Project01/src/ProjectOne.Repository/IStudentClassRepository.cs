namespace ProjectOne.Repository
{
    public interface IStudentClassRepository
    {
        UserClassModel[] GetUser(int userId);
    }
}