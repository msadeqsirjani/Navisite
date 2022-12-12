var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapGet("/Ping", () => Results.Ok("Pong"))
    .WithName("Ping")
    .WithOpenApi();

app.MapGet("/Download", (string filename, IWebHostEnvironment env) =>
    {
        var path = Path.Combine(env.WebRootPath, filename);

        return File.Exists(path) ? Results.File(File.ReadAllBytes(path)) : Results.NotFound();
    })
    .WithName("Download")
    .WithOpenApi();

app.Run();