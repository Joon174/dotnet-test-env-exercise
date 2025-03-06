using Microsoft.EntityFrameworkCore;
using ChessGame.Data;
using ChessGame.Repositories;
using ChessGame.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register EF DbContext
builder.Services.AddDbContext<ChessGameDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ChessGameDb"))
);

// Register Repositories
builder.Services.AddScoped<IChessGameRepository, ChessGameRepository>();
builder.Services.AddScoped<IPieceMoveEventRepository, MoveEventRepository>();

// Regeister Service
builder.Services.AddScoped<ChessGameService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
