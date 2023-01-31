using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SmokeTestNetFx
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SmokeTest1()
        {
            var connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=School;Integrated Security=True;Encrypt=false";

            using (var ctx = new SchoolContext(connectionString))
            {
                ctx.Database.ExecuteSqlCommand("SELECT 1");

                var students = ctx.Students.ToList();

                Assert.IsTrue(ctx.Database.Connection as SqlConnection != null);

                var stud = new Student() { StudentName = "Bill" };

                ctx.Students.Add(stud);
                ctx.SaveChanges();
            }

            using (var ctx = new SchoolContext(connectionString))
            {
                var students = ctx.Students.ToList();

                Assert.IsTrue(students.Count > 0);

                Assert.IsTrue(ctx.Database.Connection as SqlConnection != null);
            }
        }

        public class Student
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public byte[] Photo { get; set; }
            public decimal Height { get; set; }
            public float Weight { get; set; }

            public Grade Grade { get; set; }
        }

        public class Grade
        {
            public int GradeId { get; set; }
            public string GradeName { get; set; }
            public string Section { get; set; }

            public ICollection<Student> Students { get; set; }
        }

        public class SchoolContext : DbContext
        {
            public SchoolContext(string connectionString) : base(connectionString)
            { }

            public DbSet<Student> Students { get; set; }
            public DbSet<Grade> Grades { get; set; }
        }
    }
}
