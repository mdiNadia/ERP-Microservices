using CRM.Aggregator;
using CRM.Aggregator.Services.Account;
using CRM.Aggregator.Services.LeadManagement;
using CRM.Aggregator.Services.Marketing;
using CRM.Aggregator.Services.User;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices(builder.Configuration);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .SetIsOriginAllowed(origin => true)); // allow any origin

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    //endpoints.MapRazorPages() OR app.MapRazorPages() ?
    endpoints.MapControllerRoute("default", "api/v1/{controller=Home}/{action=Index}/{id?}");

});


app.Run();
