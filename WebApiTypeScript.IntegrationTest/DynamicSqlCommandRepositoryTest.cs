using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Entities;
using WebApiTypeScript.Data.AppContext;
using WebApiTypeScript.Data.Repository.Generic;
using WebApiTypeScript.Data.Repository.Generic.Command;
using WebApiTypeScript.Data.Repository.Generic.Query;
using Xunit;

namespace WebApiTypeScript.IntegrationTest
{
    public class DynamicSqlCommandRepositoryTest : IClassFixture<DatabaseFixture>, IDisposable
    {

        public DynamicSqlCommandRepositoryTest()
        {
            if (!Initialized)
            {
                Init(new DatabaseFixture());
            }
            DbContext.Database.BeginTransaction();
        }

        private bool Initialized { get; set; }
        public DynamicSqlCommandRepository DynamicSqlCommandRepository { get; set; }
        public QueryRepository<User> UserQueryRepository { get; set; }
        public WebApiTypeScriptContext DbContext { get; set; }
        public CommandRepository<User> UserCommandRepository { get; set; }
        private const string User = "User";

        public void Dispose()
        {
            DbContext.Database.CurrentTransaction.Rollback();
        }

        private void Init(DatabaseFixture data)
        {
            DbContext = data.GetDbContext();
            DynamicSqlCommandRepository = new DynamicSqlCommandRepository(DbContext);
            UserQueryRepository = new QueryRepository<User>(new RepositoryAppInitializer<User>(DbContext));
            UserCommandRepository = new CommandRepository<User>(DbContext);
            Initialized = true;
        }

        private async Task SetUpData()
        {
            for (var i = 0; i < 20; i++)
            {
                await UserCommandRepository.AddAsync(new User { FirstName = User + (i + 1) });
            }
        }

        [Fact]
        public async Task SqlCommandAsync_CheckUpdatedTeacher()
        {
            await this.SetUpData();
            var updateCommand = @"UPDATE [Users] SET [FirstName] = 'UserUpdated' WHERE [FirstName] = 'User3'";
            await this.DynamicSqlCommandRepository.SqlCommandAsync(updateCommand);
            var updatedTeacher = await this.UserQueryRepository.FirstOrDefaultAsync(t => t.FirstName == "UserUpdated");
            Assert.NotNull(updatedTeacher);
        }

        [Fact]
        public async Task SqlCommandAsync_MissspelledTableName_ExpectSqlException()
        {
            await this.SetUpData();
            var updateCommand = @"UPDATE [Users1] SET [FirstName] = 'UserUpdated' WHERE [FirstName] = 'Teacher3'";
            await Assert.ThrowsAsync<SqlException>(() => this.DynamicSqlCommandRepository.SqlCommandAsync(updateCommand));
        }

        [Fact]
        public async Task SqlCommandAsync_SqlIsNull_ExpectArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => this.DynamicSqlCommandRepository.SqlCommandAsync(null));
        }
    }
}
