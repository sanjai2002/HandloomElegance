using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Core.IServices;
using HandloomElegance.Core.Services;
using HandloomElegance.Data.IRepository;
using HandloomElegance.Data.Repository;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

#region CORS setting for API
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "_myAllowSpecificOrigins",
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowAnyMethod();
        }
    );
});

#endregion

// Dbcontext
builder.Services.AddScoped<HandloomEleganceDbContext>();

builder.Services.AddScoped<IUserServices,userServices>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<ICategoryServices,CategoryServices>();
builder.Services.AddScoped<ICategoryrepoitory,CategoryRepository>();
builder.Services.AddScoped<IProductServices,ProductServices>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IOrderServices,OrderServices>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();
builder.Services.AddScoped<ICartServices,CartServices>();
builder.Services.AddScoped<ICartRepository,CartRepository>();
builder.Services.AddScoped<IAddressServices,AddressServices>();
builder.Services.AddScoped<IAddressRepository,AddressRepository>();
builder.Services.AddScoped<IReviewServices,Reviewservices>();
builder.Services.AddScoped<IReviewRepository,ReviewRepository>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(
    new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(app.Environment.WebRootPath, "Products")
        ),
        RequestPath = "/wwwroot/Products"
    }
);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
