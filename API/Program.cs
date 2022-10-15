using API.Extensions;
using Identity.Context;
using Identity.Data;
using Identity.Extension;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

// create scope for database handling
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

// check identity db exist, create if needed
var identityContext = services.GetRequiredService<IdentityContext>();
var userManager = services.GetRequiredService<UserManager<AppUser>>();
identityContext.Database.Migrate();
await IdentitySeedData.Seed(identityContext, userManager);

var db = services.GetRequiredService<DataContext>();
db.Database.Migrate();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
