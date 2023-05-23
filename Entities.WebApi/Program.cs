using Entities.Application;
using Entities.Application.Common.Mappings;
using Entities.Application.Interfaces;
using Entities.Persistence;
using Entities.WebApi.Middleware;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddHttpContextAccessor();
services.AddAutoMapper(config =>
{
	config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
	config.AddProfile(new AssemblyMappingProfile(typeof(IEntitiesDbContext).Assembly));
});

services.AddAplication();
services.AddPersistance(builder.Configuration);
services.AddControllers();

services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(config =>
{
	config.RoutePrefix = string.Empty;
	config.SwaggerEndpoint("swagger/v1/swagger.json", "Entities API");
});
app.UseCustomExceptionHandler();
app.UseRouting();
app.UseEndpoints(x => x.MapControllers());



using (var scope = app.Services.CreateScope())
{
	var serviceProvider = scope.ServiceProvider;
	try
	{
		var context = serviceProvider.GetRequiredService<EntitiesDbContext>();
		DbInitializer.Initialize(context);
	}
	catch (Exception ex)
	{
	}
}

app.Run();
