using InfoPortal.Common.Models;
using InfoPortal.DAL;
using InfoPortal.DAL.Repositories.Implementations;
using Moq;
using NUnit.Framework;
using System.Data;

namespace InfoPortal.Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var reader = new Mock<IDataReader>();

            reader.SetupSequence(_ => _.Read())
            .Returns(true)
            .Returns(false);

            reader.Setup(reader => reader.GetOrdinal("Id")).Returns(0);
            reader.Setup(reader => reader.GetOrdinal("Email")).Returns(1);


            reader.Setup(reader => reader.GetInt32(It.IsAny<int>())).Returns(1);
            reader.Setup(reader => reader.GetString(It.IsAny<int>())).Returns("Any");

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(m => m.ExecuteReader()).Returns(reader.Object).Verifiable();

            var connectionMock = new Mock<IDbConnection>();
            connectionMock.Setup(m => m.CreateCommand()).Returns(commandMock.Object);

            var accessMock = new Mock<SQLDataAccess>();
            accessMock.Setup(x => x.DbConnection).Returns(connectionMock.Object);

            SQLDataAccess access = new SQLDataAccess();

            var service = new UserRepository(accessMock.Object);

            var actualResult = service.GetAllTest();
            Assert.IsInstanceOf(typeof(User), actualResult[0]);
        }
    }
}