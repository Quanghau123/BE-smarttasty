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
                  }
            );
        }
    }
}
