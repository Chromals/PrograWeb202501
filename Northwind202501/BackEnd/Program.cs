using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Serilog

builder.Logging.ClearProviders();
builder.Host.UseSerilog((ctx,lc   )=> lc
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day) 
    .MinimumLevel.Error()
    );

#endregion

#region BD
builder.Services.AddDbContext<NorthWindContext>(optionsAction =>
                    optionsAction
                    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

    );

builder.Services.AddDbContext<AuthDBContext>(optionsAction =>
                    optionsAction
                    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

    );

#endregion


#region Identity

    builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AuthDBContext>()
        .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
   options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;

});
#endregion

#region DI

builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryDAL, CategoryDAL>();
builder.Services.AddScoped<ISupplierDAL, SupplierDAL>();
builder.Services.AddScoped<IProductDAL, ProductDAL>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ApiKeyMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
