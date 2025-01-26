    using System.Text;
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using AutoMapper;
    using HotelReservationSystem.AutoMapper;
    using MediatR;
    using ProjectManagementSystem.Configrations;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using ProjectManagementSystem.Data;
    using ProjectManagementSystem.Middlewares;

    var builder = WebApplication.CreateBuilder(args);
    
    var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();
    builder.Services.AddDbContext<Context>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

    builder.Host.ConfigureContainer<ContainerBuilder>(
        container =>
        {
            container.RegisterModule<AutoFacModule>();
        });
    
    

    builder.Services.AddHttpContextAccessor();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddAutoMapper(typeof(Program).Assembly);
    builder.Services.AddMediatR(typeof(Program).Assembly);

    builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

    var jwtSettings = builder.Configuration.GetSection("JwtSettings");
    var key = Encoding.UTF8.GetBytes(jwtSettings.GetValue<string>("SecretKey"));

    builder.Services.AddAuthentication(opts =>
    {
        opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(opts =>
    {
        opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidIssuer = jwtSettings.GetValue<string>("Issuer"),
            ValidAudience = jwtSettings.GetValue<string>("Audience"),
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
        };
    });
    

    builder.Services.AddAuthorization();

    // builder.Services.AddCap(cfg =>
    // {
    //     cfg.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    //     cfg.UseEntityFramework<Context>();
    //     cfg.UseRabbitMQ(opt =>
    //     {
    //         opt.HostName = "localhost";
    //         opt.Port = 15672;
    //         opt.UserName = "guest";
    //         opt.Password = "guest";
    //         opt.ExchangeName = "cap.default.router";
    //     });
    // });

    var app = builder.Build();

    app.UseAuthentication();
    app.UseAuthorization();

    AutoMapperService._mapper = app.Services.GetService<IMapper>();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.UseMiddleware<GlobalErrorHandlerMiddleware>();
    
    app.UseMiddleware<TransactionMiddleware>();
    
    app.Run();
