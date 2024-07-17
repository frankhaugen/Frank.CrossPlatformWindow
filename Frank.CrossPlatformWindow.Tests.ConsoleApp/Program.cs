using Frank.CrossPlatformWindow;
using Frank.CrossPlatformWindow.Tests.ConsoleApp.RayTracingDemo;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var cancellationTokenSource = new CancellationTokenSource();
Console.CancelKeyPress += (sender, args) => cancellationTokenSource.Cancel();

var builder = Host.CreateEmptyApplicationBuilder(new HostApplicationBuilderSettings());

builder.Services.AddFrameRendering<RandomPixelColorAction, RayTracingDemo>("SDL2 Window", 1920, 1080);
// builder.Services.AddFrameRendering<RayTracingDemo>("SDL2 Window", 1920, 1080);
builder.Services.AddSingleton<Scene>();
builder.Services.AddSingleton<Camera>();

var app = builder.Build();

// Execute the app as separate task to avoid blocking the main thread
var appTask = Task.Run(() => app.RunAsync(cancellationTokenSource.Token));

// Wait for the app to finish
await appTask;