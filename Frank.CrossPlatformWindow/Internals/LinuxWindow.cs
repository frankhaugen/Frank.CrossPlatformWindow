// #if LINUX
using System;
using System.Runtime.InteropServices;
using SDL;

namespace Frank.CrossPlatformWindow.Internals
{
    public class LinuxWindow : BaseWindow
    {
        private SDL_Window _window;
        private SDL_Renderer _renderer;
        private SDL_Texture _texture;
        private uint[] _pixels;

        public LinuxWindow(int width, int height) : base(width, height)
        {
            _pixels = new uint[width * height];

            if (SDL3.SDL_Init(SDL_InitFlags.SDL_INIT_VIDEO) < 0)
                throw new Exception("SDL could not initialize!");

            _window = SDL3.SDL_CreateWindow("Pixel Window", 100, 100, width, height, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

            _renderer = SDL3.SDL_CreateRenderer(_window, -1, SDL.SDL_Flags.Ac.SDL_RENDERER_ACCELERATED);

            _texture = SDL3.SDL_CreateTexture(_renderer, SDL.SDL_PIXELFORMAT_ARGB8888, (int)SDL.SDL_TextureAccess.SDL_TEXTUREACCESS_STREAMING, width, height);
        }

        public override void SetPixel(int x, int y, uint color)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) return;
            _pixels[y * Width + x] = color;
        }

        public override void Run()
        {
            bool running = true;
            SDL.SDL_Event e;

            while (running)
            {
                while (SDL3.SDL_PollEvent(out e) != 0)
                {
                    if (e.type == SDL.SDL_EventType.SDL_QUIT)
                    {
                        running = false;
                    }
                }

                Render();
                SDL3.SDL_Delay(16); // Roughly 60 FPS
            }

            SDL3.SDL_DestroyTexture(_texture);
            SDL3.SDL_DestroyRenderer(_renderer);
            SDL3.SDL_DestroyWindow(_window);
            SDL3.SDL_Quit();
        }

        private void Render()
        {
            GCHandle handle = GCHandle.Alloc(_pixels, GCHandleType.Pinned);
            IntPtr pixelsPtr = handle.AddrOfPinnedObject();
            int pitch = Width * sizeof(uint);

            SDL3.SDL_UpdateTexture(_texture, IntPtr.Zero, pixelsPtr, pitch);
            handle.Free();

            SDL3.SDL_RenderClear(_renderer);
            // SDL3.SDL_Cop(_renderer, _texture, IntPtr.Zero, IntPtr.Zero);
            SDL3.SDL_RenderPresent(_renderer);
        }
    }
}
#endif
