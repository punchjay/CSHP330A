namespace ProjectOne.Business
{
    public interface IUserManager
    {
        UserModel LogIn(string email, string password);
        UserModel RegisterForm(string email, string password);
    }
}
