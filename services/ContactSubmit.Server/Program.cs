using Microsoft.EntityFrameworkCore;
using ContactSubmit.Server.Data;
using ContactSubmit.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      });
});

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddDbContext<ContactContext>(opt => opt.UseInMemoryDatabase("ContactsList"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



string connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

builder
.Services
.AddDbContext<DatabaseContext>(op => op.UseNpgsql(connectionString));

builder.Services.AddTransient<ContactService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
