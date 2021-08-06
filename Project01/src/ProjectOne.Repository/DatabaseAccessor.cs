using System;
using System.Collections.Generic;
using System.Text;
using ProjectOne.Database;

namespace ProjectOne.Repository
{
    public class DatabaseAccessor
    {
        static DatabaseAccessor()
        {
            Instance = new minicstructorContext();
        }

        public static minicstructorContext Instance { get; private set; }
    }
}
