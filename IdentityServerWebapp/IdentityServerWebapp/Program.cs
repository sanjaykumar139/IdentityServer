using IdentityServerWebapp.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddIdentityServer();

builder.Services.AddIdentityServer()
       .AddInMemoryIdentityResources(InMemoryConfig.GetIdentityResources())
       .AddTestUsers(InMemoryConfig.GetUsers())
       .AddInMemoryClients(InMemoryConfig.GetClients())
       .AddDeveloperSigningCredential(); //not something we want to use in a production environment;


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseIdentityServer();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
