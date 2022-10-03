using ASPApp.Dal.Repository;
using ASPApp.WebAPI.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using static ASPApp.WebAPI.Extensions.MiddlewareExtensions;
namespace ASPApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<GameContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("BoardGameApp")));

        //var mapperConfig = new MapperConfiguration(m =>
        //{
        //    m.AddProfile(new GameMappingProfile());
        //});
        //builder.Services.AddSingleton(mapperConfig.CreateMapper());

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseExceptionHandler("/Error");

        app.UseCustomErrorMiddleware();

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}