using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using DonationBlazorServerSide.Areas.Identity;
using DonationBlazorServerSide.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//     .AddEntityFrameworkStores<DonationContext>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(
options => {
    options.Stores.MaxLengthForKeys = 128;
})
.AddEntityFrameworkStores<DonationContext>()
.AddRoles<IdentityRole>()
.AddDefaultUI()
.AddDefaultTokenProviders();



builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<DonationContext>(options =>
    options.UseSqlite(connectionString));


builder.Services.AddScoped<ContactService>();
builder.Services.AddScoped<DonationService>();
builder.Services.AddScoped<TransactionTypeService>();
builder.Services.AddScoped<PaymentMethodService>();


builder.Services.AddHttpClient();

// For handling the .include queries in Linq
builder.Services.AddControllers().AddNewtonsoftJson(options =>
  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


// builder.Services.AddAuthorization(options =>
// {
//     options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
// });

var app = builder.Build(); //==========================

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

//Calling the Initialize method from IdentitySeedData class. It runs when you run this project. dotnet watch
// using (var scope = app.Services.CreateScope()) {
//     var services = scope.ServiceProvider;

//     var context = services.GetRequiredService<DonationContext>();    
//     context.Database.Migrate();

//     var userMgr = services.GetRequiredService<UserManager<IdentityUser>>();  
//     var roleMgr = services.GetRequiredService<RoleManager<IdentityRole>>();  

//     IdentitySeedData.Initialize(context, userMgr, roleMgr).Wait();
// }


app.Run();
