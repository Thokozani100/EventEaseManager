using EventEaseManager.Data;
using EventEaseManager.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Seed sample data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    // Seed Venues
    if (!context.Venues.Any())
    {
        context.Venues.AddRange(
            new Venue { VenueName = "Main Hall", Location = "Richards Bay", Capacity = 100, ImageUrl = "mainhall.jpg" },
            new Venue { VenueName = "Conference Room", Location = "Durban", Capacity = 50, ImageUrl = "confroom.jpg" }
        );
    }

    // Seed Events
    if (!context.Events.Any())
    {
        context.Events.AddRange(
            new Event { EventName = "Tech Expo", EventDate = DateTime.Today, Description = "Technology showcase", VenueId = 1 },
            new Event { EventName = "Fitness Workshop", EventDate = DateTime.Today.AddDays(7), Description = "Health and fitness event", VenueId = 2 }
        );
    }

    context.SaveChanges();
}

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Bookings}/{action=Index}/{id?}");

app.Run();