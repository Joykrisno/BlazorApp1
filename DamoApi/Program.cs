using BusinessLogic;
using DamoModels.Models;
using Microsoft.EntityFrameworkCore;

 var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<EmployeDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConString"));
            });

            builder.Services.AddScoped<IEmployeService,EmployeService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
   
