using ProjectTwo.Database;

namespace ProjectTwo.Repository
{
    internal class DatabaseAccessor
    {
        static DatabaseAccessor()
        {
            Instance = new ProjectTwoUserContext();
        }

        public static ProjectTwoUserContext Instance
        {
            get;
            private set;
        }
    }
}