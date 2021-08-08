using ProjectOne.Database;

namespace ProjectOne.Repository
{
    class DatabaseAccessor
    {
        static DatabaseAccessor()
        {
            Instance = new minicstructorContext();
        }

        public static minicstructorContext Instance
        {
            get;
            private set;
        }
    }
}
