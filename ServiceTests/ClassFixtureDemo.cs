using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ServiceTests
{
    public class DataBaseFixture : IDisposable
    {

        public DataBaseFixture()
        {
            //Initalize Database and tables
        }

        public void Dispose()
        {
            //Drop Database and Delete tables
        }
    }

    public class MyDataBaseTest:IClassFixture<DataBaseFixture>
    {
        private DataBaseFixture dataBaseFixture;

        public MyDataBaseTest(DataBaseFixture dataBaseFixture)
        {
            this.dataBaseFixture = dataBaseFixture;
        }

        [Fact]
        public void MyTest()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}
