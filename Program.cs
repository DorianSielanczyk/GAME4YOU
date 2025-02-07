using GAME4YOU.Components;
using GAME4YOU.Data;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
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
builder.Services.AddSyncfusionBlazor();
builder.Services.AddHttpClient();

var app = builder.Build();


// Creating DataBase during start
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<Game4youDbContext>();
    dbContext.Database.Migrate(); // Zastosowanie migracji bazy danych

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
