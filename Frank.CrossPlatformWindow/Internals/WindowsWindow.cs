using System.Runtime.InteropServices;

namespace Frank.CrossPlatformWindow.Internals;

public class WindowsWindow : BaseWindow
{
    private IntPtr _window;
    private IntPtr _renderer;
    private IntPtr _texture;
    private uint[] _pixels;

    public WindowsWindow(int width, int height) : base(width, height)
    {
        SDL_Init(SDL_INIT_VIDEO);
        _window = SDL_CreateWindow("Frank's Cross-Platform Window", 100, 100, width, height, SDL_WINDOW_SHOWN);
        _renderer = SDL_CreateRenderer(_window, -1, SDL_RENDERER_ACCELERATED);
        _texture = SDL_CreateTexture(_renderer, SDL_PIXELFORMAT_ARGB8888, SDL_TEXTUREACCESS_STREAMING, width, height);
        _pixels = new uint[width * height];
    }

    public override void SetPixel(int x, int y, uint color)
    {
        var index = (y * Width + x) * 4;
        _pixels[index] = (byte)(color >> 16);
        _pixels[index + 1] = (byte)(color >> 8);
        _pixels[index + 2] = (byte)color;
        _pixels[index + 3] = (byte)(color >> 24);
    }

    public override void Run()
    {
        var rect = IntPtr.Zero;
        var pitch = Width * 4;
        
        GCHandle handle = GCHandle.Alloc(_pixels, GCHandleType.Pinned);
        IntPtr pixelsPtr = handle.AddrOfPinnedObject();
        
        SDL_UpdateTexture(_texture, rect, pixelsPtr, pitch);
        SDL_RenderClear(_renderer);
        SDL_RenderCopy(_renderer, _texture, rect, rect);
        SDL_RenderPresent(_renderer);
        var quit = false;
        while (!quit)
        {
            if (SDL_PollEvent(out var _event) != 0 && _event.type == SDL_QUIT)
            {
                quit = true;
            }
            SDL_Delay(16);
        }
        SDL_DestroyTexture(_texture);
        SDL_DestroyRenderer(_renderer);
        SDL_DestroyWindow(_window);
        SDL_Quit();
    }
}