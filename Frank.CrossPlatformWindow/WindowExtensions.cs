using Frank.CrossPlatformWindow.Internals;

namespace Frank.CrossPlatformWindow;

public static class WindowExtensions
{
    /// <summary>
    /// Add a pixel to the window.
    /// </summary>
    /// <param name="window"></param>
    /// <param name="pixel"></param>
    public static void SetPixel(this Window window, Pixel pixel)
    {
        window.SetPixel(pixel.X, pixel.Y, pixel.Color);
    }

    /// <summary>
    /// Add pixels to the window.
    /// </summary>
    /// <param name="window"></param>
    /// <param name="pixels"></param>
    public static void SetPixels(this Window window, IEnumerable<Pixel> pixels)
    {
        foreach (var pixel in pixels)
        {
            window.SetPixel(pixel.X, pixel.Y, pixel.Color);
        }
    }
}