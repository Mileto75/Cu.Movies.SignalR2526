using Blazor.Movies.Web.Components;
using Cu_ServicePattern_Movies.Core.Data;
using Cu_ServicePattern_Movies.Core.Interfaces;
using Cu_ServicePattern_Movies.Core.Services;
using Cu_ServicePattern_Movies.Core.Services.Interfaces;
using Cu_ServicePattern_Movies_01;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Movies.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContextFactory<MovieDbContext>(options
                => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext")));
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
            app.Run();
        }
    }
}
