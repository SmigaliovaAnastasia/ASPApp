using Microsoft.EntityFrameworkCore;
using ASPApp.Bll.Services;
using ASPApp.Bll.Mappings;
using ASPApp.Domain.Entities;
using ASPApp.Dal;
using Microsoft.AspNetCore.Identity;
using ASPApp.Domain.Entities.Auth;
using ASPApp.Dal.Repository.Repositories;
using ASPApp.Dal.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using ASPApp.Bll.Interfaces;

namespace ASPApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
        });

        builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("BoardGameApp")));
        builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:securityKey"]))
                };
            });

        builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile));
        builder.Services.AddAutoMapper(typeof(CollectionGameMappingProfile));
        builder.Services.AddAutoMapper(typeof(CollectionMappingProfile));
        builder.Services.AddAutoMapper(typeof(GameMappingProfile));
        builder.Services.AddAutoMapper(typeof(ReviewMappingProfile));

        builder.Services.AddScoped<DbContext, ApplicationContext>();
        builder.Services.AddScoped(typeof(IGameRepository<Game>), typeof(GameRepository));
        builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        builder.Services.AddScoped<ICollectionService, CollectionService>();
        builder.Services.AddScoped<IGameService, GameService>();
        builder.Services.AddScoped<IGenreService, GenreService>();
        builder.Services.AddScoped<IComplexityLevelService, ComplexityLevelService>();
        builder.Services.AddScoped<IReviewService, ReviewService>();
        builder.Services.AddScoped<ICollectionGameService, CollectionGameService>();
        builder.Services.AddControllers().AddNewtonsoftJson();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHsts();
        }

        app.UseExceptionHandler("/Error");

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors(configurePolicy => configurePolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.MapControllers();

        app.Run();
    }
}