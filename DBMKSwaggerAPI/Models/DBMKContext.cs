using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace DBMKSwaggerAPI.Models
{
    public class DBMKContext : DbContext 
    {
        // Class
        public DBMKContext(DbContextOptions<DBMKContext> options) : base(options)
        {

        }

        public DbSet<DBMK> DBMK { get; set; } = null!;
    }
}
