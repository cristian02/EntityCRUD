using FormulaOneApp;
using FormulaOneApp.Data;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddApiVersioning(config=>
{
    config.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(2, 0);
    config.AssumeDefaultVersionWhenUnspecified = true; 
    config.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(config =>
 {   
    config.GroupNameFormat = "'v'VVV";
    config.SubstituteApiVersionInUrl = true; 

});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(options=>{
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>(); 
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
