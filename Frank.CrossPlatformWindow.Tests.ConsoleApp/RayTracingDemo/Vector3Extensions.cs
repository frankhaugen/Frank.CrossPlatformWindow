using System.Numerics;

namespace Frank.CrossPlatformWindow.Tests.ConsoleApp.RayTracingDemo;

public static class Vector3Extensions
{
    public static float Dot(this Vector3 vector1, Vector3 vector2)
    {
        return Vector3.Dot(vector1, vector2);
    }
}