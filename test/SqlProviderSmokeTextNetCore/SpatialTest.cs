
using System.Data.Entity.Spatial;
using System.Data.Entity.SqlServer.Utilities;
using Moq;
using System.Data.Entity.SqlServer;
using System.Data.SqlTypes;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SmokeTestNetCore
{
    public class SpatialTest
    {
        [Fact]
        public void GetGeography_roundtrips_DbGeography()
        {
            var dbGeography = DbGeography.FromText("POINT (90 50)");
            var mockSqlDataReader = CreateSqlDataReaderWrapper(dbGeography.ProviderValue, "sys.geography");
            var sqlSpatialDataReader = new SqlSpatialDataReader(MicrosoftSqlSpatialServices.Instance, mockSqlDataReader);

            var convertedDbGeography = sqlSpatialDataReader.GetGeography(0);

            Assert.Equal(dbGeography.WellKnownValue.WellKnownText, convertedDbGeography.WellKnownValue.WellKnownText);
        }

        private SqlDataReaderWrapper CreateSqlDataReaderWrapper(object spatialProviderValueToReturn, string providerDataType)
        {
            var mockSqlDataReader = new Mock<SqlDataReaderWrapper>();

            using (var memoryStream = new MemoryStream())
            {
                var writer = new BinaryWriter(memoryStream);

                var writeMethod = spatialProviderValueToReturn.GetType().GetMethod("Write", new[] { typeof(BinaryWriter) });
                writeMethod.Invoke(spatialProviderValueToReturn, new[] { writer });
                var sqlBytes = new SqlBytes(memoryStream.ToArray());

                mockSqlDataReader.Setup(m => m.GetSqlBytes(0)).Returns(sqlBytes);
#if !NET40
                mockSqlDataReader.Setup(m => m.GetFieldValueAsync<SqlBytes>(0, CancellationToken.None)).Returns(Task.FromResult(sqlBytes));
#endif
                mockSqlDataReader.Setup(m => m.GetDataTypeName(0)).Returns(providerDataType);
                mockSqlDataReader.Setup(m => m.FieldCount).Returns(1);
            }

            return mockSqlDataReader.Object;
        }

    }
}
