using System.Numerics;
using Microsoft.Extensions.Options;

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
        
        // Move camera based on input
        // foreach (var inputDevice in RawInputDevice.GetDevices())
        // {
        //     if (inputDevice.DeviceType == RawInputDeviceType.Mouse)
        //     {
        //         var mouse = inputDevice as RawInputMouse;
        //         if (mouse is not null)
        //         {
        //             var x = mouse.LastX;
        //             var y = mouse.LastY;
        //             var z = mouse.LastZ;
        //             
        //             if (x != 0 || y != 0 || z != 0)
        //             {
        //                 _camera.Move(x, y, z);
        //             }
        //         }
        //     }
        //     
        //     if (inputDevice.DeviceType == RawInputDeviceType.Keyboard)
        //     {
        //         if (inputDevice is RawInputKeyboard keyboard)
        //         {
        //         }
        //     }
        // }

        await Task.CompletedTask;
    }
}