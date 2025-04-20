using Demo.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Demo.DataAccess.Repositoriers.Interfaces;
using Demo.DataAccess.Repositoriers.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.BusinessLogic.Services.Classes;
using Microsoft.Extensions.DependencyInjection;
using Demo.BusinessLogic.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Persentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region Depndencey Injection
            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            }             
            );
            builder.Services.AddDbContext<AppDbContext>(options=> 
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
                //options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);
                //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });//Register service in Dependance Injection

            builder.Services.AddScoped<IDepartmentReprository,DepartmentReprository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



            //builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
            builder.Services.AddAutoMapper(p => p.AddProfile(new MappingProfile()));
            #endregion
            var app = builder.Build();  

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
