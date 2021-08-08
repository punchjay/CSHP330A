﻿using System.Linq;

namespace ProjectOne.Repository
{
    public interface IEnrollClassRepository
    {
        EnrollClassModel[] EnrollClass { get; }
    }

    public class EnrollClassModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }

    public class EnrollClassRepository : IEnrollClassRepository
    {
        public EnrollClassModel[] EnrollClass
        {
            get
            {
                return DatabaseAccessor
                    .Instance
                    .Class
                    .Select(t => new EnrollClassModel
                    {
                        ClassId = t.ClassId,
                        ClassName = t.ClassName,
                    })
                    .ToArray();
            }
        }
    }
}