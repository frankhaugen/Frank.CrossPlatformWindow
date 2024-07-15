using Frank.CrossPlatformWindow.Internals;

namespace Frank.CrossPlatformWindow;

public class Window
{
    private readonly BaseWindow _platformWindow;

    public Window(int width, int height)
    {
#if WINDOWS
            _platformWindow = new Internals.WindowsWindow(width, height);
#elif LINUX
            _platformWindow = new Internals.LinuxWindow(width, height);
#elif MACOS
            _platformWindow = new Internals.MacWindow(width, height);
#else
        throw new PlatformNotSupportedException("Unsupported platform");
#endif
    }

    public void SetPixel(int x, int y, uint color)
    {
        _platformWindow.SetPixel(x, y, color);
    }

    public void Run()
    {
        _platformWindow.Run();
    }
}