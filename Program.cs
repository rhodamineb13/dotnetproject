using dotnetproject.Helpers;
using dotnetproject.Data;
using Microsoft.EntityFrameworkCore;

public class Programs {
    public static void Main(string []args) {
        var builder = WebApplication.CreateBuilder(args);

        EnvConfig e = new EnvConfig();
        e.Load(".env");
        Dictionary<string, string> eDict = e.EnvVariables;

        builder.Services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseNpgsql($"Host={eDict["DATABASE_HOST"]};Port={eDict["DATABASE_PORT"]};Username={eDict["DATABASE_USER"]};Password={eDict["DATABASE_PASS"]};Database={eDict["DATABASE_NAME"]}");
        });

        builder.Services.AddBookService();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.MapControllers();
        app.Run();
    }
}


