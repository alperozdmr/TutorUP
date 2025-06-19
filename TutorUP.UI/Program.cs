using System.Reflection;
using TutorUP.DataAccessLayer.Concrete;
using TutorUP.EntityLayer.Entity;
using TutorUp.ServiceLayer.Container;
using TutorUP.UI.Extenisons;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<TutorUpDbContext>();
//builder.Services.AddIdentity<AppUser, AppRole>()
//    .AddEntityFrameworkStores<TutorUpDbContext>();
builder.Services.AddIdetityWithExt();

builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    });

builder.Services.ConfigureApplicationCookie(options =>
{
    var cookieBuilder = new CookieBuilder();

    cookieBuilder.Name = "TutorUPCookie";
    options.LoginPath = new PathString("/Auth/Login");
    //options.LogoutPath = new PathString("/Auth/Logout");
    options.Cookie = cookieBuilder;
    options.ExpireTimeSpan = TimeSpan.FromHours(1);
    options.SlidingExpiration = true;
});
builder.Services.AddControllers();



builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.ContainerDependencies();// Dependecy Ýnjectionlarý çaðýrýyor service layerýndaki


// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();
app.UseStatusCodePages(async x =>
{
    if (x.HttpContext.Response.StatusCode == 404)
    {
        x.HttpContext.Response.Redirect("/Error/NotFound404Page/");
    }
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Lesson}/{action=Index}/{id?}");

app.Run();
