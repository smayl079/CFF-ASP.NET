var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Serve static files (CSS, JS, images, etc.)
app.UseStaticFiles();

// Enable default files (index.html)
app.UseDefaultFiles();

// Route for all HTML pages
app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync("templatemo_561_purple_buzz/index.html");
});

app.MapGet("/index.html", async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync("templatemo_561_purple_buzz/index.html");
});

app.MapGet("/about.html", async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync("templatemo_561_purple_buzz/about.html");
});

app.MapGet("/work.html", async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync("templatemo_561_purple_buzz/work.html");
});

app.MapGet("/pricing.html", async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync("templatemo_561_purple_buzz/pricing.html");
});

app.MapGet("/contact.html", async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync("templatemo_561_purple_buzz/contact.html");
});

app.MapGet("/work-single.html", async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync("templatemo_561_purple_buzz/work-single.html");
});

app.Run();