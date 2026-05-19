using blazor_final_pro.Components;
using blazor_final_pro.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// Add this to register your UserService globally across the app
builder.Services.AddSingleton<UserService>();
// Add this line in Program.cs
//builder.Services.AddScoped<UserService>();
// (Use .AddSingleton<UserService>() instead if the data needs to persist across all users/tabs)

// --- YE DO LINES LAZMI HONI CHAHIYEN BUILDER.BUILD SE PEHLE ---
builder.Services.AddScoped<blazor_final_pro.Services.BattleEngine>();
builder.Services.AddScoped<blazor_final_pro.Services.UserService>(); // <-- YE VALI LINE ADD KREIN!
builder.Services.AddSingleton<ReviewService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();