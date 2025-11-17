var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region API Clients
builder.Services.AddHttpClient("CatalogAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7070/api/");
});

builder.Services.AddHttpClient("OrderAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7070/api/");
});
#endregion


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

// Önce alan (area) bazlý yönlendirmeyi tanýmlayýn (daha spesifik olduðu için)
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// Sonra varsayýlan (default) yönlendirmeyi tanýmlayýn
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
