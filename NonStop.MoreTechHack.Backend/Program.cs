using NonStop.MoreTechHack.Backend.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddSingleton<IPointsProvider, PointsProvider>()
    .AddSingleton<IAtmsProvider, AtmsProvider>()
    .AddSingleton<IWorkloadProvider, WorkloadProvider>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
