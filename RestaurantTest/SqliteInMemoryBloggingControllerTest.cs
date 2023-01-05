using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Resturant_managment;

namespace RestaurantTest
{
	public class SqliteInMemoryBloggingControllerTest
	{
        private readonly DbContextOptions<RmDbContext> _contextOptions;
        private readonly SqliteConnection _connection;
        public SqliteInMemoryBloggingControllerTest()
        {
            // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
            // at the end of the test (see Dispose below).
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            // These options will be used by the context instances in this test suite, including the connection opened above.
             _contextOptions = new DbContextOptionsBuilder<RmDbContext>()
                .UseSqlite(_connection)
                .Options;

            // Create the schema and seed some data
            using var context = new RmDbContext(_contextOptions);

            if (context.Database.EnsureCreated())
            {
                using var viewCommand = context.Database.GetDbConnection().CreateCommand();
                viewCommand.CommandText = @"
CREATE VIEW AllResources AS
SELECT Url
FROM Blogs;";
                viewCommand.ExecuteNonQuery();
            }


        }

        RmDbContext CreateContext() => new RmDbContext(_contextOptions);

        public void Dispose() => _connection.Dispose();
    }
}

