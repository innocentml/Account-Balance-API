using Account.Balance.API.Handlers;
using Account.Balance.API.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IWithdrawHandler, WithdrawHandler>();
builder.Services.AddSingleton<IDConnection, DConnection>();
builder.Services.AddSingleton<IAccountDataAccess, AccountDataAccess>();



var application = builder.Build();

// Configure the HTTP request pipeline.
if (application.Environment.IsDevelopment())
{
    application.UseSwagger();
    application.UseSwaggerUI();
}

application.UseHttpsRedirection();

application.UseAuthorization();

application.MapControllers();

application.Run();
