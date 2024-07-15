namespace Frank.CrossPlatformWindow.Internals;

public static class BaseWindowExtensions
{
    public static void AddPixel(this BaseWindow window, Pixel pixel)
    {
        window.SetPixel(pixel.X, pixel.Y, pixel.Color);
    }
    
    public static void AddPixels(this BaseWindow window, IEnumerable<Pixel> pixels)
    {
        foreach (var pixel in pixels)
        {
            window.SetPixel(pixel.X, pixel.Y, pixel.Color);
        }
    }
}