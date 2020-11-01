using AutoMapper;
using GameShelf.Domain;
using GameShelf.Repository.Commands.Games;
using GameShelf.Repository.Commands.Users;
using GameShelf.Repository.Queries.Games;
using GameShelf.Repository.Queries.Users;
using GameShelf.Services.Game;
using GameShelf.Services.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GameShelf.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();
            
            // Register the Swagger services
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "GameShelf API";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Kurt Lim",
                        Email = "klim049@gmail.com",
                        Url = "https://github.com/kurtlnz"
                    };
                };
            });

            // Register dependencies
            RegisterServices(services);
            RegisterCommands(services);
            RegisterQueries(services);
            
            services.AddAutoMapper(typeof(Startup));
            
            services.AddDbContext<GameShelfContext>(opt => opt
                .UseNpgsql(Configuration.GetConnectionString("(default)")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IUserService, UserService>();
        }

        private static void RegisterCommands(IServiceCollection services)
        {
            // Games
            services.AddTransient<IAddGameCommand, AddGameCommand>();
            services.AddTransient<IDeleteGameCommand, DeleteGameCommand>();
            services.AddTransient<IUpdateGameCommand, UpdateGameCommand>();
            
            // Users
            services.AddTransient<IAddUserCommand, AddUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
        }

        private static void RegisterQueries(IServiceCollection services)
        {
            // Games
            services.AddTransient<IGetGameQuery, GetGameQuery>();
            services.AddTransient<IGetAllGamesQuery, GetAllGamesQuery>();
            
            // Users
            services.AddTransient<IGetUserQuery, GetUserQuery>();
            services.AddTransient<IGetAllUsersQuery, GetAllUsersQuery>();
        }
    }
}