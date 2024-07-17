using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Frank.CrossPlatformWindow.Tests.ConsoleApp.RayTracingDemo;

public class HitRecord(Vector3 point, Vector3 normal, [NotNull] float t, Color color)
{
    public Vector3 Point { get; } = point;
    public Vector3 Normal { get; } = normal;
    public float T { get; } = t;
    public Color Color { get; } = color;
}