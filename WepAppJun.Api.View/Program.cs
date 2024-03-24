using WepAppJun.Api.View.Middlewares;
using WepAppJun.Application.Interfaces.Products;
using WepAppJun.Application.Services.Products;
using WepAppJun.infrastructure.AppDBContext;
using WepAppJun.infrastructure.Repositories.Products.Interfaces;
using WepAppJun.infrastructure.Repositories.Products.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//
builder.Services.AddAutoMapper(typeof(Program));
//
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IProductService,ProductService>();

builder.Services.AddDbContext<TestDbContext>();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();


var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); 
    //new Added Middleware
    app.UseMiddleware<ExceptionHandlingMiddleware>();
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
