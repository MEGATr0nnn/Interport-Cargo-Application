using IAB251_Assignment_2_Project_Final.Models;
using System.Reflection;

//ensuring users have installed the DB package to run this program package has been added as a dependency into the .csproj file 
try
{
    Assembly.Load("Microsoft.Data.Sqlite");
    Console.WriteLine("Assembly Loaded Sucessfully");
}
catch (FileNotFoundException)
{
    throw new InvalidOperationException("The required package 'Microsoft.Data.Sqlite' is not installed. Please install it using the following command: \n\n" +
                                               "Install-Package Microsoft.Data.Sqlite\n\n" +
                                               "or, using .NET CLI:\n\n" +
                                               "dotnet add package Microsoft.Data.Sqlite");
}


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