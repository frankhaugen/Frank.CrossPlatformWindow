namespace Frank.CrossPlatformWindow.Internals;

public readonly struct Pixel(int x, int y, uint color)
{
    public int X { get; } = x;
    public int Y { get; } = y;
    public uint Color { get; } = color;
}