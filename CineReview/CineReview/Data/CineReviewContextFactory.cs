using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CineReview.Data
{
    public class CineReviewContextFactory : IDesignTimeDbContextFactory<CineReviewContext>
    {
        public CineReviewContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CineReviewContext>();
            builder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));

            return new CineReviewContext(builder.Options);
        }
    }
}
