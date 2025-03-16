//using Authorization.Database;
//using Authorization.Model;
using Jobpost.API.Database;
using Microsoft.AspNetCore.Identity;
using Jobpost.API.Model;
using JobPost.API.Database;
using Microsoft.AspNetCore.Authorization;
using JobPost.API.Services.AuthService;

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
    options.Cookie.SameSite = SameSiteMode.Lax;
})
.AddBearerToken(IdentityConstants.BearerScheme);


//Service defaults for Aspire

builder.AddServiceDefaults();

builder.AddRedisOutputCache("redis");

//Database context
builder.AddSqlServerDbContext<AppDbContext>("jobdb");

builder.Services.AddControllers();
builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole>() 
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders()
    .AddSignInManager();

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
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddServiceDiscovery(); 



var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    await SeedData.SeedAsync(scope.ServiceProvider);
}

app.UseOutputCache();

app.MapDefaultEndpoints();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAllLocalHost");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

await app.RunAsync();
