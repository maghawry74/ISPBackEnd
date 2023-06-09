using Ecommerce.API.MiddleWare;
using ISP.BL;
using ISP.DAL;
using ISP.DAL.Repository.BranchRepository;
using ISP.DAL.Repository.CentralRepository;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region default

builder.Services.AddControllers();
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


#region Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion


#region Repos
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IGovernarateRepository , GovernarateRepository>();
builder.Services.AddScoped<ICentralRepository , CentralRepository >();
builder.Services.AddScoped<IProviderRepository , ProviderRepository >();
builder.Services.AddScoped<IPackageReposatory,PackageReposatory>();
#endregion


#region Services

builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IGovernarateService , GovernarateService>();
builder.Services.AddScoped<ICentalService  , CentalService>();
builder.Services.AddScoped<IProviderService , ProviderService>();
builder.Services.AddScoped<IPackageService, PackageService>();
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