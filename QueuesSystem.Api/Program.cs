using QueuesSystem.Application;
using QueuesSystem.Domain.Configurations;
using QueuesSystem.Infrastructure;

string CorsConfiguration = "_corsConfiguration";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions();

builder.Services.Configure<FormRecognizerConfiguration>(builder.Configuration.GetSection("FormRecognizer"));

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsConfiguration,
        builder =>
        {
            builder.WithHeaders("*");
            builder.WithOrigins("*");
            builder.WithMethods("*");
        });
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(CorsConfiguration);
app.MapControllers();

app.Run();