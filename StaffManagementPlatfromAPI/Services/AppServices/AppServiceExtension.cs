using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StaffManagementPlatfromAPI.DataAccess.Context;
using StaffManagementPlatfromAPI.DataAccess.Implimentations;
using StaffManagementPlatfromAPI.Domain.Repositories.UnitOfWork;
using System.Text;
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
            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Authentication:Issuer"],
                        ValidAudience = builder.Configuration["Authentication:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
                    };
                });
            builder.Services.AddApiVersioning(setupAction =>
            {

                setupAction.AssumeDefaultVersionWhenUnspecified = true;
                setupAction.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                setupAction.ReportApiVersions = true;
            });

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

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseCors("corsPolicy");
            app.MapControllers();

            return app;
        }
    }
}


