using System.Runtime.InteropServices;

namespace Frank.CrossPlatformWindow.Internals;

public class LinuxWindow : BaseWindow
{
    private IntPtr _window;
    private IntPtr _renderer;
    private IntPtr _texture;
    private uint[] _pixels;

    public LinuxWindow(int width, int height) : base(width, height)
    {
        _pixels = new uint[width * height];

        if (SDL_Init(SDL_INIT_VIDEO) < 0)
            throw new Exception("SDL could not initialize!");

        _window = SDL_CreateWindow("Pixel Window", 100, 100, width, height, SDL_WINDOW_SHOWN);
        if (_window == IntPtr.Zero)
            throw new Exception("Window could not be created!");

        _renderer = SDL_CreateRenderer(_window, -1, SDL_RENDERER_ACCELERATED);
        if (_renderer == IntPtr.Zero)
            throw new Exception("Renderer could not be created!");

        _texture = SDL_CreateTexture(_renderer, SDL_PIXELFORMAT_ARGB8888, SDL_TEXTUREACCESS_STREAMING, width, height);
        if (_texture == IntPtr.Zero)
            throw new Exception("Texture could not be created!");
    }

    public override void SetPixel(int x, int y, uint color)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height) return;
        _pixels[y * Width + x] = color;
    }

    public override void Run()
    {
        bool running = true;
        SDL_Event e;

        while (running)
        {
            while (SDL_PollEvent(out e) != 0)
            {
                if (e.type == SDL_QUIT)
                {
                    running = false;
                }
            }

            Render();
            SDL_Delay(16); // Roughly 60 FPS
        }

        SDL_DestroyTexture(_texture);
        SDL_DestroyRenderer(_renderer);
        SDL_DestroyWindow(_window);
        SDL_Quit();
    }

    private void Render()
    {
        GCHandle handle = GCHandle.Alloc(_pixels, GCHandleType.Pinned);
        IntPtr pixelsPtr = handle.AddrOfPinnedObject();
        int pitch = Width * sizeof(uint);

        SDL_UpdateTexture(_texture, IntPtr.Zero, pixelsPtr, pitch);
        handle.Free();

        SDL_RenderClear(_renderer);
        SDL_RenderCopy(_renderer, _texture, IntPtr.Zero, IntPtr.Zero);
        SDL_RenderPresent(_renderer);
    }
}