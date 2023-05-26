using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace CoreConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbProviderFactories.RegisterFactory(MicrosoftSqlProviderServices.ProviderInvariantName, Microsoft.Data.SqlClient.SqlClientFactory.Instance);

            var connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=School;Integrated Security=True;Encrypt=false";

            using (var ctx = new SchoolContext(new SqlConnection(connectionString)))
            {
                ctx.Database.Log = Console.WriteLine;

                ctx.Database.ExecuteSqlCommand("SELECT 1");

                var students = ctx.Students.Where(s => "erik" == SqlFunctions.UserName()).ToList();

                var conn = ctx.Database.Connection as SqlConnection;

                if (conn is null) throw new Exception("conn should not be null");

                var stud = new Student() { StudentName = "Bill" };

                ctx.Students.Add(stud);
                ctx.SaveChanges();
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

    public class SchoolContext : DbContext
    {
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
    }

}