using GamesForFree.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesForFree.Data
{
    public class GamesForFreeDbContext : DbContext
    {
        public GamesForFreeDbContext(DbContextOptions<GamesForFreeDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<VideoGame> VideoGame { get; set; }
        public DbSet<CompanyType> CompanyType { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<CompanyVideoGame> CompanyVideoGame { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Filename=./GamesForFree.sqlite");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<VideoGame>()
                        .HasMany(vg => vg.VideoGameCompanies)
                        .WithOne(c => c.VideoGame);

            modelBuilder.Entity<Company>()
                        .HasMany(vg => vg.CompanyVideoGames)
                        .WithOne(c => c.Company);

            var defaultUsers = new User[]
            {
                new User()
                {
                    FirstName = "Angel",
                    LastName = "Murchison",
                    Password = "password",
                    Email = "amurchison@email.com",
                    UserName = "amurchison",
                    GamePointBalance = 0m
                }
            };

            AssignIdsSequentially(defaultUsers);

            var companyTypes = new CompanyType[]
            {
                new CompanyType()
                {
                    Code = "DEV",
                    Name = "Developer"
                },
                new CompanyType()
                {
                    Code = "PUB",
                    Name = "Publisher"
                }
            };

            AssignIdsSequentially(companyTypes);

            modelBuilder.Entity<User>().HasData(defaultUsers);
            modelBuilder.Entity<CompanyType>().HasData(companyTypes);


            base.OnModelCreating(modelBuilder);
        }

        private BaseEntity[] AssignIdsSequentially(BaseEntity[] entities)
        {
            for (int index = 0; index < entities.Length; index++)
            {
                entities[index].Id = index + 1;
            }

            return entities;
        }

        private Transaction[] ProduceTransactions(int count)
        {
            var transactions = new Transaction[count];

            for (int i = 0; i < count; i++)
            {
                transactions[i] = new Transaction()
                {
                    CustomerId = 1,
                    VideoGameId = 2
                };
            }

            return transactions;
        }
    }
}