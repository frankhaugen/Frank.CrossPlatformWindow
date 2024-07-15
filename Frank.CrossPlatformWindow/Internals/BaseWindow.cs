namespace Frank.CrossPlatformWindow.Internals;

public abstract class BaseWindow : InteropWindow, IWindow
{
    protected int Width { get; }
    protected int Height { get; }

    protected BaseWindow(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public abstract void SetPixel(int x, int y, uint color);
    public abstract void Run();
}