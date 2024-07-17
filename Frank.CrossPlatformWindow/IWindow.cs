namespace Frank.CrossPlatformWindow;

public interface IWindow
{
    /// <summary>
    /// Set the pixel at the specified coordinates to the specified color.
    /// </summary>
    /// <param name="x"> The x-coordinate of the pixel. </param>
    /// <param name="y"> The y-coordinate of the pixel. </param>
    /// <param name="r"> The red component of the color. </param>
    /// <param name="g"> The green component of the color. </param>
    /// <param name="b"> The blue component of the color. </param>
    /// <param name="a"> The alpha component of the color. </param>
    void SetPixel(int x, int y, byte r, byte g, byte b, byte a);
}