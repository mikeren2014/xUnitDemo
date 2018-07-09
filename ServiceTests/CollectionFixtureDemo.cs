using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ServiceTests
{
    [CollectionDefinition("Database collection")]
    public class DatabaseCollection : ICollectionFixture<DataBaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    [Collection("Database collection")]
    public class DatabaseTestClass1
    {
        DataBaseFixture fixture;

        public DatabaseTestClass1(DataBaseFixture fixture)
        {
            this.fixture = fixture;
        }
    }

    [Collection("Database collection")]
    public class DatabaseTestClass2
    {
        // ...
    }
}
