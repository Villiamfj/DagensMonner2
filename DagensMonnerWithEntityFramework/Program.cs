using DagensMonnerWithEntityFramework.Data;
using DagensMonnerWithEntityFramework.Models;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("monner-db")!;
IMonnerController controller = new MonnerController(connectionString);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton(controller);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseStaticFiles();
app.MapRazorPages();
app.MapFallbackToPage("/notFound");

app.MapGet("/monner", () =>
{
    try
    {
        return Results.Json(controller.GetMonner());
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        return Results.Problem("something went wrong");
    }
});

app.Run();