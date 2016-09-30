using System;
using System.Linq;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Entities;
using WebApiTypeScript.Core.Enums;
using WebApiTypeScript.Core.Interfaces.Repository.Command;
using WebApiTypeScript.Core.Interfaces.Repository.Query;
using WebApiTypeScript.Data.AppContext;
using WebApiTypeScript.Data.Repository.Generic;
using WebApiTypeScript.Data.Repository.Generic.Command;
using WebApiTypeScript.Data.Repository.Generic.Query;
using Xunit;

namespace WebApiTypeScript.IntegrationTest
{
    public class QueryRepositoryTest : IClassFixture<DatabaseFixture>, IDisposable
    {
        public QueryRepositoryTest()
        {
            if (!Initialized)
            {
                Init(new DatabaseFixture());
            }
            DbContext.Database.BeginTransaction();
        }

        private bool Initialized { get; set; }

        private const string User = "User";
        private const string Course = "Course";

        public ICommandRepository<User> UserCommandRepository { get; set; }
        public ICommandRepository<Course> CourseCommandRepository { get; set; }
        public IQueryRepository<User> UserQueryRepository { get; set; }
        public IQueryRepository<Course> CourseQueryRepository { get; set; }
        public WebApiTypeScriptContext DbContext { get; set; }

        public void Dispose()
        {
            DbContext.Database.CurrentTransaction.Rollback();
        }

        private void Init(DatabaseFixture data)
        {
            DbContext = data.GetDbContext();
            UserCommandRepository = new CommandRepository<User>(DbContext);
            CourseCommandRepository = new CommandRepository<Course>(DbContext);
            UserQueryRepository = new QueryRepository<User>(new RepositoryWebApiTypeScriptInitializer<User>(this.DbContext));
            CourseQueryRepository = new QueryRepository<Course>(new RepositoryWebApiTypeScriptInitializer<Course>(this.DbContext));
            Initialized = true;
        }

        private async Task SetUpData()
        {
            for (var i = 0; i < 20; i++)
            {
                await UserCommandRepository.AddAsync(new User { FirstName = User + (i + 1) });
            }
            var firstUser = await UserQueryRepository.FirstAsync(s => true);
            for (var i = 0; i < 20; i++)
            {
                await CourseCommandRepository.AddAsync(new Course { CourseName = Course + (i + 1), UserId = firstUser.Id });
            }

        }

