using Hangfire;
using WebApplication6.Config.Core.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallerServicesInAssembly(builder.Configuration);


// var connectionString = builder.Configuration.GetConnectionString("auth");
// builder.Services.AddDbContext<DbDatabaseContext>(options =>
// {
//     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
// });
//
//
// // Add services to the container.
//
// //Hangfire
// // builder.Services.AddTransient<WebApplication6.Config.Hangfire.Hangfire>();
// var databaseConnection = builder.Configuration.GetConnectionString("hangfire");
// builder.Services.AddHangfire(x => x.UseStorage(new MySqlStorage(databaseConnection,new MySqlStorageOptions
// {
//     TransactionIsolationLevel = (IsolationLevel?)System.Data.IsolationLevel.ReadCommitted,
//     QueuePollInterval = TimeSpan.FromSeconds(15),
//     JobExpirationCheckInterval = TimeSpan.FromHours(1),
//     CountersAggregateInterval = TimeSpan.FromMinutes(5),
//     PrepareSchemaIfNecessary = true,
//     DashboardJobListLimit = 50000,
//     TransactionTimeout = TimeSpan.FromMinutes(1),
//     TablesPrefix = "Hangfire"
// })));
// builder.Services.AddHangfireServer();
//
//
//
// builder.Services.AddAuthentication(config =>
//     {
//         config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//         config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     }
// ).AddJwtBearer(config =>
// {
//     var key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
//     config.SaveToken = true;
//     config.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = false,
//         ValidateAudience = false,
//         ValidateLifetime = true,
//         ValidateIssuerSigningKey = true,
//         ValidIssuer = builder.Configuration["JWT:Issuer"],
//         ValidAudience = builder.Configuration["JWT:Audience"],
//         IssuerSigningKey = new SymmetricSecurityKey(key)
//     };
// });
// builder.Services.AddScoped<IJwtManagerRepository, JwtManagerRepository>();





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHangfireDashboard();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();