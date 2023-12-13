
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DonationModel.Model;

namespace DonationModel.Data
{
    public class DonationContext : IdentityDbContext<IdentityUser>
    {
        
        //public DonationContext(DbContextOptions options) : base(options) { }
        
        public DonationContext(DbContextOptions<DonationContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<Contact>().Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            builder.Entity<Contact>().Property(p => p.LastName).HasMaxLength(100);

            builder.Entity<Contact>().Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(100)
            .HasAnnotation("RegEx", @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$")
            .IsUnicode();


            builder.Entity<Contact>().Property(p => p.Street).HasMaxLength(255);
            builder.Entity<Contact>().Property(p => p.City).HasMaxLength(100);
            builder.Entity<Contact>().Property(p => p.PostalCode).HasMaxLength(20);
            builder.Entity<Contact>().Property(p => p.Country).HasMaxLength(100);

           

                // builder.Entity<NewsLetterTitle>().ToTable("NewsLetterTitles");
                // builder.Entity<NewsletterArticle>().ToTable("NewsletterArticles");
                

                // builder.Entity<NewsLetterTitle>().HasData(SampleData.GetArticles());
                // builder.Entity<NewsletterArticle>().HasData(SampleData.GetArticleDetails());

            builder.Entity<IdentityRole>().HasData(
                new {Id = "1", Name = "Admin", NormalizedName = "ADMIN"},
                new { Id = "2", Name = "Finance", NormalizedName = "FINANCE" }
            );

            // Seed users
            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "1",
                    UserName = "a@a.a",
                    NormalizedUserName = "A@A.A",
                    Email = "a@a.a",
                    NormalizedEmail = "A@A.A",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "P@$$w0rd"),
                    SecurityStamp = string.Empty
                },
                new IdentityUser
                {
                    Id = "2",
                    UserName = "f@f.f",
                    NormalizedUserName = "F@F.F",
                    Email = "f@f.f",
                    NormalizedEmail = "F@F.F",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "P@$$w0rd"),
                    SecurityStamp = string.Empty
                }
            );

            // Assign roles to users
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "1", RoleId = "1" }, // Admin role for user with Id = 1
                new IdentityUserRole<string> { UserId = "2", RoleId = "2" }  // Finance role for user with Id = 2
            );
            
             // Seed to Contact entity.
            builder.Entity<Contact>().HasData(
                  new Contact
                {
                    AccountNo = 1,
                    FirstName = "Sam",
                    LastName = "Fox",
                    Email = "sam@fox.com",
                    Street = "457 Fox Avenue",
                    City = "Richmond",
                    PostalCode = "V4F 1M7",
                    Country = "Canada",
                    Created = DateTime.UtcNow.AddDays(-4),
                    Modified = DateTime.UtcNow.AddDays(-4),
                    CreatedBy = "f@f.f",
                    ModifiedBy = "f@f.f"
                },
                new Contact
                {
                    AccountNo = 2,
                    FirstName = "Ann",
                    LastName = "Day",
                    Email = "ann@day.com",
                    Street = "231 River Road",
                    City = "Delta",
                    PostalCode = "V6G 1M6",
                    Country = "Canada",
                    Created = DateTime.UtcNow.AddDays(-3),
                    Modified = DateTime.UtcNow.AddDays(-3),
                    CreatedBy = "f@f.f",
                    ModifiedBy = "f@f.f"
                },
                new Contact
                {
                    AccountNo = 3,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@doe.com",
                    Street = "123 Main St",
                    City = "Anytown",
                    PostalCode = "12345",
                    Country = "USA",
                    Created = DateTime.UtcNow.AddDays(-2),
                    Modified = DateTime.UtcNow.AddDays(-2),
                    CreatedBy = "a@a.a",
                    ModifiedBy = "a@a.a"
                },
                new Contact
                {
                    AccountNo = 4,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane@smith.ca",
                    Street = "456 Oak St",
                    City = "Another Town",
                    PostalCode = "67890",
                    Country = "Canada",
                    Created = DateTime.UtcNow.AddDays(-1),
                    Modified = DateTime.UtcNow.AddDays(-1),
                    CreatedBy = "f@f.f",
                    ModifiedBy = "f@f.f"
                },
                new Contact
                {
                    AccountNo = 5,
                    FirstName = "Tim",
                    LastName = "Hick",
                    Email = "tim@hick.ca",
                    Street = "456 Dayanee St",
                    City = "Coquitlam",
                    PostalCode = "V3A0E1",
                    Country = "Canada",
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    CreatedBy = "f@f.f",
                    ModifiedBy = "f@f.f"
                }
                             
            );           
            // Seed to TransactionType entity.
            builder.Entity<TransactionType>().HasData(
                new TransactionType
                {
                    TransactionTypeId = 1,
                    Name = "General Donation",
                    Description = "Donations made without any special purpose",
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    CreatedBy = "a@a.a", // Provide the appropriate user or system identifier
                    ModifiedBy = "a@a.a" // Provide the appropriate user or system identifier
                },
                new TransactionType
                {
                    TransactionTypeId = 2,
                    Name = "Food for homeless",
                    Description = "Donations made for homeless people",
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    CreatedBy = "a@a.a",
                    ModifiedBy = "a@a.a" 
                },
                new TransactionType
                {
                    TransactionTypeId = 3,
                    Name = "Repair of Gym",
                    Description = "Donations for the purpose of upgrading the gym",
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    CreatedBy = "a@a.a", 
                    ModifiedBy = "a@a.a"
                }
                
            );
            // Seed to PaymentMethod entity.
            builder.Entity<PaymentMethod>().HasData(
                new PaymentMethod
                {
                    PaymentMethodId = 1,
                    Name = "Direct Deposit",
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    CreatedBy = "a@a.a",
                    ModifiedBy = "a@a.a"
                },
                new PaymentMethod
                {
                    PaymentMethodId = 2,
                    Name = "PayPal",
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    CreatedBy = "a@a.a",
                    ModifiedBy = "a@a.a"
                },
                new PaymentMethod
                {
                    PaymentMethodId = 3,
                    Name = "Check",
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    CreatedBy = "a@a.a",
                    ModifiedBy = "a@a.a"
                }
                
            );
            // Seed to Donation entity.
            builder.Entity<Donation>().HasData(
                new Donation
                {
                    TransId = 1,
                    Date = DateTime.UtcNow,
                    Amount = 100.00f,
                    Notes = "General donation",
                    AccountNo = 1, 
                    TransactionTypeId = 1,
                    PaymentMethodId = 1, 
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    CreatedBy = "f@f.f",
                    ModifiedBy = "f@f.f"
                },
                new Donation
                {
                    TransId = 2,
                    Date = DateTime.UtcNow,
                    Amount = 50.00f,
                    Notes = "Monthly contribution",
                    AccountNo = 2, 
                    TransactionTypeId = 2, 
                    PaymentMethodId = 2,
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    CreatedBy = "f@f.f",
                    ModifiedBy = "f@f.f"
                }
                ,
                new Donation
                {
                    TransId = 3,
                    Date = DateTime.UtcNow,
                    Amount = 200.00f,
                    Notes = "Yearly contribution",
                    AccountNo = 3, 
                    TransactionTypeId = 3, 
                    PaymentMethodId = 3,
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    CreatedBy = "f@f.f",
                    ModifiedBy = "f@f.f"
                },
                new Donation
                {
                    TransId = 4,
                    Date = DateTime.UtcNow,
                    Amount = 50.00f,
                    Notes = "Monthly contribution",
                    AccountNo = 1, 
                    TransactionTypeId = 2, 
                    PaymentMethodId = 2,
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    CreatedBy = "f@f.f",
                    ModifiedBy = "f@f.f"
                },
                new Donation
                {
                    TransId = 5,
                    Date = DateTime.UtcNow,
                    Amount = 50.00f,
                    Notes = "Monthly contribution",
                    AccountNo = 1, 
                    TransactionTypeId = 2, 
                    PaymentMethodId = 2,
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    CreatedBy = "f@f.f",
                    ModifiedBy = "f@f.f"
                },
                new Donation
                {
                    TransId = 6,
                    Date = DateTime.UtcNow,
                    Amount = 50.00f,
                    Notes = "Monthly contribution",
                    AccountNo = 1, 
                    TransactionTypeId = 2, 
                    PaymentMethodId = 2,
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    CreatedBy = "f@f.f",
                    ModifiedBy = "f@f.f"
                }
            
            );

            // builder.Entity<Donation>().HasData(GetDonations());
            
        }

        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<Donation>? Donations { get; set; }
        public DbSet<PaymentMethod>? PaymentMethods { get; set; }
        public DbSet<TransactionType>? TransactionTypes { get; set; }


        
        // private static IEnumerable<Donation> GetDonations() {
        //     string[] p = { Directory.GetCurrentDirectory(), "../DonationModel", "Donations.csv" };
        //     var csvFilePath = Path.Combine(p);

        //     var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
        //         PrepareHeaderForMatch = args => args.Header.ToLower(),
        //     };

        //     var data = new List<Donation>().AsEnumerable();
        //     using (var reader = new StreamReader(csvFilePath)) {
        //         using (var csvReader = new CsvReader(reader, config)) {
        //             data = csvReader.GetRecords<Donation>().ToList();
        //         }
        //     }
        //     return data;
        // }

    }
}