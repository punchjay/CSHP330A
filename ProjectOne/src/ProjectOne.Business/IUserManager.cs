namespace ProjectOne.Business
{
    public interface IUserManager
    {
        UserModel LogIn(string email, string password);

        UserModel Register(string email, string password);
    }
}