using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using onlinesinavportali.Hubs;
using onlinesinavportali.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 10;
    config.IsDismissable = true;
    config.Position = NotyfPosition.BottomRight;
});

// SignalR servisini ekle
builder.Services.AddSignalR();

// Dosya provider servisi ekle
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));

// Veritaban� ba�lant�s� ve Entity Framework yap�land�rmas�
builder.Services.AddDbContext<AppDBContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("sqlCon"));
});

// Identity yap�land�rmas�
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    // Identity i�in opsiyonel ayarlar yap�labilir
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
})
.AddEntityFrameworkStores<AppDBContext>()
.AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Kimlik do�rulama ve yetkilendirme
app.UseAuthentication();
app.UseAuthorization();

// SignalR hub'� i�in rotay� tan�mla
app.MapHub<GeneralHub>("/generalHub"); // SignalR Hub rotas�

// Route mapping
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
