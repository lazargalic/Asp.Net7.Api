using API.Core;
using Implementation.Validators;
using Application.Logging;
using Application.UseCases.Commands;
using DataAccess;
using Implementation.Logging;
using Implementation.UseCases.Commands.Ef;
using Implementation.UseCases;
using Implementation.UseCases.Queries.Ef;
using Application.UseCases.Queries.Searches;
using Application.UseCases.Dto;
using Application.UseCases.Commands.AdminCommands;
using Implementation.UseCases.Commands.Ef.AdminEfCommands;
using Application;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.UseCases.Queries;
using Application.UseCases;
using Implementation.UseCases.Queries.Ef.AdminEfQueryies;
using Microsoft.OpenApi.Models;
using Application.UseCases.Queries.AdminQueries;
using AutoMapper;
using Implementation.AutoMapper;
using Implementation.Email;
using Application.Emails;
using API.Core.TokenStorage;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//builder.Services.AddSwaggerGen();
//////////////////////////////ZA AUTORIZACIJU U SWAGGERU 
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lazar Galic", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter ONLY your token in the text input below.
                      \r\n\r\nExample: '12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",

    });

    //Dokumentacija xml-a
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
//////////////////////////////////////////
///// Bindovanje Sa Konfiguracijom
var settings = new AppSettings();
builder.Configuration.Bind(settings);
builder.Services.AddSingleton(settings);
//////////////


///////////////////////////////My Dependency Operations Start
builder.Services.AddTransient<IEmailSender>(x =>
                    new SmtpEmailSender(settings.EmailOptions.FromEmail,
                                        settings.EmailOptions.Password,
                                        settings.EmailOptions.Port,
                                        settings.EmailOptions.Host));

builder.Services.AddTransient<Asp2023DbContext>();
builder.Services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
builder.Services.AddTransient<UseCaseHandler>();
builder.Services.AddTransient<EmptySearchDto>();
builder.Services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
builder.Services.AddTransient<RegisterUserValidator>();
builder.Services.AddTransient<IAdminGetAllRegisteredUsers, EfAdminGetAllRegisteredUsersQuery>();
builder.Services.AddTransient<SearchRegisteredUsersDto>();
builder.Services.AddTransient<IAddUseCaseToUserCommand, EfAddUseCaseToUserCommand>();
builder.Services.AddTransient<IDeleteUseCaseUserCommand, EfDeleteUseCaseUserCommand>();
builder.Services.AddTransient<IAddUseCaseToRoleCommand, EfAddUseCaseToRoleCommand>();
builder.Services.AddTransient<IDeleteUseCaseToRoleCommand, EfDeleteUseCaseToRoleCommand>(); //
//builder.Services.AddTransient<JwtManager>(settings.JwtSettings);   // 
builder.Services.AddTransient<JwtManager>(x =>
{
    var context = x.GetService<Asp2023DbContext>();
    var tokenStorage = x.GetService<ITokenStorage>();
    return new JwtManager(context, settings.JwtSettings.Issuer, settings.JwtSettings.SecretKey, settings.JwtSettings.Minutes, tokenStorage);
});

