using GymServices.OrderService;
using GymServices.OrderService.Interface;
using GymServices.TrainerService;
using GymServices.TrainerService.Interface;
using GymServices.UsersService;
using GymServices.Utils;
using GymServices.Utils.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IUsers,Users>();
builder.Services.AddTransient<IOrders, Orders>();
builder.Services.AddTransient<ITrainer, Trainer>();
builder.Services.AddScoped<IMail, Mail>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
