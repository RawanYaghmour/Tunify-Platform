using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Tunify_Platform.Data;
using Tunify_Platform.Repositories.Interfaces;
using Tunify_Platform.Repositories.Services;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });
            string ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<TunifyDbContext>(optionsX => optionsX.UseSqlServer(ConnectionStringVar));



            // Identity
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<TunifyDbContext>();

            //builder.Services
            builder.Services.AddScoped<IAccountRepository, IdentityAccountService>();




            //for Repoditory pattern
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            builder.Services.AddScoped<ISongRepository, SongRepository>();
            builder.Services.AddScoped<IArtistRepository, ArtistRepository>();



            // swagger configuration
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("tunifyApi", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Tunify API",
                    Version = "v1",
                    Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                });
            });



            var app = builder.Build();

            //app.UseAuthentication();
            app.UseAuthentication();



            // call swagger service
            app.UseSwagger(
             options =>
             {
                 options.RouteTemplate = "api/{documentName}/swagger.json";
             });

            // call swagger UI
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/tunifyApi/swagger.json", "Tunify API v1");
                options.RoutePrefix = "";
            });




            app.MapControllers();

           // app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
