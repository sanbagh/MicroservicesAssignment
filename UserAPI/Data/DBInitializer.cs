using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Data
{
    public class DBInitializer : IDbIntializer
    {
        private readonly ApplicationDBContext dbContext;

        public DBInitializer(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task InitializeAsync()
        {
            try
            {
                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    dbContext.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dbContext.Users.Any(x => x.Name.ToLower() == "john")) return;
            var user = new User
            {
                Email = "john.doe@google.com",
                Name = "John",
                Age = 23
            };

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
