using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Configurar os Serviços

//Iniciar o Contexto
builder.Services.AddDbContext<ControleVeiculo.Data.DataContext>(options => options.UseNpgsql(builder.Configuration["Banco:PG:conexao"]));

//Adiciona os serviços  para injeção de dependencia
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews().AddNewtonsoftJson();

//Configura a obtenção do IP por proxy (cloudflare) ForwardedHeadersOptions
builder.Services.Configure<ForwardedHeadersOptions>(options => { options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto; });
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);


var app = builder.Build();

//Criar obanco de dados do entity caso ele ainda não exista e executar as migrações do ef migrate
var servicesTemp = app.Services.GetService<IServiceScopeFactory>();
if (servicesTemp is not null)
    using (var serviceScope = servicesTemp.CreateScope())
    {
        var appContext = serviceScope.ServiceProvider.GetRequiredService<ControleVeiculo.Data.DataContext>();
        appContext.Database.Migrate();
    }

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials
}


//Habilita o uso de proxy - (cloudflare)
app.UseForwardedHeaders();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
