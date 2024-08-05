using API.Extensions;
using API.Middlewares;
using Common.Constants;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();

builder.Services.AddRouting(options => options.LowercaseUrls = true); //Lower case url in swagger

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true; //Suppressing default validation of model for API
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inside ApplicationConfiguration Extension Method
builder.Services.ConnectDatabase(builder.Configuration);
builder.Services.RegisterRepository();
builder.Services.RegisterServices();
builder.Services.ConfigureCors();
builder.Services.ConfigAuthentication(builder.Configuration);
builder.Services.SetRequestBodySize();
builder.Services.RegisterAutoMapper();
builder.Services.RegisterMail(builder.Configuration);

var app = builder.Build();

app.UseCors(SystemConstants.CORS_POLICY);

//Auto migration
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<AppDbContext>();

    // Here is the migration executed
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


