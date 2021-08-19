namespace ProjectOne.Repository
{
    public interface IUserRepository
    {
        UserModel LogIn(string email, string password);
        UserModel RegisterUser(string email, string password);
    }
}
