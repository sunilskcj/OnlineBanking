using DataAccessLayer.Repository.Abstraction;
using DataAccessLayer.Repository.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IAccountFieldDao, AccountFieldDao>();
builder.Services.AddSingleton<ICredentialsDaoImpl, CredentialsDaoImpl>();
builder.Services.AddSingleton<ITransactionDaoImpl, TransactionDaoImpl>();
builder.Services.AddSingleton<IPayeeDaoImpl, PayeeDaoImpl>();
builder.Services.AddTransient<IAuthenticationDaoImpl, AuthenticationDaoImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
