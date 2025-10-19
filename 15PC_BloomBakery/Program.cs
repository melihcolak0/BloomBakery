using _15PC_BloomBakery.AIIntegration;
using _15PC_BloomBakery.Context;
using _15PC_BloomBakery.Hubs;
using _15PC_BloomBakery.Mapping;
using _15PC_BloomBakery.Services.AboutServices;
using _15PC_BloomBakery.Services.CategoryServices;
using _15PC_BloomBakery.Services.ChefServices;
using _15PC_BloomBakery.Services.OrderServices;
using _15PC_BloomBakery.Services.ProductServices;
using _15PC_BloomBakery.Services.ServiceServices;
using _15PC_BloomBakery.Services.SliderServices;
using _15PC_BloomBakery.Services.TestimonialServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSignalR();

builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IChefService, ChefService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<RapidApiGPT4oIntegration>();

//AutoMapper profillerini ekle ve DI'ye kaydet
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
}, AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapHub<ChatBotHub>("/chatHub");

app.Run();
