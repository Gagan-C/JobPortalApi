//using Authorization.Database;
//using Authorization.Model;
using Jobpost.API.Database;
using Microsoft.AspNetCore.Identity;
using Jobpost.API.Model;

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


//Service defaults for Aspire

builder.AddServiceDefaults();

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


app.MapIdentityApi<User>();
app.MapControllers();

app.Run();
