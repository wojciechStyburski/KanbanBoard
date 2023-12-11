using KanbanBoard.Api.ApiEndpoints;
using KanbanBoard.Application;
using KanbanBoard.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(policy =>
{
    policy
    .AddPolicy("CorsPolicy", opt => opt
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();
app.UseItemsEndpoint();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();
