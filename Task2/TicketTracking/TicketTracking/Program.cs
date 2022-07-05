var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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
    name: "default",
    pattern: "{controller=Login}/{action=LoginView}/{id?}");
app.MapControllerRoute(
   name: "LoginView",
   pattern: "{area:exists}/{controller=Login}/{action=LoginView}/{id?}");
app.MapControllerRoute(
   name: "ManagerView",
   pattern: "{area:exists}/{controller=Manager}/{action=ManagerView}/{id?}");
app.MapControllerRoute(
   name: "CreateView",
   pattern: "{area:exists}/{controller=Create}/{action=CreateView}/{id?}");
app.MapControllerRoute(
   name: "EditView",
   pattern: "{area:exists}/{controller=Edit}/{action=EditView}/{id?}");

// Session
app.UseSession();

app.Run();
