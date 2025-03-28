var builder = DistributedApplication.CreateBuilder(args);


var redis = builder.AddRedis("redis");

var database = builder.AddSqlServer("sqlDB")
    .WithLifetime(ContainerLifetime.Persistent);
var db = database.AddDatabase("jobdb");

var jobApi = builder.AddProject<Projects.JobPost_API>("jobapi")
    .WithReference(db)
    .WithReference(redis)
    .WaitFor(db);

builder.AddProject<Projects.JobPost_WebApp>("jobpost-webapp")
    .WithReference(jobApi);

builder.Build().Run();