builder.Services.AddTransient<AddEmotionValidator>();
builder.Services.AddTransient<UpdateEmotionValidator>();
builder.Services.AddTransient<UpdateStickerValidator>();
builder.Services.AddTransient<IAddEmotionCommand, EfAddEmotionCommand>();
builder.Services.AddTransient<IDeleteEmotionCommand, EfDeleteEmotionCommand>();
builder.Services.AddTransient<IGetAllEmotionQuery, EfGetAllEmotionQuery>();
builder.Services.AddTransient<IEditEmotionCommand, EfEditEmotionCommand>();
builder.Services.AddTransient<IGetAllCountriesWithTownshipsQuery, EfGetAllCountriesWithTownshipsQuery>();
builder.Services.AddTransient<IGetAllTownshipsInOneCountry, EfGetAllTownshipsInOneCountry>();
builder.Services.AddTransient<IAddUserCompanyCommand, EfAddUserCompanyCommand>();
builder.Services.AddTransient<IDeleteUserCompanyCommand, EfDeleteUserCompanyCommand>();
builder.Services.AddTransient<IGetUsersCompanies, EfGetUsersCompaniesQuery>();
builder.Services.AddTransient<IAddStickerCommand, EfAddStickerCommand>();
builder.Services.AddTransient<AddStickerValidation>();
builder.Services.AddTransient<IGetStickersQuery, EfGetStickersQuery>();
builder.Services.AddTransient<IDeleteStickerCommand, EfDeleteStickerCommand>();
builder.Services.AddTransient<IEditStickerCommand, EfEditStickerCommand>();
builder.Services.AddTransient<IAddPostNonRegisteredUser, EfAddPostNonRegisteredUser>();
builder.Services.AddTransient<AddPostValidator>();
builder.Services.AddTransient<NonRegisteredUserValidator>();
builder.Services.AddTransient<IAddPostRegisteredUser, EfAddPostRegisteredUser>();
builder.Services.AddTransient<IAddCommentRegisteredUserCommand, EfUserAddCommentCommand>();
builder.Services.AddTransient<IGetArticlesQuery, EfGetArticlesQuery>();
builder.Services.AddTransient<IAddUserEmotionToArticleCommand, EfAddUserEmotionToArticleCommand>();
builder.Services.AddTransient<IDeleteEmotionArticleUser, EfDeleteEmotionArticleUser>();
builder.Services.AddTransient<IAuditLogLogger, EfAuditLogLogger>();
builder.Services.AddTransient<IGetAuditLogs, EfIGetAuditLogsQuery>();
builder.Services.AddTransient<IGetOneArticleQuery, EfIGetOneArticleQuery>();
builder.Services.AddTransient<IUpdateOneUserCommand, EfUpdateOneUserCommand>();
builder.Services.AddTransient<UpdateUserValidator>();
builder.Services.AddTransient<IDeleteArticleCommand, EfDeleteArticleCommand>();
builder.Services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();
builder.Services.AddTransient<ITokenStorage, InMemoryTokenStorage>();
builder.Services.AddTransient<LoginValidator>();
builder.Services.AddTransient<IGetReactionToCurrentPost, EfGetReactionToCurrentPost>();
 
///////////////////////////////My Dependency Operation End

//Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevServer",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


//////////////////////////////Token Koriscenje u projektu 
builder.Services.AddAuthentication(options =>
    {
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(cfg =>
    {
        cfg.RequireHttpsMetadata = false;
        cfg.SaveToken = true;
        cfg.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = settings.JwtSettings.Issuer,
            ValidateIssuer = true,
            ValidAudience = "Any",
            ValidateAudience = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
        cfg.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                //Token dohvatamo iz Authorization header-a

                var header = context.Request.Headers["Authorization"];
                var token = header.ToString().Split("Bearer ")[1];
                var handler = new JwtSecurityTokenHandler();
                var tokenObj = handler.ReadJwtToken(token);
                string jti = tokenObj.Claims.FirstOrDefault(x => x.Type == "jti").Value;

                //ITokenStorage
                ITokenStorage storage = context.HttpContext.RequestServices.GetService<ITokenStorage>();
                bool isValid = storage.TokenExists(jti);
                if (!isValid)
                {
                    context.Fail("Token is not valid.");
                    throw new TokenNotValidException();
                }
                return Task.CompletedTask;
            }
        };
     });
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddTransient<IApplicationUser>(x =>
    {
        var accessor = x.GetService<IHttpContextAccessor>();
        var header = accessor.HttpContext.Request.Headers["Authorization"];

        //Pristup payload-u
        //var claims = accessor.HttpContext.User;
        var claims = accessor?.HttpContext?.User;

        if (claims == null || claims.FindFirst("UserId") == null)
        {
            return new AnonymousUser();  //definisan vec 
        }

        var actor = new JwtUser
        {
            Email = claims.FindFirst("Email").Value,
            Id = Int32.Parse(claims.FindFirst("UserId").Value),
            RoleId = Int32.Parse(claims.FindFirst("RoleId").Value),
            Identity = claims.FindFirst("Identity").Value,           
            UseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
        };

        return actor;
    });
///////////////////////TOKEN KORISCENJE KRAJ  +  app.UseAuthentication(); ispod + u jwt manageru make token



///
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Angular
app.UseCors("AllowAngularDevServer");    /////
/////////////////////////////////////////////My Middleware Start
app.UseMiddleware<GlobalExceptionHandler>();
/////////////////////////////////////////////My Middleware End

app.UseHttpsRedirection();

////////////////////////////// Rad sa Tokenom za application usera dodati pre autorizacije
app.UseAuthentication();
////////////////////////////////////////////
app.UseAuthorization();
app.UseStaticFiles();


app.MapControllers();
app.Run();
