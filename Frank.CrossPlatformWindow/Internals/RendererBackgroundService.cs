using Microsoft.Extensions.Hosting;

namespace Frank.CrossPlatformWindow.Internals;

internal class RendererBackgroundService(Renderer renderer) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await renderer.RenderFrameAsync(stoppingToken);
            await Task.Delay(16, stoppingToken); // Roughly 60 FPS
        }
    }
}