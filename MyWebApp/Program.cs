// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddRazorComponents()
// .AddInteractiveServerComponents();

// var app = builder.Build();

// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Error", createScopeForErrors: true);
//     app.UseHsts();
// }

// app.UseHttpsRedirection();

// app.UseAntiforgery();

// app.MapStaticAssets();


// app.MapRazorComponents<App>()
// .AddInteractiveServerRenderMode();

// app.Run();

using Microsoft.AspNetCore.Rewrite;
using MyWebApp.Interfaces;
using MyWebApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IPersonService, PersonService>();
builder.Services.AddTransient<IWelcomeService, WelcomeService>();

var app = builder.Build();

// app.MapGet("/",
// (IPersonService personService) =>
// {
//     return $"Hello {personService.GetName()}!";
// });

app.MapGet("/", (IWelcomeService welcomeService1, IWelcomeService welcomeService2) =>
{
    string message1 = $"Message1 {welcomeService1.GetWelcomeMessage()}";
    string message2 = $"Message2 {welcomeService2.GetWelcomeMessage()}";
    return $"{message1}\n{message2}";
});

app.Run();

// app.Use(async (context, next) =>
// {
//     await context.Response.WriteAsync("Hello from midleware 1. Passing to the next middleware!|r\n");

//     await next.Invoke();

//     await context.Response.WriteAsync("Hello from middleware 1 Again!\r\n");
// });

// app.Run(async context =>
// {
//     await context.Response.WriteAsync("Hello from middleware 2! \r\n");
// });

// app.MapGet("/", () => "Welcome to Contoso!");

// app.MapGet("/about", () => "Contoso was founded in 2000!");

// app.UseRewriter(new Microsoft.AspNetCore.Rewrite.RewriteOptions().AddRedirect("history", "about"));

// app.Run();

// app.Use(async (context, next) =>
// {

//     await next.Invoke();
//     Console.WriteLine($"{context.Request.Method} {context.Request.Path} {context.Response.StatusCode}");
// });
// app.Run(async context =>
// {
//     Console.WriteLine($"{context.Request.Body}");
//     await Task.CompletedTask;
// });