        [Fact]
        public void CreateInstance_EfQueryRepository_DbContextIsNull_ExpectArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new QueryRepository<User>(null));
        }

        [Fact]
        public async Task FirstAsync_ExpectUserName_User3()
        {
            //Arrange
            await SetUpData();
            var expectedName = User + "3";

            //Act
            var user = await this.UserQueryRepository.FirstAsync(a => a.FirstName == expectedName);

            //Assert
            Assert.Equal(expectedName, user.FirstName);
        }

        [Fact]
        public async Task FirstAsync_And_IncludeCourse_ExpectUserName_User3()
        {
            //Arrange
            await SetUpData();
            var expectedName = User + "3";

            var course = await CourseQueryRepository.FirstAsync(s => true);
            var user = await UserQueryRepository.FirstAsync(t => t.FirstName == expectedName);
            course.UserId = user.Id;
            await CourseCommandRepository.UpdateAsync(course);

            //Act
            var result = await this.UserQueryRepository.FirstAsync(a => a.FirstName == expectedName, t => t.Courses);

            //Assert
            Assert.Equal(expectedName, result.FirstName);
            Assert.Equal(1, result.Courses.Count);
        }

        [Fact]
        public async Task FirstOrDefaultAsync_ExpectUserName_User3()
        {
            //Arrange
            await SetUpData();
            var expectedName = User + "3";

            //Act
            var user = await this.UserQueryRepository.FirstOrDefaultAsync(a => a.FirstName == expectedName);

            //Assert
            Assert.Equal(expectedName, user.FirstName);
        }

        [Fact]
        public async Task FirstOrDefaultAsync_And_IncludeCourse_ExpectUser_User3()
        {
            //Arrange
            await SetUpData();
            var expectedName = User + "3";

            var course = await CourseQueryRepository.FirstAsync(s => true);
            var user = await UserQueryRepository.FirstAsync(t => t.FirstName == expectedName);
            course.UserId = user.Id;
            await CourseCommandRepository.UpdateAsync(course);

            //Act
            var result = await this.UserQueryRepository.FirstOrDefaultAsync(a => a.FirstName == expectedName, t => t.Courses);

            //Assert
            Assert.Equal(expectedName, result.FirstName);
            Assert.Equal(1, result.Courses.Count);
        }

        [Fact]
        public async Task FirstOrDefaultAsync_Search_User33_ExpectNull()
        {
            //Arrange
            await SetUpData();
            var expectedName = User + "33";

            //Act
            var user = await this.UserQueryRepository.FirstOrDefaultAsync(a => a.FirstName == expectedName);

            //Assert
            Assert.Equal(null, user);
        }

        [Fact]
        public async Task SingleAsync_Search_User3_ExpectOne()
        {
            //Arrange
            await SetUpData();
            var expectedName = User + "3";

            //Act
            var user = await this.UserQueryRepository.SingleAsync(a => a.FirstName == expectedName);
            //Assert
            Assert.NotNull(user);
            Assert.Equal(expectedName, user.FirstName);
        }

        [Fact]
        public async Task SingleAsync_And_IncludeCourse_ExpectUserName_User3()
        {
            //Arrange
            await SetUpData();
            var expectedName = User + "3";

            var course = await CourseQueryRepository.FirstAsync(s => true);
            var user = await UserQueryRepository.FirstAsync(t => t.FirstName == expectedName);
            course.UserId = user.Id;
            await CourseCommandRepository.UpdateAsync(course);

            //Act
            var result = await this.UserQueryRepository.SingleAsync(a => a.FirstName == expectedName, t => t.Courses);

            //Assert
            Assert.Equal(expectedName, result.FirstName);
            Assert.Equal(1, result.Courses.Count);
        }

        [Fact]
        public async Task SingleAsync_Add_AnotherUser3_ExpectException()
        {
            //Arrange
            await SetUpData();
            var NameName = User + "3";

            //Act
            await this.UserCommandRepository.AddAsync(new User { FirstName = NameName });

            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => this.UserQueryRepository.SingleAsync(a => a.FirstName == NameName));
        }

        [Fact]
        public async Task SingleAsync_Search_AnotherUser33_ExpectException()
        {
            //Arrange
            await SetUpData();
            var expectedName = User + "33";

            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => this.UserQueryRepository.SingleAsync(a => a.FirstName == expectedName));
        }

        [Fact]
        public async Task SingleOrDefaultAsync_SearchUser3_ExpectOne()
        {
            //Arrange
            await SetUpData();
            var expectedName = User + "3";

            //Act
            var user = await this.UserQueryRepository.SingleOrDefaultAsync(a => a.FirstName == expectedName);
            //Assert
            Assert.NotNull(user);
            Assert.Equal(expectedName, user.FirstName);
        }

        [Fact]
        public async Task SingleOrDefaultAsync_And_IncludeCourse_ExpectUserName_User3()
        {
            //Arrange
            await SetUpData();
            var expectedName = User + "3";

            var course = await CourseQueryRepository.FirstAsync(s => true);
            var user = await UserQueryRepository.FirstAsync(t => t.FirstName == expectedName);
            course.UserId = user.Id;
            await CourseCommandRepository.UpdateAsync(course);

            //Act
            var result = await this.UserQueryRepository.SingleOrDefaultAsync(a => a.FirstName == expectedName, t => t.Courses);

            //Assert
            Assert.Equal(expectedName, result.FirstName);
            Assert.Equal(1, result.Courses.Count);
        }

        [Fact]
        public async Task SingleOrDefaultAsync_Add_AnotherUser3_ExpectException()
        {
            //Arrange
            await SetUpData();
            var expectedName = User + "3";

            //Act
            await this.UserCommandRepository.AddAsync(new User { FirstName = expectedName });

            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => this.UserQueryRepository.SingleOrDefaultAsync(a => a.FirstName == expectedName));
        }

        [Fact]
        public async Task SingleOrDefaultAsync_Search_User33_ExpectNull()
        {
            //Arrange
            await SetUpData();
            var expectedName = User + "33";

            //Assert
            var user = await this.UserQueryRepository.SingleOrDefaultAsync(a => a.FirstName == expectedName);
            Assert.Null(user);
        }

        [Fact]
        public async Task FindAsync_Search_User3_ExpectOneInList()
        {
            //Arrange
            await SetUpData();
            var expectedName = User + "3";

            //Act
            var teachers = await this.UserQueryRepository.FindAsync(a => a.FirstName == expectedName);

            //Assert
            Assert.Equal(1, teachers.Count);
            Assert.Equal(expectedName, teachers.First().FirstName);
        }

        [Fact]
        public async Task FindAsync_And_IncludeCourse_ExpectUserName_User3()
        {
            //Arrange
            await SetUpData();
            var expectedName = User + "3";

            var course = await CourseQueryRepository.FirstAsync(s => true);
            var user = await UserQueryRepository.FirstAsync(t => t.FirstName == expectedName);
            course.UserId = user.Id;
            await CourseCommandRepository.UpdateAsync(course);

            //Act
            var result = await this.UserQueryRepository.FindAsync(a => a.FirstName == expectedName, t => t.Courses);

            //Assert
            Assert.Equal(expectedName, result.First().FirstName);
            Assert.Equal(1, result.First().Courses.Count);
        }

        [Fact]
        public async Task FindAsync_Search_User33_ExpectEmptyList()
        {
            //Arrange
            await SetUpData();
            var expectedName = User + "33";

            //Act
            var teachers = await this.UserQueryRepository.FindAsync(a => a.FirstName == expectedName);

            //Assert
            Assert.Equal(0, teachers.Count);
        }

        [Fact]
        public async Task AnyAsync_Search_User33_ExpectFalse()
        {
            //Arrange
            await SetUpData();
            var expectedName = User + "33";

            //Act
            var notFound = await this.UserQueryRepository.AnyAsync(a => a.FirstName == expectedName);

            //Assert
            Assert.Equal(false, notFound);
        }

        [Fact]
        public async Task AnyAsync_Search_User3_ExpectFalse()
        {
            //Arrange
            await SetUpData();
            var expectedName = User + "3";

            //Act
            var found = await this.UserQueryRepository.AnyAsync(a => a.FirstName == expectedName);

            //Assert
            Assert.Equal(true, found);
        }

        [Fact]
        public async Task CountAsync_AllUsers_Expect20()
        {
            //Arrange
            await SetUpData();

            //Act
            var amount = await this.UserQueryRepository.CountAsync();

            //Assert
            Assert.Equal(20, amount);
        }

        [Fact]
        public async Task CountAsync_user3_Expect1()
        {
            //Arrange
            await SetUpData();
            var expectedName = User + "3";
            //Act
            var amount = await this.UserQueryRepository.CountAsync(user => user.FirstName == expectedName);

            //Assert
            Assert.Equal(1, amount);
        }

        [Fact]
        public async Task GetAllAsync_AllUsers_Expect20()
        {
            //Arrange
            await SetUpData();

            //Act
            var teachers = await this.UserQueryRepository.GetAllAsync();

            //Assert
            Assert.Equal(20, teachers.Count);
        }

        [Fact]
        public async Task GetAllAsync_AllUser_Expect20_And_IncludeCourse()
        {
            //Arrange
            await SetUpData();

            var courses = await CourseQueryRepository.GetAllAsync();
            var allUsers = await UserQueryRepository.GetAllAsync();

            for (var i = 0; i < courses.Count; i++)
            {
                courses[i].UserId = allUsers[i].Id;
            }

            await CourseCommandRepository.UpdateListAsync(courses);

            //Act
            var result = await this.UserQueryRepository.GetAllAsync(t => t.Courses);

            //Assert
            Assert.Equal(20, result.Count);
            Assert.Equal(1, result.First().Courses.Count);
        }

        [Fact]
        public async Task GetAllOrderedByAsync_DefaultOrder_ExpectAscendingOrder()
        {
            //Arrange
            await SetUpData();
            var firstUserName = User + "9";
            var lastUserName = User + "1";

            //Act
            var teachers = await this.UserQueryRepository.GetAllOrderedByAsync(user => user.FirstName);

            //Assert
            Assert.Equal(firstUserName, teachers.First().FirstName);
            Assert.Equal(lastUserName, teachers.Last().FirstName);
        }

        [Fact]
        public async Task GetAllOrderedByAsync_SetDescOrder_ExpectDescendingOrder()
        {
            //Arrange
            await SetUpData();
            var firstUserName = User + "1";
            var lastUserName = User + "9";

            //Act
            var teachers = await this.UserQueryRepository.GetAllOrderedByAsync(user => user.FirstName, Sort.Desc);

            //Assert
            Assert.Equal(firstUserName, teachers.First().FirstName);
            Assert.Equal(lastUserName, teachers.Last().FirstName);
        }

        [Fact]
        public async Task GetAllOrderedByAsync_SetDescOrder_ExpectDescendingOrder_And_IncludeCourses()
        {
            //Arrange
            await SetUpData();
            var firstUserName = User + "1";
            var lastUserName = User + "9";

            //Act
            var courses = await CourseQueryRepository.GetAllAsync();
            var allUsers = await UserQueryRepository.GetAllAsync();

            for (var i = 0; i < courses.Count; i++)
            {
                courses[i].UserId = allUsers[i].Id;
            }

            await CourseCommandRepository.UpdateListAsync(courses);
            var teachers = await this.UserQueryRepository.GetAllOrderedByAsync(user => user.FirstName, Sort.Desc, user => user.Courses);

            //Assert
            Assert.Equal(firstUserName, teachers.First().FirstName);
            Assert.Equal(1, teachers.First().Courses.Count);
            Assert.Equal(lastUserName, teachers.Last().FirstName);
            Assert.Equal(1, teachers.Last().Courses.Count);
        }

        [Fact]
        public async Task GetAllOrderedByAsync_ExpectAscendingOrder_And_IncludeCourses()
        {
            //Arrange
            await SetUpData();
            var firstUserName = User + "9";
            var lastUserName = User + "1";

            //Act
            var courses = await CourseQueryRepository.GetAllAsync();
            var allUsers = await UserQueryRepository.GetAllAsync();

            for (var i = 0; i < courses.Count; i++)
            {
                courses[i].UserId = allUsers[i].Id;
            }

            await CourseCommandRepository.UpdateListAsync(courses);
            var teachers = await this.UserQueryRepository.GetAllOrderedByAsync(user => user.FirstName, Sort.Asc, user => user.Courses);

            //Assert
            Assert.Equal(firstUserName, teachers.First().FirstName);
            Assert.Equal(1, teachers.First().Courses.Count);
            Assert.Equal(lastUserName, teachers.Last().FirstName);
            Assert.Equal(1, teachers.Last().Courses.Count);
        }

        [Fact]
        public async Task GetFilteredtWithPagingAndOrderAsync_ExpectAscendingOrder()
        {
            //Arrange
            await SetUpData();
            var siteOneFirstUserName = User + "9";
            var SiteOneLastUserName = User + "5";
            var siteTwoFirstUserName = User + "4";
            var SiteTwoLastUserName = User + "19";

            //Act
            var teacherSite1 = await this.UserQueryRepository.GetFilteredtWithPagingAndOrderAsync(t => t.FirstName.Contains(User), t => t.FirstName, 0, 5);
            var teacherSite2 = await this.UserQueryRepository.GetFilteredtWithPagingAndOrderAsync(t => t.FirstName.Contains(User), t => t.FirstName, 1, 5);

            //Assert
            Assert.Equal(5, teacherSite1.Count);
            Assert.Equal(siteOneFirstUserName, teacherSite1.First().FirstName);
            Assert.Equal(SiteOneLastUserName, teacherSite1.Last().FirstName);

            Assert.Equal(5, teacherSite2.Count);
            Assert.Equal(siteTwoFirstUserName, teacherSite2.First().FirstName);
            Assert.Equal(SiteTwoLastUserName, teacherSite2.Last().FirstName);
        }

        [Fact]
        public async Task GetFilteredtWithPagingAndOrderAsync_ExpectAscendingOrder_And_IncludeCourses()
        {
            //Arrange
            await SetUpData();
            var siteOneFirstUserName = User + "9";
            var SiteOneLastUserName = User + "5";
            var siteTwoFirstUserName = User + "4";
            var SiteTwoLastUserName = User + "19";

            //Act
            var courses = await CourseQueryRepository.GetAllAsync();
            var allUsers = await UserQueryRepository.GetAllAsync();

            for (var i = 0; i < courses.Count; i++)
            {
                courses[i].UserId = allUsers[i].Id;
            }

            await CourseCommandRepository.UpdateListAsync(courses);
            var teacherSite1 = await this.UserQueryRepository.GetFilteredtWithPagingAndOrderAsync(t => t.FirstName.Contains(User), t => t.FirstName, 0, 5, Sort.Asc, t => t.Courses);
            var teacherSite2 = await this.UserQueryRepository.GetFilteredtWithPagingAndOrderAsync(t => t.FirstName.Contains(User), t => t.FirstName, 1, 5, Sort.Asc, t => t.Courses);

            //Assert
            Assert.Equal(5, teacherSite1.Count);
            Assert.Equal(siteOneFirstUserName, teacherSite1.First().FirstName);
            Assert.Equal(SiteOneLastUserName, teacherSite1.Last().FirstName);
            Assert.Equal(1, teacherSite1.Last().Courses.Count);

            Assert.Equal(5, teacherSite2.Count);
            Assert.Equal(siteTwoFirstUserName, teacherSite2.First().FirstName);
            Assert.Equal(SiteTwoLastUserName, teacherSite2.Last().FirstName);
            Assert.Equal(1, teacherSite2.Last().Courses.Count);
        }

        [Fact]
        public async Task GetFilteredtWithPagingAndOrderAsync_PageIndexIsNegative_ExpectArgumentException()
        {
            //Arrange
            await SetUpData();

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(() => this.UserQueryRepository.GetFilteredtWithPagingAndOrderAsync(t => t.FirstName.Contains(User), t => t.FirstName, -1, 5, Sort.Asc));
        }

        [Fact]
        public async Task GetFilteredtWithPagingAndOrderAsync_PageSizeIsNegative_ExpectArgumentException()
        {
            //Arrange
            await SetUpData();

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(() => this.UserQueryRepository.GetFilteredtWithPagingAndOrderAsync(t => t.FirstName.Contains(User), t => t.FirstName, 0, -1, Sort.Asc));
        }

        [Fact]
        public async Task GetFilteredtWithPagingAndOrderAsync_And_IncludeCourses_PageIndexIsNegative_ExpectArgumentException()
        {
            //Arrange
            await SetUpData();

            //Act
            var courses = await CourseQueryRepository.GetAllAsync();
            var allUsers = await UserQueryRepository.GetAllAsync();

            for (var i = 0; i < courses.Count; i++)
            {
                courses[i].UserId = allUsers[i].Id;
            }

            await CourseCommandRepository.UpdateListAsync(courses);

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(() => this.UserQueryRepository.GetFilteredtWithPagingAndOrderAsync(t => t.FirstName.Contains(User), t => t.FirstName, -1, 5, Sort.Asc, t => t.Courses));
        }

        [Fact]
        public async Task GetFilteredtWithPagingAndOrderAsync_And_IncludeCourses_PageSizeIsNegative_ExpectArgumentException()
        {
            //Arrange
            await SetUpData();

            //Act
            var courses = await CourseQueryRepository.GetAllAsync();
            var allUsers = await UserQueryRepository.GetAllAsync();

            for (var i = 0; i < courses.Count; i++)
            {
                courses[i].UserId = allUsers[i].Id;
            }

            await CourseCommandRepository.UpdateListAsync(courses);

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(() => this.UserQueryRepository.GetFilteredtWithPagingAndOrderAsync(t => t.FirstName.Contains(User), t => t.FirstName, 0, -1, Sort.Asc, t => t.Courses));
        }

        [Fact]
        public async Task GetAllWithPagingAsync_ExpectAscendingOrder()
        {
            //Arrange
            await SetUpData();
            var siteOneFirstUserName = User + "9";
            var SiteOneLastUserName = User + "5";
            var siteTwoFirstUserName = User + "4";
            var SiteTwoLastUserName = User + "19";

            //Act
            var userSite1 = await this.UserQueryRepository.GetAllWithPagingAsync(t => t.FirstName, 0, 5);
            var userSite2 = await this.UserQueryRepository.GetAllWithPagingAsync(t => t.FirstName, 1, 5);

            //Assert
            Assert.Equal(5, userSite1.Count);
            Assert.Equal(siteOneFirstUserName, userSite1.First().FirstName);
            Assert.Equal(SiteOneLastUserName, userSite1.Last().FirstName);

            Assert.Equal(5, userSite2.Count);
            Assert.Equal(siteTwoFirstUserName, userSite2.First().FirstName);
            Assert.Equal(SiteTwoLastUserName, userSite2.Last().FirstName);
        }

        [Fact]
        public async Task GetAllWithPagingAsync_And_IncludeCourses_ExpectAscendingOrder()
        {
            //Arrange
            await SetUpData();
            var siteOneFirstUserName = User + "9";
            var SiteOneLastUserName = User + "5";
            var siteTwoFirstUserName = User + "4";
            var SiteTwoLastUserName = User + "19";

            //Act
            var courses = await CourseQueryRepository.GetAllAsync();
            var allUsers = await UserQueryRepository.GetAllAsync();

            for (var i = 0; i < courses.Count; i++)
            {
                courses[i].UserId = allUsers[i].Id;
            }
            await CourseCommandRepository.UpdateListAsync(courses);

            var teacherSite1 = await this.UserQueryRepository.GetAllWithPagingAsync(t => t.FirstName, 0, 5, Sort.Asc, t => t.Courses);
            var teacherSite2 = await this.UserQueryRepository.GetAllWithPagingAsync(t => t.FirstName, 1, 5, Sort.Asc, t => t.Courses);

            //Assert
            Assert.Equal(5, teacherSite1.Count);
            Assert.Equal(siteOneFirstUserName, teacherSite1.First().FirstName);
            Assert.Equal(SiteOneLastUserName, teacherSite1.Last().FirstName);
            Assert.Equal(1, teacherSite1.Last().Courses.Count);

            Assert.Equal(5, teacherSite2.Count);
            Assert.Equal(siteTwoFirstUserName, teacherSite2.First().FirstName);
            Assert.Equal(SiteTwoLastUserName, teacherSite2.Last().FirstName);
            Assert.Equal(1, teacherSite2.Last().Courses.Count);
        }

        [Fact]
        public async Task GetAllWithPagingAsync_And_IncludeCourses_PageSizeIsNegative_ExpectArgumentException()
        {
            //Arrange
            await SetUpData();
            //Assert
            await Assert.ThrowsAsync<ArgumentException>(() => this.UserQueryRepository.GetAllWithPagingAsync(t => t.FirstName, 0, -1, Sort.Asc, t => t.Courses));
        }

        [Fact]
        public async Task GetAllWithPagingAsync_And_IncludeCourses_PageIndexIsNegative_ExpectArgumentException()
        {
            //Arrange
            await SetUpData();
            //Assert
            await Assert.ThrowsAsync<ArgumentException>(() => this.UserQueryRepository.GetAllWithPagingAsync(t => t.FirstName, -1, 5, Sort.Asc, t => t.Courses));
        }

        [Fact]
        public async Task GetAllWithPagingAsync_PageSizeIsNegative_ExpectArgumentException()
        {
            //Arrange
            await SetUpData();
            //Assert
            await Assert.ThrowsAsync<ArgumentException>(() => this.UserQueryRepository.GetAllWithPagingAsync(t => t.FirstName, 0, -1));
        }

        [Fact]
        public async Task GetAllWithPagingAsync_PageIndexIsNegative_ExpectArgumentException()
        {
            //Arrange
            await SetUpData();
            //Assert
            await Assert.ThrowsAsync<ArgumentException>(() => this.UserQueryRepository.GetAllWithPagingAsync(t => t.FirstName, -1, 5));
        }
    }
}