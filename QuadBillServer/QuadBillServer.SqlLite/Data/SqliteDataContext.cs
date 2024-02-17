using Microsoft.EntityFrameworkCore;
using QuadBillServer.SqlLite.Data.Tables;

namespace QuadBillServer.SqlLite.Data
{
    public class SqliteDataContext : DbContext
    {
        public SqliteDataContext(DbContextOptions<SqliteDataContext> options) : base(options)
        {

        }

        public DbSet<AuthenticationEntity> AuthenticationEntities { get; set; }
        public DbSet<VerificationEntity> VerificationEntities { get; set; }
        public DbSet<RefreshTokenEntity> RefreshTokenEntities { get; set; }

        public Task MigrateDatabase()
        {
            return this.Database.MigrateAsync();
        }
    }
}
