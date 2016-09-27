using System;
using System.Linq;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Entities;
using WebApiTypeScript.Data.AppContext;
using WebApiTypeScript.Data.Repository.Generic;
using WebApiTypeScript.Data.Repository.Generic.Command;
using WebApiTypeScript.Data.Repository.Generic.Query;
using Xunit;

namespace WebApiTypeScript.IntegrationTest
{
    public class DynamicSqlQueryRepositoryTest : IClassFixture<DatabaseFixture>, IDisposable
    {

        public DynamicSqlQueryRepositoryTest()
        {
            if (!Initialized)
            {
                Init(new DatabaseFixture());
            }
            DbContext.Database.BeginTransaction();
        }

        private bool Initialized { get; set; }
        public DynamicSqlQueryRepository<User> DynamicSqlQueryRepository { get; set; }
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
            DynamicSqlQueryRepository = new DynamicSqlQueryRepository<User>(DbContext);
            UserQueryRepository = new QueryRepository<User>(new RepositoryAppInitializer<User>(this.DbContext));
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
        public async Task DynamicSqlQueryRepository_GetAllUsers_CheckAmount()
        {
            //Arrange
            await this.SetUpData();
            var selectCommand = @"Select * FROM [Users]";

            //Act
            var teachers = await this.DynamicSqlQueryRepository.SqlQueryAsync(selectCommand);

            //Assert
            Assert.Equal(20, teachers.Count);
        }

        [Fact]
        public async Task DynamicSqlQueryRepository_SearchUser3_ExpectListWithOneItem()
        {
            //Arrange
            await this.SetUpData();
            var selectCommand = @"Select * FROM [Users] WHERE FirstName = 'User3'";

            //Act
            var users = await this.DynamicSqlQueryRepository.SqlQueryAsync(selectCommand);

            //Assert
            Assert.Equal(1, users.Count);
        }

        [Fact]
        public async Task DynamicSqlQueryRepository_SearchUser3_UseParameters_ExpectAmount1()
        {
            //Arrange
            await this.SetUpData();
            var selectCommand = @"DECLARE @Name varchar(max) = {0} " +
                                "BEGIN " +
                                "Select * FROM [Users] WHERE FirstName = @Name " +
                                "END";

            //Act
            var teachers = await this.DynamicSqlQueryRepository.SqlQueryAsync(selectCommand, "User3");

            //Assert
            Assert.Equal(1, teachers.Count);
        }

        [Fact]
        public async Task DynamicSqlQueryRepository_CountUsers_Expect20_ListOfInteger()
        {
            //Arrange
            await this.SetUpData();
            var selectCommand = @"Select Count(*) FROM [Users];";
            var expectedUserCount = 20;

            //Act
            var result = await this.DynamicSqlQueryRepository.SqlQueryAsync<int>(selectCommand);

            //Assert
            Assert.Equal(1, result.Count);
            Assert.Equal(expectedUserCount, result.First());
        }

        [Fact]
        public async Task SqlCommandAsync_SqlIsNull_ExpectArgumentNullException()
        {
            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => this.DynamicSqlQueryRepository.SqlQueryAsync(null));
        }

        [Fact]
        public async Task SqlCommandAsyncWithGenericReturnTypeT_GetAllUsers_CheckAmount()
        {
            //Arrange
            await this.SetUpData();
            var selectCommand = @"Select * FROM [Users]";

            //Act
            var teachers = await this.DynamicSqlQueryRepository.SqlQueryAsync<User>(selectCommand);

            //Assert
            Assert.Equal(20, teachers.Count);
        }

        [Fact]
        public async Task SqlCommandAsyncWithGenericReturnTypeT_SearchUser3_ExpectListWithOneItem()
        {
            //Arrange
            await this.SetUpData();
            var selectCommand = @"Select * FROM [Users] WHERE FirstName = 'User3'";

            //Act
            var teachers = await this.DynamicSqlQueryRepository.SqlQueryAsync<User>(selectCommand);

            //Assert
            Assert.Equal(1, teachers.Count);
        }

        [Fact]
        public async Task SqlCommandAsyncWithGenericReturnTypeT_SearchUser3_UseParameters_ExpectAmount1()
        {
            //Arrange
            await this.SetUpData();
            var selectCommand = @"DECLARE @Name varchar(max) = {0} " +
                                "BEGIN " +
                                "Select * FROM [Users] WHERE FirstName = @Name " +
                                "END";

            //Act
            var teachers = await this.DynamicSqlQueryRepository.SqlQueryAsync<User>(selectCommand, "User3");

            //Assert
            Assert.Equal(1, teachers.Count);
        }


        [Fact]
        public async Task SqlCommandAsyncWithGenericReturnTypeT_SqlIsNull_ExpectArgumentNullException()
        {
            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => this.DynamicSqlQueryRepository.SqlQueryAsync<User>(null));
        }
    }
}
