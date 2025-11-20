using backend.Domain.Enums;
using backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Data.Seeders
{
    public static class UserSeeder
    {
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserName = "admin",
                    UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                    Email = "l3acasha@gmail.com",
                    Phone = "0386001106",
                    Address = "123 Admin Street",
                    Role = UserRole.admin,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new User
                {
                    UserId = 2,
                    UserName = "business",
                    UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                    Email = "nhocsieuquay131023@gmail.com",
                    Phone = "0827749293",
                    Address = "456 Business Street",
                    Role = UserRole.business,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                  new User
                  {
                      UserId = 3,
                      UserName = "user",
                      UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                      Email = "phatqq0@gmail.com",
                      Phone = "0395042018",
                      Address = "789 User Street",
                      Role = UserRole.user,
                      IsActive = true,
                      CreatedAt = DateTime.UtcNow
                  },
                  new User
                  {
                      UserId = 4,
                      UserName = "business",
                      UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                      Email = "test1@gmail.com",
                      Phone = "0829949293",
                      Address = "987 Business Street",
                      Role = UserRole.business,
                      IsActive = true,
                      CreatedAt = DateTime.UtcNow
                  },
                  new User
                  {
                      UserId = 5,
                      UserName = "user",
                      UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                      Email = "test2@gmail.com",
                      Phone = "0395992018",
                      Address = "654 User Street",
                      Role = UserRole.user,
                      IsActive = true,
                      CreatedAt = DateTime.UtcNow
                  },
                    new User
                    {
                        UserId = 6,
                        UserName = "business",
                        UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                        Email = "test3@gmail.com",
                        Phone = "0826649293",
                        Address = "321 Business Street",
                        Role = UserRole.business,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                  new User
                  {
                      UserId = 7,
                      UserName = "user",
                      UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                      Email = "test4@gmail.com",
                      Phone = "0395042018",
                      Address = "136 User Street",
                      Role = UserRole.user,
                      IsActive = true,
                      CreatedAt = DateTime.UtcNow
                  },
                  new User
                  {
                      UserId = 8,
                      UserName = "business",
                      UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                      Email = "test5@gmail.com",
                      Phone = "0826111123",
                      Address = "111 Business Street",
                      Role = UserRole.business,
                      IsActive = true,
                      CreatedAt = DateTime.UtcNow
                  },
                    new User
                    {
                        UserId = 9,
                        UserName = "user",
                        UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                        Email = "test6@gmail.com",
                        Phone = "0395888201",
                        Address = "222 User Street",
                        Role = UserRole.user,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new User
                    {
                        UserId = 10,
                        UserName = "business",
                        UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                        Email = "test7@gmail.com",
                        Phone = "0826333444",
                        Address = "333 Business Street",
                        Role = UserRole.business,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new User
                    {
                        UserId = 11,
                        UserName = "user",
                        UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                        Email = "test8@gmail.com",
                        Phone = "0395001122",
                        Address = "444 User Street",
                        Role = UserRole.user,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new User
                    {
                        UserId = 12,
                        UserName = "business",
                        UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                        Email = "test9@gmail.com",
                        Phone = "0826777888",
                        Address = "555 Business Street",
                        Role = UserRole.business,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new User
                    {
                        UserId = 13,
                        UserName = "user",
                        UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                        Email = "test10@gmail.com",
                        Phone = "0395123456",
                        Address = "666 User Street",
                        Role = UserRole.user,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new User
                    {
                        UserId = 14,
                        UserName = "business",
                        UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                        Email = "test11@gmail.com",
                        Phone = "0826999000",
                        Address = "777 Business Street",
                        Role = UserRole.business,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new User
                    {
                        UserId = 15,
                        UserName = "user",
                        UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                        Email = "test12@gmail.com",
                        Phone = "0395666777",
                        Address = "888 User Street",
                        Role = UserRole.user,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new User
                    {
                        UserId = 16,
                        UserName = "business",
                        UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                        Email = "test13@gmail.com",
                        Phone = "0826222333",
                        Address = "999 Business Street",
                        Role = UserRole.business,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new User
                    {
                        UserId = 17,
                        UserName = "user",
                        UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                        Email = "test14@gmail.com",
                        Phone = "0395777123",
                        Address = "101 User Ave",
                        Role = UserRole.user,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new User
                    {
                        UserId = 18,
                        UserName = "business",
                        UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                        Email = "test15@gmail.com",
                        Phone = "0826555444",
                        Address = "202 Business Ave",
                        Role = UserRole.business,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new User
                    {
                        UserId = 19,
                        UserName = "user",
                        UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                        Email = "test16@gmail.com",
                        Phone = "0395999888",
                        Address = "303 User Ave",
                        Role = UserRole.user,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new User
                    {
                        UserId = 20,
                        UserName = "business",
                        UserPassword = "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86",
                        Email = "test17@gmail.com",
                        Phone = "0826111777",
                        Address = "404 Business Ave",
                        Role = UserRole.business,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    }
            );
        }
    }
}
