using GiniHomeTask.Services;
using GiniHomeTask.Services.Inerfaces;
using GiniTask.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<RepoSearch>(builder.Configuration.GetSection("RepoSearch"));
builder.Services.AddTransient<IReposService, ReposService>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".GiniHomeTask.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSession();

app.UseRouting();
// Configure the HTTP request pipeline.


app.UseAuthorization();

app.MapControllers();

app.Run();
