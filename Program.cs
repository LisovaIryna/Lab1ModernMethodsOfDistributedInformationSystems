using Lab1ModernMethodsOfDistributedInformationSystems.ServiceContracts;
using Lab1ModernMethodsOfDistributedInformationSystems.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGetTimeService, GetTimeService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
