using System.Numerics;

namespace Frank.CrossPlatformWindow.Tests.ConsoleApp.RayTracingDemo;

public class Camera
{    
    public float FieldOfView { get; set; } = 90;
    
    public Vector3 Position { get; set; } = new Vector3(0, 0, -5);
    public Vector3 Direction { get; set; } = DirectionHelper.LookAt(new Vector3(0, 0, -5), new Vector3(0, 0, 0));
}