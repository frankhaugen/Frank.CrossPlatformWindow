namespace Frank.CrossPlatformWindow;

public static class WindowExtensions
{
    /// <summary>
    /// Set the pixel at the specified coordinates to the specified color.
    /// </summary>
    /// <param name="window"> The window to set the pixel on. </param>
    /// <param name="pixel"> The pixel to set. </param>
    public static void SetPixel(this IWindow window, Pixel pixel)
    {
        window.SetPixel(pixel.X, pixel.Y, pixel.Color);
    }
    
    /// <summary>
    /// Set the pixel at the specified coordinates to the specified color.
    /// </summary>
    /// <param name="window"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="color"></param>
    public static void SetPixel(this IWindow window, int x, int y, Color color)
    {
        window.SetPixel(x, y, color.R, color.G, color.B, color.A);
    }
    
    /// <summary>
    /// Set the pixels on the window.
    /// </summary>
    /// <param name="window"> The window to set the pixels on. </param>
    /// <param name="pixels"> The pixels to set. </param>
    public static void SetPixels(this IWindow window, IEnumerable<Pixel> pixels)
    {
        foreach (var pixel in pixels)
        {
            window.SetPixel(pixel);
        }
    }
}