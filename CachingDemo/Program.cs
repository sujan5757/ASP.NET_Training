
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddResponseCaching();


var app = builder.Build();
app.UseHttpsRedirection();
app.UseResponseCaching();
app.MapControllers();

// Configure the HTTP request pipeline.
app.Run();


