using DataAccessLayer.Repository.Abstraction;
using DataAccessLayer.Repository.Implementation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using ServerAPI.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAccountFieldDao, AccountFieldDao>();
builder.Services.AddScoped<ICredentialsDaoImpl, CredentialsDaoImpl>();
builder.Services.AddScoped<ITransactionDaoImpl, TransactionDaoImpl>();
builder.Services.AddScoped<IPayeeDaoImpl, PayeeDaoImpl>();
builder.Services.AddTransient<IAuthenticationDaoImpl, AuthenticationDaoImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors(
             policyBuilder =>
             policyBuilder
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader()
             );
app.Run();
