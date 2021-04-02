using System.Data.Entity.ModelConfiguration.Conventions;
using DataAccess.DataModels;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.DBContext
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
           : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=NME;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User
            modelBuilder.Entity<User>().HasIndex(user => new { user.Username }).IsUnique(true);
            modelBuilder.Entity<User>().HasIndex(user => new { user.Email }).IsUnique(true);
            #endregion

            #region Vote
            modelBuilder.Entity<Vote>().HasIndex(vote => new { vote.PostId, vote.UserId }).IsUnique(true);
            #endregion
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
