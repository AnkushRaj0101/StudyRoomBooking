using Microsoft.Extensions.FileProviders;
using StudyRoomBooking.Core.Helpers;
using StudyRoomBooking.Core.Helpers.Intefaces;
using StudyRoomBooking.Core.Services;
using StudyRoomBooking.Core.Services.Interfaces;
using StudyRoomBooking.DataAccess.Configuration;
using StudyRoomBooking.DataAccess.Repositories.Interfaces;
using StudyRoomBooking.DataAccess.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services
    .RegisterDataAccessServiceDependencies(builder.Configuration);

builder.Services.AddScoped<IBookingRegistrationHelper, BookingRegistrationService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy",
        builder => builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});



builder.Services.AddCors(options =>{
    options.AddPolicy("MyCorsPolicy",
        builder => builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});


builder.Services.AddScoped<IBookingDetailsRepository, BookingDetailsRepository>();


builder.Services.AddTransient<IServiceFactory, ServiceHandlerFactory>();

Assembly.GetAssembly(typeof(ServiceHandlerFactory))
                       .GetTypes()
                       .Where(a => a.Name.EndsWith("ServiceHandler"))
                       .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
                       .ToList()
                       .ForEach(typesToRegister =>
                       {
                           typesToRegister.serviceTypes.ForEach(typeToRegister => builder.Services.AddScoped(typeToRegister, typesToRegister.assignedType));
                       });
var app = builder.Build();
app.UseCors("MyCorsPolicy");

app.UseCors("MyCorsPolicy");

// Configure the HTTP request pipeline.
var isDeployed = builder.Configuration.GetValue<bool>("Settings:IsDeployed");
if (!isDeployed && app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles")),
    RequestPath = "/app" // URL path to access the Angular app
});

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());//for Cross-origin

app.MapControllers();

app.Run();


