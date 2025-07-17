var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World the hot reload is done, so I am chaning this code string to check teh hot reload watch command!");

app.Run();
