using Microsoft.Extensions.Options;

namespace Frank.CrossPlatformWindow.Internals;

internal class FrameWriter(IOptions<WindowOptions> options) : IWindow
{
    private readonly int _width = options.Value.Width;
    private readonly int _height = options.Value.Height;
    private readonly Dictionary<(int x, int y), (byte r, byte g, byte b, byte a)> _pixels = new();

    public event Action<int, int, byte, byte, byte, byte>? PixelChanged;

    public void SetPixel(int x, int y, byte r, byte g, byte b, byte a)
    {
        if (x < 0 || x >= _width || y < 0 || y >= _height)
        {
            return;
            // throw new ArgumentOutOfRangeException($"Pixel coordinates are out of bounds. They must be within the bounds of the window: Between 0 and {_width} wide (x), and 0 and {_height} high (y).");
        }
		
        if (_pixels.TryGetValue((x, y), out var existingPixel))
        {
            if (existingPixel == (r, g, b, a)) return;
            _pixels[(x, y)] = (r, g, b, a);
            PixelChanged?.Invoke(x, y, r, g, b, a);
        }
        else
        {
            _pixels[(x, y)] = (r, g, b, a);
            PixelChanged?.Invoke(x, y, r, g, b, a);
        }
    }
}