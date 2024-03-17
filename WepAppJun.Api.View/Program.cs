using WepAppJun.Application.Interfaces.Products;
using WepAppJun.Application.Services.Products;
using WepAppJun.infrastructure.AppDBContext;
using WepAppJun.infrastructure.Repositories.Products.Interfaces;
using WepAppJun.infrastructure.Repositories.Products.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IProductService,ProductService>();

builder.Services.AddDbContext<TestDbContext>();



var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
