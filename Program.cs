using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebRestoran.Data;
using WebRestoran.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Register the generic repository for DI
builder.Services.AddScoped(typeof(IRepo<>), typeof(Repository<>));

// Register other dependencies
builder.Services.AddScoped<IRepo<Food>, Repository<Food>>();
builder.Services.AddScoped<IRepo<Ingredient>, Repository<Ingredient>>();
builder.Services.AddScoped<IRepo<Category>, Repository<Category>>();
builder.Services.AddScoped<IRepo<FoodIngredient>, Repository<FoodIngredient>>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); // session expires after 20 minutes of inactivity
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();   //enable session state
app.UseAuthentication();
app.UseAuthorization(); //enable authorization

// Auto-assign 'User' role on first authenticated request
app.Use(async (context, next) =>
{
    if (context.User?.Identity?.IsAuthenticated == true)
    {
        var userManager = context.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = context.RequestServices.GetRequiredService<RoleManager<IdentityRole>>();
        var user = await userManager.GetUserAsync(context.User);
        if (user != null)
        {
            var roles = await userManager.GetRolesAsync(user);
            if (roles == null || roles.Count == 0)
            {
                if (!await roleManager.RoleExistsAsync("User"))
                {
                    await roleManager.CreateAsync(new IdentityRole("User"));
                }
                await userManager.AddToRoleAsync(user, "User");
            }
        }
    }
    await next();
});
app.MapStaticAssets();

// Custom authentication routes
app.MapControllerRoute(
    name: "auth",
    pattern: "auth/{action=Login}",
    defaults: new { controller = "Account" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Only map Razor Pages for Identity management (profile, etc.)
app.MapRazorPages()
   .WithStaticAssets();

// Seed roles on startup
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roles = new[] { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

app.Run();
