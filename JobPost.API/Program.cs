//using Authorization.Database;
//using Authorization.Model;
using Jobpost.API.Database;
using Microsoft.AspNetCore.Identity;
using Jobpost.API.Model;
using JobPost.API.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
})
.AddCookie(IdentityConstants.ApplicationScheme, options =>
{
    options.Cookie.SameSite = SameSiteMode.None;
})
.AddBearerToken(IdentityConstants.BearerScheme);



//Database context
builder.AddSqlServerDbContext<AppDbContext>("jobdb");

builder.Services.AddControllers();
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<AppDbContext>().AddApiEndpoints();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllLocalHost", builder =>
    {
        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

builder.Services.AddScoped<IOnboardingService, OnboardingService>();
builder.Services.AddScoped<IPostService, PostService>();


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    await SeedUser.SeedAsync(scope.ServiceProvider);
}

app.UseOutputCache();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAllLocalHost");

app.UseAuthentication();
app.UseAuthorization();


app.MapIdentityApi<User>();
app.MapControllers();

await app.RunAsync();
