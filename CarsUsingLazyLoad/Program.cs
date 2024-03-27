using CarsUsingLazyLoad.Data.Context;
using CarsUsingLazyLoad.Repository;
using CarsUsingLazyLoad.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MySqlContext>(options =>
{
  var connectionString = "server=localhost;port=3306;database=cars_lazy_load;user=root;password=1234";
  options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 34)));
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.UseCors(options =>
    options.AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin()
);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
