using CodeFirstStoreFunctions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace SqlProviderSmokeTest.StringSplit
{
    public class StringSplitTest
    {
        [Fact]
        public void SmokeTest1()
        {
            var connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=School;Integrated Security=True;Encrypt=false";

            using (var ctx = new SchoolContext(new SqlConnection(connectionString)))
            {
                ctx.Database.ExecuteSqlCommand("SELECT 1");

                var students = ctx.Students.ToList();

                Assert.True(ctx.Database.Connection as SqlConnection != null);

                var stud = new Student() { StudentName = "Bill" };

                ctx.Students.Add(stud);
                ctx.SaveChanges();
            }

            using (var ctx = new SchoolContext(connectionString))
            {
                var students = ctx.Students.ToList();

                Assert.True(students.Count > 0);

                Assert.True(ctx.Database.Connection as SqlConnection != null);

                var values = new[] { "1", "2", "3" };

                var splits =  ctx.AsSplit(values);
                
                var sql = ((ObjectQuery)splits).ToTraceString();
                ctx.Database.Log = sql => Debug.Write(sql);

                var spltResult = splits.ToList();
            }
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

    public class StringSplitResult
    {
        [Key]
        public string Value { get; set; }
    }

    [DbConfigurationType(typeof(System.Data.Entity.SqlServer.MicrosoftSqlDbConfiguration))]
    public class SchoolContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new FunctionsConvention<SchoolContext>("dbo"));
        }

        public IQueryable<string> AsSplit(string[] source)
            => String_split(string.Join(",", source), ",").Select(s => s.Value);

        [DbFunction(nameof(SchoolContext), "STRING_SPLIT")]
        [DbFunctionDetails(IsBuiltIn = true)]
        public IQueryable<StringSplitResult> String_split(string source, string separator)
        {
            var sourceParameter = new ObjectParameter("Source", source);
            var separatorParameter = new ObjectParameter("Separator", separator);

            return ((IObjectContextAdapter)this).ObjectContext
                .CreateQuery<StringSplitResult>(
                    string.Format("[{0}].{1}", GetType().Name, "STRING_SPLIT(@Source, @Separator)"), 
                    sourceParameter, separatorParameter);
        }

        public SchoolContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<SchoolContext>(null);
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public SchoolContext(SqlConnection connection) : base(connection, true)
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<StringSplitResult> StringSplitResults { get; set; }
    }
}
