using Developers2023.Common.Options;
using Developers2023.IoC.Extensions;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddRouting(option =>
{
    option.LowercaseQueryStrings = true;
    option.LowercaseUrls = true;
});

builder.Configuration.AddConfiguration("appsettings.token.json");
//builder.Configuration.AddConfiguration("appsettings.token.leftkey.json");
//builder.Configuration.AddConfiguration("appsettings.token.rightkey.json");

builder.AddOption<TokenOption>();
builder.AddOption<UserOption>();

builder.Services.AddAutomapper();

builder.Services.AddApplicationServices();

builder.Services.AddSecurity(builder.Configuration.GetOption<TokenOption>());

builder.Services.AddOpenApi();


//Limit requests
//builder.Services.AddRateLimiter(_ => _.AddFixedWindowLimiter("fixed", opt =>
//{
//    opt.PermitLimit = 1;
//    opt.Window = TimeSpan.FromSeconds(15);
//    opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
//    opt.QueueLimit = 1;
//}));


var app = builder.Build();

app.UseOpenApi();

app.UseRateLimiter();

app.UseHttpsRedirection();

app.UseSecurity();

app.MapControllers();
   //.RequireRateLimiting("fixed");

app.Run();
