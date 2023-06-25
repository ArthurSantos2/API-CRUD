using AplicativoAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AplicativoAPI.Persistence
{
    public class TutoringDbContext : DbContext
    {
        public TutoringDbContext(DbContextOptions<TutoringDbContext> options) : base(options)
        {
            bool databaseExists = Database.CanConnect();

            if (!databaseExists)
            {
                try
                {
                    Database.Migrate();
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu um erro ao migrar o banco de dados.", ex);
                }
            }
        }

        public DbSet<Pupil> Tutoring { get; set; }
        public DbSet<Mastermind> Masterminds { get; set; }

        //fluente API
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pupil>(p => { p.HasKey(pp => pp.Id); p.Property(pp => pp.Name);
                p.Property(pp => pp.Description).HasMaxLength(200).HasColumnType("varchar(200)");
                p.Property(pp => pp.CreatedDate).HasColumnName("Created_Date");
                p.Property(pp => pp.UpdatedDate).HasColumnName("Update_Date");
                p.HasMany(pp => pp.Masterminds).WithOne().HasForeignKey(s => s.Id);
            });

            builder.Entity<Mastermind>(m => { m.HasKey(mm => mm.Id); });
        }
    } 
    

      
}
