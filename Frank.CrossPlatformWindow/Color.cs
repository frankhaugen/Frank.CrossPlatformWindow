namespace Frank.CrossPlatformWindow;

public class Color(byte r, byte g, byte b, byte a = 255)
{
    public byte R { get; } = r;
    public byte G { get; } = g;
    public byte B { get; } = b;
    public byte A { get; } = a;

    public static Color operator *(byte t, Color c) => new Color((byte)(t * c.R), (byte)(t * c.G), (byte)(t * c.B));
    public static Color operator +(Color c1, Color c2) => new Color((byte)(c1.R + c2.R), (byte)(c1.G + c2.G), (byte)(c1.B + c2.B));

    public static Color FromArgb(byte v1, byte v2, byte v3, byte v4 = 255) => new(v1, v2, v3, v4);
    
    public static implicit operator Color(System.Drawing.Color color) => new Color(color.R, color.G, color.B, color.A);
    public static implicit operator System.Drawing.Color(Color color) => System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
    
    public static implicit operator Color(uint color) => new Color((byte)((color >> 16) & 0xFF), (byte)((color >> 8) & 0xFF), (byte)(color & 0xFF), (byte)((color >> 24) & 0xFF));
    public static implicit operator uint(Color color) => (uint)((color.A << 24) | (color.R << 16) | (color.G << 8) | color.B);
}