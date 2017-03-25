using System;
using System.Collections.Generic;

namespace NewBe.Web.Easyui.Intergration.DataModels
{
    public interface IDataStore
    {
        IList<Student> Students { get; }
        IList<Class> Classes { get; }
        IList<Grade> Grades { get; }
    }

    public class StaticDataStore : IDataStore
    {
        private static readonly IList<Student> Students;
        private static readonly IList<Class> Classes;
        private static readonly IList<Grade> Grades;

        static StaticDataStore()
        {
            var grade1 = new Grade
            {
                Name = "Grade One",
                Id = "grade1",
            };
            var grade2 = new Grade
            {
                Name = "Grade Two",
                Id = "grade2"
            };
            Grades = new List<Grade>
            {
                grade1,
                grade2
            };
            var class1 = new Class
            {
                Name = "Class One",
                Id = "class1",
                GradeId = grade1.Id,
            };
            var class2 = new Class
            {
                Name = "Class Two",
                Id = "class2",
                GradeId = grade1.Id
            };
            var class3 = new Class
            {
                Name = "Class Three",
                Id = "class3",
                GradeId = grade2.Id
            };
            Classes = new List<Class>
            {
                class1,
                class2,
                class3
            };
            Students = new List<Student>
            {
                new Student
                {
                    Id = "student1",
                    Name = "Mary",
                    Birthday = DateTime.Parse("1992-01-02"),
                    ClassId = class1.Id,
                    Sex = SexType.Female
                },
                new Student
                {
                    Id = "student2",
                    Name = "Justin",
                    Birthday = DateTime.Parse("1991-11-02"),
                    ClassId = class1.Id,
                    Sex = SexType.Male
                },
                new Student
                {
                    Id = "student3",
                    Name = "Lee",
                    Birthday = DateTime.Parse("1995-6-23"),
                    ClassId = class3.Id,
                    Sex = SexType.Male
                }
            };

            var rand = new Random();
            for (var i = 0; i < 10000; i++)
            {
                Students.Add(new Student
                {
                    Birthday = DateTime.Parse("1990-01-01").AddDays(rand.Next(1000)),
                    Id = Guid.NewGuid().ToString(),
                    Name = $"student{i}",
                    ClassId = Classes[rand.Next(3)].Id,
                    Sex = rand.Next(100) % 2 == 0 ? SexType.Female : SexType.Male,
                });
            }
        }

        IList<Student> IDataStore.Students => Students;

        IList<Class> IDataStore.Classes => Classes;

        IList<Grade> IDataStore.Grades => Grades;
    }

    public class Grade
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Class
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string GradeId { get; set; }
    }

    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public SexType Sex { get; set; }
        public string ClassId { get; set; }
    }


    public enum SexType
    {
        Male,
        Female
    }
}