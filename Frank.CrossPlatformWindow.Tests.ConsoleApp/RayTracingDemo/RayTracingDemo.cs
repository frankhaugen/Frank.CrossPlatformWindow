using System.Numerics;
using Microsoft.Extensions.Options;
using SharpHook;
using SharpHook.Native;

namespace Frank.CrossPlatformWindow.Tests.ConsoleApp.RayTracingDemo;

public class RayTracingDemo : IFrameUpdateAction
{
    private readonly IWindow _window;
    private readonly Scene _scene;
    private readonly Camera _camera;
    private readonly IOptions<WindowOptions> _windowOptions;

    public RayTracingDemo(IWindow window, Scene scene, Camera camera, IOptions<WindowOptions> windowOptions)
    {
        _window = window;
        _scene = scene;
        _camera = camera;
        _windowOptions = windowOptions;

        _scene.Add(new Sphere(new Vector3(0, 0, 0), 0.75f, Color.FromArgb(180, 60, 200)));
        
        _scene.Add(new Sphere(new Vector3(0, 0, 1), 0.25f, Color.FromArgb(200, 60, 60)));
        
        _scene.Add(new Sphere(new Vector3(1, 0, 0), 0.25f, Color.FromArgb(60, 200, 60)));
        
        PrepareInput();
    }

    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        
        var width = _windowOptions.Value.Width;
        var height = _windowOptions.Value.Height;
        var aspectRatio = width / (float)height;
        var scale = MathF.Tan(MathF.PI * _camera.FieldOfView / 360);
        
        var rays = new List<Ray>();

        for (var y = height - 1; y >= 0; y--)
        {
            for (var x = 0; x < width; x++)
            {
                // Map (x, y) to [-1, 1] in NDC and adjust based on aspect ratio and FOV
                var u = (2f * (x + 0.5f) / width - 1) * aspectRatio * scale;
                var v = (1 - 2f * (y + 0.5f) / height) * scale;

                // Direction from the camera to the pixel
                Vector3 direction = _camera.Direction + new Vector3(u, v, 1) - _camera.Position;
                direction = Vector3.Normalize(direction);

                var ray = new Ray(_camera.Position, direction);
                rays.Add(ray);
            }
        }
        
        foreach (var ray in rays)
        {
            var hit = _scene.Hit(ray, 0, 500f);
            if (hit is not null)
            {
                var x = (int)(width * hit.Point.X);
                var y = (int)(height * hit.Point.Y);
                
                _window.SetPixel(x, y, hit.Color);
            }
        }

        await Task.CompletedTask;
    }

    private void PrepareInput()
    {
        var hook = new TaskPoolGlobalHook();

        hook.HookEnabled += OnHookEnabled;     // EventHandler<HookEventArgs>
        hook.HookDisabled += OnHookDisabled;   // EventHandler<HookEventArgs>

        hook.KeyTyped += OnKeyTyped;           // EventHandler<KeyboardHookEventArgs>
        hook.KeyPressed += OnKeyPressed;       // EventHandler<KeyboardHookEventArgs>
        hook.KeyReleased += OnKeyReleased;     // EventHandler<KeyboardHookEventArgs>

        hook.Run();
    }

    private void OnKeyReleased(object? sender, KeyboardHookEventArgs e)
    {
    }

    private void OnKeyPressed(object? sender, KeyboardHookEventArgs e)
    {
    }

    private void OnKeyTyped(object? sender, KeyboardHookEventArgs e)
    {
        if (e.Data.KeyCode == KeyCode.VcEscape)
        {
            Environment.Exit(0);
        }
        
        if (e.Data.KeyCode == KeyCode.VcW)
        {
            _camera.Position += _camera.Direction * 0.1f;
        }
        
        if (e.Data.KeyCode == KeyCode.VcS)
        {
            _camera.Position -= _camera.Direction * 0.1f;
        }
        
        if (e.Data.KeyCode == KeyCode.VcA)
        {
            _camera.Position -= Vector3.Cross(_camera.Direction, _camera.Position) * 0.1f;
        }
        
        if (e.Data.KeyCode == KeyCode.VcD)
        {
            _camera.Position += Vector3.Cross(_camera.Direction, _camera.Position) * 0.1f;
        }
    }

    private void OnHookDisabled(object? sender, HookEventArgs e)
    {
    }

    private void OnHookEnabled(object? sender, HookEventArgs e)
    {
        
    }
}