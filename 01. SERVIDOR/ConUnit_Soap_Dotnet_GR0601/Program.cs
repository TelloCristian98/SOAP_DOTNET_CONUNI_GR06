using ConUnit_Soap_Dotnet_GR06.ec.edu.monster.modelo;
using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Set specific URLs for the application
builder.WebHost.UseUrls("http://localhost:7109", "https://localhost:7109");

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddSingleton<Conversión>();
builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
// Temporarily disable HTTPS redirection to test HTTP
// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<Conversión>();
    serviceBuilder.AddServiceEndpoint<Conversión, IConversión>(new BasicHttpBinding(), "/Conversion.svc");
});

var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
serviceMetadataBehavior.HttpGetEnabled = true;
serviceMetadataBehavior.HttpsGetEnabled = false; // Disable HTTPS metadata for now

app.Run();