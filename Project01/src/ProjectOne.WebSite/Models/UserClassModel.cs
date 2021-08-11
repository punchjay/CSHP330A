namespace ProjectOne.WebSite.Models
{
    public class UserClassModel
    {
        public int ClassId { get; set; }
        public int UserId { get; set; }

        public ClassListModel Class { get; set; }
        public UserModel User { get; set; }
    }
}
