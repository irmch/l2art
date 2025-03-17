using L2Art.Api.Controllers.Auction;
using L2Art.Api.Controllers.Authorization;
using L2Art.Api.Controllers.ItemName;
using L2Art.Api.Controllers.PrivateStore;
using L2Art.Api.Extensions;
using L2Art.Application;
using L2Art.Application.Services;
using L2Art.Infrastructure;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.AddApiAuthentication(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        policy => policy
            .WithOrigins("http://51.38.114.22", "http://localhost")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddInfrastructure(connectionString);
builder.Services.AddApplication();

builder.Services.AddSignalR(
        options =>
        {
            options.EnableDetailedErrors = true;
        }
    );

builder.Services.AddHttpContextAccessor();


var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseCors("AllowAll");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

//app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapPrivateStoreEndpoints();
app.MapAuthorizationEndpointsBuilder();
app.MapItemNameEndpointBuilder();
app.MapAuctionEndpointsBuilder();

app.UseCookiePolicy(
        new CookiePolicyOptions
        {
            MinimumSameSitePolicy = SameSiteMode.Strict,
            HttpOnly = HttpOnlyPolicy.Always,
            Secure = CookieSecurePolicy.Always
        }
    );


app.MapHub<ItemHub>("/api/items-hub");


app.Run();
