using GAME4YOU.Components;
using GAME4YOU.Data;
using GAME4YOU.Services;
using Microsoft.EntityFrameworkCore;
using BlazorBootstrap;
using System;

var builder = WebApplication.CreateBuilder(args);

// MSSQL Configuration
builder.Services.AddDbContext<Game4youDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<Game4youSeeder>();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddBlazorBootstrap();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ProductService>();

var app = builder.Build();


// Creating DataBase during start required:DbContext and Seeder
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<Game4youDbContext>();
    dbContext.Database.Migrate(); // Using migrations (we have to have them)

    //Completing the database by seeder
        var seeder = scope.ServiceProvider.GetRequiredService<Game4youSeeder>();
    seeder.Seed();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "GAME4YOU"); });
app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();
