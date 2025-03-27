using Medical.Data.EF.Domain;
using Medical.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medical.Data.EF
{
    /// <summary>
    /// The Medical db context class
    /// </summary>
    /// <seealso cref="DbContext"/>
    public class MedicalDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VictoriaDbContext"/> class
        /// </summary>
        /// <param name="options">The options</param>
        public MedicalDbContext(DbContextOptions<MedicalDbContext> options) : base(options)
        {

        }
        public DbSet<UserRole>? UserRole { get; set; }



    }
}