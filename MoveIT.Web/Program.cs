using Microsoft.EntityFrameworkCore;
using MoveIT.Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MoveITContext>(opt =>
    opt.UseInMemoryDatabase("Customers"));
builder.Services.AddSwaggerGen(c =>
{
   c.SwaggerDoc("v1", new() { Title = "OfferApi", Version = "v1" });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OfferApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
