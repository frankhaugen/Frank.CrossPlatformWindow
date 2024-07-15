namespace Frank.CrossPlatformWindow.Internals;

public interface IWindow
{
    /// <summary>
    /// Sets the pixel at the specified coordinates to the specified color.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="color"></param>
    void SetPixel(int x, int y, uint color);
    
    /// <summary>
    /// Runs the window.
    /// </summary>
    void Run();
}