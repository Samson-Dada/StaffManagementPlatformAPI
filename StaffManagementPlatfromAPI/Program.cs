using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.DataAccess.Context;
using StaffManagementPlatfromAPI.DataAccess.Implimentations;
using StaffManagementPlatfromAPI.Domain.Repositories.UnitOfWork;
using StaffManagementPlatfromAPI.Services;
using StaffManagementPlatfromAPI.Services.AppServices;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
ConfigurationCorsServices.Configure(builder.Services);
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddMvc().AddJsonOptions(
//    json => json.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//builder.Services.AddDbContext<ApplicationContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("StaffManagementConnection"));
//});
//builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Configure the HTTP request pipeline.
var app = builder
    .ConfigureAppService()
    .ConfigureAppPipeline();


//var app = builder.Build();





/*

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler(appBuilder =>
             appBuilder.Run(async context =>
           {
                 context.Response.StatusCode = 500;
                 await context.Response.WriteAsync("An unexpected fault happend. Try again later");
             }
             ));
}


app.UseHttpsRedirection();
app.UseCors("corsPolicy");
app.UseAuthorization();

app.MapControllers();
*/
app.Run();
