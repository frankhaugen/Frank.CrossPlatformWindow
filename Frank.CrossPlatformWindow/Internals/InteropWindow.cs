using System.Runtime.InteropServices;

namespace Frank.CrossPlatformWindow.Internals;

public abstract class InteropWindow
{
    private const string SDL2_LIB = "SDL2";

    [DllImport(SDL2_LIB)]
    private protected static extern int SDL_Init(uint flags);

    [DllImport(SDL2_LIB)]
    private protected static extern IntPtr SDL_CreateWindow(string title, int x, int y, int w, int h, uint flags);

    [DllImport(SDL2_LIB)]
    private protected static extern IntPtr SDL_CreateRenderer(IntPtr window, int index, uint flags);

    [DllImport(SDL2_LIB)]
    private protected static extern IntPtr SDL_CreateTexture(IntPtr renderer, uint format, int access, int w, int h);

    [DllImport(SDL2_LIB)]
    private protected  static extern int SDL_UpdateTexture(IntPtr texture, IntPtr rect, IntPtr pixels, int pitch);

    [DllImport(SDL2_LIB)]
    private protected  static extern int SDL_RenderClear(IntPtr renderer);

    [DllImport(SDL2_LIB)]
    private protected  static extern int SDL_RenderCopy(IntPtr renderer, IntPtr texture, IntPtr srcrect, IntPtr dstrect);

    [DllImport(SDL2_LIB)]
    private protected  static extern void SDL_RenderPresent(IntPtr renderer);

    [DllImport(SDL2_LIB)]
    private protected  static extern void SDL_DestroyTexture(IntPtr texture);

    [DllImport(SDL2_LIB)]
    private protected  static extern void SDL_DestroyRenderer(IntPtr renderer);

    [DllImport(SDL2_LIB)]
    private protected  static extern void SDL_DestroyWindow(IntPtr window);

    [DllImport(SDL2_LIB)]
    private protected  static extern void SDL_Quit();

    [DllImport(SDL2_LIB)]
    private protected  static extern int SDL_PollEvent(out SDL_Event _event);

    [DllImport(SDL2_LIB)]
    private protected  static extern void SDL_Delay(uint ms);

    protected struct SDL_Event
    {
        public uint type;
    }

    protected const uint SDL_INIT_VIDEO = 0x00000020;
    protected const uint SDL_WINDOW_SHOWN = 0x00000004;
    protected const uint SDL_RENDERER_ACCELERATED = 0x00000002;
    protected const uint SDL_PIXELFORMAT_ARGB8888 = 372645892;
    protected const int SDL_TEXTUREACCESS_STREAMING = 1;
    protected const uint SDL_QUIT = 0x100;
}