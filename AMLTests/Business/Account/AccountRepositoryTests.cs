using AML.Server.Data;
using AML.Server.Helpers;
using AML.Server.Repositories;
using EntityFrameworkCore3Mock;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace AMLTests.Business.Account
{
    public class AccountRepositoryTests
    {
        [Fact]
        public async Task AccountExistsVerifyEmailReturnsFalse()
        {
            string email = "testuser@gmail.com";

            var accounts = new List<AML.Server.Models.Account>()
            {
                new AML.Server.Models.Account
                {
                    Email = email,
                    Password = "password",
                    PasswordSalt = "abc123",
                    Subscribed = true,
                    Name = "Test User",
                    Address = "Test Address",
                    Phone = "07111111111",
                    AccountType = AML.Server.Models.AccountType.LibraryMember,
                    BranchId = 2
                }
            };

            var dbContextMock = new DbContextMock<DBContext>();
            dbContextMock.Setup<DbSet<AML.Server.Models.Account>>(x => x.Accounts)
                .ReturnsDbSet(accounts);

            AccountRepository repo = new AccountRepository(dbContextMock.Object);
            bool success = await repo.VerifyEmail(email);

            Assert.False(success);
        }

        [Fact]
        public async Task AccountNotExistVerifyEmailReturnsTrue()
        {
            string email = "newuser@gmail.com";

            var accounts = new List<AML.Server.Models.Account>()
            {
                new AML.Server.Models.Account
                {
                    Email = "testuser@gmail.com",
                    Password = "password",
                    PasswordSalt = "abc123",
                    Subscribed = true,
                    Name = "Test User",
                    Address = "Test Address",
                    Phone = "07111111111",
                    AccountType = AML.Server.Models.AccountType.LibraryMember,
                    BranchId = 2
                }
            };

            var dbContextMock = new DbContextMock<DBContext>();
            dbContextMock.Setup<DbSet<AML.Server.Models.Account>>(x => x.Accounts)
                .ReturnsDbSet(accounts);

            AccountRepository repo = new AccountRepository(dbContextMock.Object);
            bool success = await repo.VerifyEmail(email);

            Assert.True(success);
        }

        [Fact]
        public async Task VerifyLoginReturnsTrue()
        {
            string email = "testuser@gmail.com";
            string password = "password";
            CancellationToken cancellationToken = new CancellationToken();

            var accounts = new List<AML.Server.Models.Account>()
            {
                new AML.Server.Models.Account
                {
                    Email = "testuser@gmail.com",
                    Password = PasswordHasher.ComputeHash(password, "abc123", null, 3),
                    PasswordSalt = "abc123",
                    Subscribed = true,
                    Name = "Test User",
                    Address = "Test Address",
                    Phone = "07111111111",
                    AccountType = AML.Server.Models.AccountType.LibraryMember,
                    BranchId = 2
                }
            };

            var dbContextMock = new DbContextMock<DBContext>();
            dbContextMock.Setup<DbSet<AML.Server.Models.Account>>(x => x.Accounts)
                .ReturnsDbSet(accounts);

            AccountRepository repo = new AccountRepository(dbContextMock.Object);
            AML.Server.Models.Account account = await repo.VerifyLogin(email, password, cancellationToken);

            Assert.NotNull(account);
            Assert.Equal(email, account.Email);
        }
    }
}
