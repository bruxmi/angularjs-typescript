using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Entities;
using WebApiTypeScript.Core.Interfaces.Repository.Command;
using WebApiTypeScript.Core.Interfaces.Repository.Query;
using WebApiTypeScript.Data.AppContext;
using WebApiTypeScript.Data.Repository.Generic;
using WebApiTypeScript.Data.Repository.Generic.Command;
using WebApiTypeScript.Data.Repository.Generic.Query;
using Xunit;

namespace WebApiTypeScript.IntegrationTest
{
    public class CommandRepositoryTest : IClassFixture<DatabaseFixture>, IDisposable
    {
        public CommandRepositoryTest()
        {
            if (!Initialized)
            {
                Init(new DatabaseFixture());
            }
            DbContext.Database.BeginTransaction();
        }

        private bool Initialized { get; set; }

        public ICommandRepository<User> UserCommandRepository { get; set; }
        public IQueryRepository<User> UserQueryRepository { get; set; }
        public WebApiTypeScriptContext DbContext { get; set; }

        public void Dispose()
        {
            DbContext.Database.CurrentTransaction.Rollback();
        }

        private void Init(DatabaseFixture data)
        {
            DbContext = data.GetDbContext();
            UserCommandRepository = new CommandRepository<User>(DbContext);
            UserQueryRepository = new QueryRepository<User>(new RepositoryWebApiTypeScriptInitializer<User>(this.DbContext));
            Initialized = true;
        }

        [Fact]
        public void CreateInstance_EfCommandRepository_DbContextIsNull_ExpectArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new CommandRepository<User>(null));
        }

        [Fact]
        public async Task Add_CheckCount_ExpectTwo()
        {
            //Act
            await UserCommandRepository.AddAsync(new User { FirstName = "User1" });
            await UserCommandRepository.AddAsync(new User { FirstName = "User2" });
            var actualAmount = (await UserQueryRepository.GetAllAsync()).Count;
            //Assert
            Assert.Equal(2, actualAmount);
        }

        [Fact]
        public async Task AddList_CheckCount_ExpectTwo()
        {
			//Arrange
			var user1 = new User { FirstName = "User1" };
			var user2 = new User { FirstName = "User2" };

			//Act
			await UserCommandRepository.AddListAsync(new List<User> { user1 });
            await UserCommandRepository.AddListAsync(new List<User> { user2 });
            var actualAmount = (await UserQueryRepository.GetAllAsync()).Count;

            //Assert
            Assert.Equal(2, actualAmount);
        }


        [Fact]
        public async Task DeleteList_CheckCount_ExpectZero()
        {
			//Arrange
			var user1 = new User { FirstName = "User1" };
			var user2 = new User { FirstName = "User2" };

			//Act
			await UserCommandRepository.AddListAsync(new List<User> { user1, user2 });
            var toDelete = await UserQueryRepository.GetAllAsync();
            await UserCommandRepository.DeleteListAsync(toDelete);
            var actualAmount = (await UserQueryRepository.GetAllAsync()).Count;

            //Assert
            Assert.Equal(0, actualAmount);
        }

        [Fact]
        public async Task Delete_CheckCount_ExpectZero()
        {
			//Act
			await UserCommandRepository.AddAsync(new User { FirstName = "User1" });
			await UserCommandRepository.AddAsync(new User { FirstName = "User2" });

            var toDelete = await UserQueryRepository.GetAllAsync();
            await UserCommandRepository.DeleteAsync(toDelete.First());
            await UserCommandRepository.DeleteAsync(toDelete.Last());

            var actualAmount = (await UserQueryRepository.GetAllAsync()).Count;

            //Assert
            Assert.Equal(0, actualAmount);
        }

        [Fact]
        public async Task Update_Expect_TeacherNameChanged()
        {
            //Arrange
            var expectedName = "changed name";

			//Act
			await UserCommandRepository.AddAsync(new User { FirstName = "User1" });
			await UserCommandRepository.AddAsync(new User { FirstName = "User2" });

            var toChange = await UserQueryRepository.GetAllAsync();
            toChange.ForEach(teacher => teacher.FirstName = expectedName);
            await UserCommandRepository.UpdateAsync(toChange.First());
			await UserCommandRepository.UpdateAsync(toChange.Last());

            var result = await UserQueryRepository.GetAllAsync();

            //Assert
            Assert.Equal(expectedName, result.First().FirstName);
            Assert.Equal(expectedName, result.Last().FirstName);

        }

        [Fact]
        public async Task UpdateAllAsync_Expect_TeacherNamesChanged()
        {
			//Arrange
			var user1 = new User { FirstName = "user1" };
			var user2 = new User { FirstName = "user2" };
			var user3 = new User { FirstName = "user3" };
			var user4 = new User { FirstName = "user4" };
			var expectedTitle = "changed Name";

            //Act
            await UserCommandRepository.AddListAsync(new List<User> { user1, user2, user3, user4 });

            var toChange = await UserQueryRepository.GetAllAsync();
            toChange.ForEach(teacher => teacher.FirstName = expectedTitle);

            var firstPairOfTeachers = toChange.Take(2).ToList();
            var scondPairOfTeachers = toChange.Skip(2).Take(2).ToList();
            await UserCommandRepository.UpdateListAsync(firstPairOfTeachers);
			await UserCommandRepository.UpdateListAsync(scondPairOfTeachers);

            var teachers = await UserQueryRepository.GetAllAsync();

            //Assert
            foreach (var teacher in teachers)
            {
                Assert.Equal(expectedTitle, teacher.FirstName);
            }
        }

        [Fact]
        public async Task Add_CheckArgumentNullExceptionIsThrown()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => UserCommandRepository.AddAsync(null));
        }

        [Fact]
        public async Task AddList_CheckArgumentNullExceptionIsThrown()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => UserCommandRepository.AddListAsync(null));
        }

        [Fact]
        public async Task Update_CheckArgumentNullExceptionIsThrown()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => UserCommandRepository.UpdateAsync(null));
        }

        [Fact]
        public async Task UpdateList_CheckArgumentNullExceptionIsThrown()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => UserCommandRepository.UpdateListAsync(null));
        }

        [Fact]
        public async Task Delete_CheckArgumentNullExceptionIsThrown()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => UserCommandRepository.DeleteAsync(null));
        }

        [Fact]
        public async Task DeleteListAsync_CheckArgumentNullExceptionIsThrown()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => UserCommandRepository.DeleteListAsync(null));
        }
    }
}