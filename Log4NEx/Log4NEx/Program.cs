using Microsoft.Extensions.Logging; // Add this using directive if not already present
using log4net.Config; // Add this using directive to configure log4net

var builder = WebApplication.CreateBuilder(args);

// 👇 Add log4net as logging provider
builder.Logging.ClearProviders();
builder.Logging.AddProvider(new Log4NetProvider("log4net.config")); // Use Log4NetProvider explicitly

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();