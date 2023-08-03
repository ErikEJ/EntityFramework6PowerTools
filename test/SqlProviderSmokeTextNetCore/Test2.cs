using Microsoft.Data.SqlClient;
using System.Data.Entity.Core;
using Xunit;

namespace SqlProviderSmokeTest
{
    public class Test2
    {
        [Fact]
        public void SmokeTest2()
        {
            var connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=School;Integrated Security=True;Encrypt=false";

            using (var ctx = new SchoolContext(new SqlConnection(connectionString)))
            {
                string sql = "RAISERROR(49918, 16, 1, 'Cannot process request. Not enough resources to process request.');";

                var ex = Assert.Throws<EntityException>(() => ctx.Database.ExecuteSqlCommand(sql));

                Assert.True(ex.InnerException is SqlException);
            }
        }
    }
}
