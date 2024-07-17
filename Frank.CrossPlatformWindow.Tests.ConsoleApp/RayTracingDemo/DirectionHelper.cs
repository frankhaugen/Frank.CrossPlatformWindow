using System.Numerics;

namespace Frank.CrossPlatformWindow.Tests.ConsoleApp.RayTracingDemo;

public static class DirectionHelper
{
    public static Vector3 LookAt(Vector3 from, Vector3 to) => Vector3.Normalize(to - from);
    
    public static Vector3 GetVector(Direction direction) => direction switch
    {
        Direction.Up => Vector3.UnitY,
        Direction.Down => -Vector3.UnitY,
        Direction.Left => -Vector3.UnitX,
        Direction.Right => Vector3.UnitX,
        Direction.Forward => Vector3.UnitZ,
        Direction.Backward => -Vector3.UnitZ,
        _ => Vector3.Zero
    };
}