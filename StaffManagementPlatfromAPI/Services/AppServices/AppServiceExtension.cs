using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StaffManagementPlatfromAPI.DataAccess.Context;
using StaffManagementPlatfromAPI.DataAccess.Implimentations;
using StaffManagementPlatfromAPI.Domain.Repositories.UnitOfWork;
using System.Text.Json.Serialization;

namespace StaffManagementPlatfromAPI.Services.AppServices
{
    public static class AppServiceExtension
    {
        public static WebApplication ConfigureAppService(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers(option =>
            {
                option.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();

            builder.Services.AddSwaggerGen();
            builder.Services.AddMvc().AddJsonOptions(json => json.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("StaffManagementConnection")));
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return builder.Build();
        }
       

        public static WebApplication ConfigureAppPipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
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

            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseCors("corsPolicy");
            app.MapControllers();

            return app;
        }
    }
}

/*
  //public static WebApplication ConfigureAppPipeline(this WebApplicationBuilder builder)
        //{
        //    var app = builder.Build();
        //    if (app.Environment.IsDevelopment())
        //    {
        //        app.UseSwagger();
        //        app.UseSwaggerUI();
        //        app.UseDeveloperExceptionPage();
        //    }
        //    app.UseAuthorization();
        //    app.MapControllers();
        //    return app;
        //}
    */


/*
  // Add services to the container
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        builder.Services.AddScoped<ICourseLibraryRepository, 
            CourseLibraryRepository>();

        builder.Services.AddDbContext<CourseLibraryContext>(options =>
        {
            options.UseSqlite(@"Data Source=library.db");
        });

        builder.Services.AddAutoMapper(
            AppDomain.CurrentDomain.GetAssemblies());

        return builder.Build();
    }
 */