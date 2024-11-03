using IAB251_Assignment_2_Project_Final.Models;

var builder = WebApplication.CreateBuilder(args);


try
{
    // Check DB state before building the app
    ConnectionControler connectionControler = new ConnectionControler();
    if (!connectionControler.checkConState())
    {
        throw new Exception("Database connection failed.");
    }

    // Continue building application normally
    builder.Services.AddSingleton<IUserSessionControl, UserSessionService>();
    builder.Services.AddRazorPages();
}
catch (Exception ex)
{
    // Log the error (consider using a logging framework)
    Console.WriteLine($"FATAL ERROR: {ex.Message}");

    // Set up a minimal app to show the error page
    var errorApp = WebApplication.CreateBuilder(args).Build();
    errorApp.MapGet("/", () => Results.Redirect("/Error"));
    errorApp.Run();
    return; // Exit to avoid running the normal app logic
}

// Build application normally if connection is successful
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();