namespace Frank.CrossPlatformWindow;

public class RandomPixelColorAction(IWindow window) : IFrameUpdateAction
{
    public Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var random = new Random();
        var x = random.Next(800);
        var y = random.Next(600);
        byte r = (byte)random.Next(256);
        byte g = (byte)random.Next(256);
        byte b = (byte)random.Next(256);
        byte a = 255;
        window.SetPixel(x, y, r, g, b, a);
        return Task.CompletedTask;
    }
}