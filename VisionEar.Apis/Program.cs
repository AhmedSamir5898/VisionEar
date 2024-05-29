//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using VisionEar.Apis.Helper;

//using VisionEar.Core.Entities.Identity;
//using VisionEar.Core.IRepository;
//using VisionEar.Repository;
//using VisionEar.Repository.Data;
//using VisionEar.Repository.IDentity;

//namespace VisionEar.Apis
//{
//    public class Program
//    {
//        public static async Task Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
//            // Add services to the container.


//            builder.Services.AddControllers();
//            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//            builder.Services.AddEndpointsApiExplorer();
//            builder.Services.AddSwaggerGen();
//            builder.Services.AddScoped(typeof(IGenericRepositroy<>), typeof(GenericRepository<>));
//            builder.Services.AddScoped(typeof(IDashboardRepository<>), typeof(DashBoardRepository<>));
//            builder.Services.AddAutoMapper(typeof(MappingProfile));


//            builder.Services.AddDbContext<StoreContext>(Options =>
//            {
//                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"));
//            });
//            builder.Services.AddDbContext<AppIdentityDbContext>(optionsBuilder =>
//            {
//                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
//            });
//            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
//            {

//            }).AddEntityFrameworkStores<AppIdentityDbContext>(); ;
//            builder.Services.AddCors(options =>
//            {
//                options.AddPolicy(name: MyAllowSpecificOrigins,
//                                  policy =>
//                                  {
//                                      policy.WithOrigins("https://oguzevrensel.com",
//                                                          "https://www.nacres.com.tr");
//                                  });
//            });



//            var app = builder.Build();

//            #region Update DataBase
//            using var scope = app.Services.CreateScope();
//            var services = scope.ServiceProvider;
//            var _dbcontext = services.GetRequiredService<StoreContext>();
//            var _IdentityDBContect = services.GetRequiredService<AppIdentityDbContext>();
//            var loggerFactor = services.GetRequiredService<ILoggerFactory>();
//          //  var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();



//            try
//            {
//                await _dbcontext.Database.MigrateAsync();
//                await StoreContextSeed.SeedAsync(_dbcontext);
//                await _IdentityDBContect.Database.MigrateAsync();
//                var _UserManger = services.GetRequiredService<UserManager<ApplicationUser>>();
//             //   await AppIdentityDbContextDataSeeding.UserAddAsync(_UserManger);
//            }
//            catch (Exception ex)
//            {
//               // var logger = loggerFactor.CreateLogger<Program>();
//                logger.LogError(ex, "An Error Happend when update DataBase");
//            }

//            #endregion

//            // Configure the HTTP request pipeline.

//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            app.UseHttpsRedirection();
//            app.UseCors(MyAllowSpecificOrigins);


//            app.UseAuthorization();
//            app.UseStaticFiles();

//            app.MapControllers();

//            app.Run();
//        }

//    }
//}
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VisionEar.Apis.Helper;
using VisionEar.Core.Entities.Identity;
using VisionEar.Core.IRepository;
using VisionEar.Repository;
using VisionEar.Repository.Data;
using VisionEar.Repository.IDentity;
using static System.Net.WebRequestMethods;

namespace VisionEar.Apis
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped(typeof(IGenericRepositroy<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IDashboardRepository<>), typeof(DashBoardRepository<>));
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddDbContext<StoreContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"));
            });
            builder.Services.AddDbContext<AppIdentityDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {

            }).AddEntityFrameworkStores<AppIdentityDbContext>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:3000", "https://oguzevrensel.com", "https://www.nacres.com.tr")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                                  });
            });
           
            var app = builder.Build();

            #region Update DataBase
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var _dbcontext = services.GetRequiredService<StoreContext>();
            var _IdentityDBContect = services.GetRequiredService<AppIdentityDbContext>();
            var loggerFactor = services.GetRequiredService<ILoggerFactory>();
            // var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            try
            {
                await _dbcontext.Database.MigrateAsync();
                await StoreContextSeed.SeedAsync(_dbcontext);
                await _IdentityDBContect.Database.MigrateAsync();
                var _UserManger = services.GetRequiredService<UserManager<ApplicationUser>>();
                // await AppIdentityDbContextDataSeeding.UserAddAsync(_UserManger);
            }
            catch (Exception ex)
            {
                var logger = loggerFactor.CreateLogger<Program>();
                logger.LogError(ex, "An Error Happend when update DataBase");
            }
            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}