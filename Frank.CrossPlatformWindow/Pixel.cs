namespace Frank.CrossPlatformWindow;

/// <summary>
/// Represents a pixel.
/// </summary>
/// <remarks> This type is immutable. </remarks>
/// <param name="x"> The x-coordinate of the pixel. </param>
/// <param name="y"> The y-coordinate of the pixel. </param>
/// <param name="color"> The color of the pixel. </param>
public readonly struct Pixel(int x, int y, uint color)
{
    public int X { get; } = x;
    public int Y { get; } = y;
    public uint Color { get; } = color;
}