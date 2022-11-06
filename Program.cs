using ASPApp.Dal.Repository;
using Microsoft.EntityFrameworkCore;
using ASPApp.Bll.Services;
using ASPApp.Bll.Mappings;
using ASPApp.Domain.Entities;

namespace ASPApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<GameContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("BoardGameApp")));

        builder.Services.AddAutoMapper(typeof(GameMappingProfile));
        builder.Services.AddScoped<DbContext, GameContext>();
        builder.Services.AddScoped(typeof(IRepository<Game>), typeof(GameRepository));
        builder.Services.AddScoped<IGameService, GameService>();
        builder.Services.AddControllers().AddNewtonsoftJson();

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

        //app.UseCustomErrorMiddleware();

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseCors(configurePolicy => configurePolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.MapControllers();
       
        app.Run();
    }
}