// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
// using Microsoft.Extensions.Configuration;

// namespace DonationModel
// {
//     public class DonationContextFactory : IDesignTimeDbContextFactory<DonationContext>
//     {
//         public DonationContext CreateDbContext(string[] args)
//         {
//             IConfigurationRoot configuration = new ConfigurationBuilder()
//                 .SetBasePath(AppContext.BaseDirectory)
//                 .AddJsonFile("appsettings.json")
//                 .Build();

//             var builder = new DbContextOptionsBuilder<DonationContext>();
//             var connectionString = configuration.GetConnectionString("DataSource=Donation.db;Cache=Shared"); // Replace with your connection string name
//             builder.UseSqlite(connectionString);

//             return new DonationContext(builder.Options);
//         }
//     }
// }