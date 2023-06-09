using Ecommerce.API.MiddleWare;
using FluentValidation.AspNetCore;
using ISP.BL;
using ISP.BL.Services.OfferService;
using ISP.BL.Services.RoleService;
using ISP.DAL;
using ISP.DAL.Repository.BranchRepository;
using ISP.DAL.Repository.CentralRepository;
using ISP.DAL.Repository.OfferRepository;
using ISP.DAL.Repository.RoleRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region default

builder.Services.AddControllers()
      .AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<CentralWriteValidation>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion



#region Configure CORS
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder
         .AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader();

}));

#endregion

#region Database configuration

var connetionstring = builder.Configuration.GetConnectionString("connction_string");

builder.Services.AddDbContext<ISPContext>(
    options => options.UseSqlServer(connetionstring));

#endregion

#region Identity Services

builder.Services
    .AddIdentity<User, IdentityRole>(options =>
    {
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 4;
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<ISPContext>();

#endregion


#region Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region Authentication 

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Cool";
    options.DefaultChallengeScheme = "Cool";
})
.AddJwtBearer("Cool", options =>
{
    var secretKeyString = builder.Configuration.GetValue<string>("SecretKey");
    var secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
    var secretKey = new SymmetricSecurityKey(secretyKeyInBytes);
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = secretKey,
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

#endregion


#region Repos
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IGovernarateRepository , GovernarateRepository>();
builder.Services.AddScoped<ICentralRepository , CentralRepository >();
builder.Services.AddScoped<IProviderRepository , ProviderRepository >();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();

#endregion


#region Services

builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IGovernarateService , GovernarateService>();
builder.Services.AddScoped<ICentalService  , CentalService>();
builder.Services.AddScoped<IProviderService , ProviderService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IOfferService, OfferService>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandlingMiddleware();
}

app.UseCors("MyPolicy");
 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();