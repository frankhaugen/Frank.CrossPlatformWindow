using Microsoft.Extensions.Options;
using static SDL2.SDL;

namespace Frank.CrossPlatformWindow.Internals;

internal class Renderer : IWindow, IDisposable
{
    private readonly IntPtr _window;
    private readonly IntPtr _renderer;
    private readonly FrameWriter _frameWriter;
    private readonly IEnumerable<IFrameUpdateAction>? _frameUpdateActions;
    private bool _needsUpdate;

    public Renderer(FrameWriter frameWriter, IOptions<WindowOptions> options, IEnumerable<IFrameUpdateAction>? frameUpdateActions = null)
    {
        _frameWriter = frameWriter;
        _frameUpdateActions = frameUpdateActions;

        if (SDL_Init(SDL_INIT_VIDEO) < 0)
        {
            throw new Exception($"Unable to initialize SDL: {SDL_GetError()}");
        }

        _window = SDL_CreateWindow(options.Value.Title,
            SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED,
            options.Value.Width, options.Value.Height, SDL_WindowFlags.SDL_WINDOW_SHOWN | SDL_WindowFlags.SDL_WINDOW_VULKAN | SDL_WindowFlags.SDL_WINDOW_MOUSE_CAPTURE);
        
        _renderer = SDL_CreateRenderer(_window, -1, SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

        // Set the window background color to black
        SDL_SetRenderDrawColor(_renderer, 0, 0, 0, 255);
        SDL_RenderClear(_renderer);
        SDL_RenderPresent(_renderer);
        
        _frameWriter.PixelChanged += OnPixelChanged;
    }

    private void OnPixelChanged(int x, int y, byte r, byte g, byte b, byte a)
    {
        var rect = new SDL_Rect { x = x, y = y, w = 1, h = 1 };
        SDL_SetRenderDrawColor(_renderer, r, g, b, a);
        SDL_RenderFillRect(_renderer, ref rect);
        _needsUpdate = true;
    }

    public void SetPixel(int x, int y, byte r, byte g, byte b, byte a)
    {
        _frameWriter.SetPixel(x, y, r, g, b, a);
    }

    public async Task RenderFrameAsync(CancellationToken cancellationToken)
    {
        if (SDL_PollEvent(out var e) != 0)
        {
            if (e.type == SDL_EventType.SDL_QUIT)
            {
                Dispose();
                Environment.Exit(0);
            }
        }
        
        if (_frameUpdateActions != null)
        {
            foreach (var action in _frameUpdateActions)
            {
                await action.ExecuteAsync(cancellationToken);
            }
        }

        if (_needsUpdate)
        {
            SDL_RenderPresent(_renderer);
            _needsUpdate = false;
        }
    }

    public void Dispose()
    {
        _frameWriter.PixelChanged -= OnPixelChanged;
        SDL_DestroyRenderer(_renderer);
        SDL_DestroyWindow(_window);
        SDL_Quit();
    }
}