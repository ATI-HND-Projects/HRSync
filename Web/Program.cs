using DataAccessLayer;
using AuthLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Confiqure Auth, DataAcces and Service Layers services
builder.Services.ConfigureDataAccessServices(builder.Configuration);
builder.Services.ConfigureAuthServices();

// configure Automapper
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "login",
    pattern: "",
    defaults: new {controller = "Account", action = "Login"});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
