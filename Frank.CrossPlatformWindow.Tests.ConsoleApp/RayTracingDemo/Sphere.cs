using System.Numerics;

namespace Frank.CrossPlatformWindow.Tests.ConsoleApp.RayTracingDemo;

public class Sphere
{
    public Vector3 Center { get; }
    public float Radius { get; }
    public Color Color { get; }

    public Sphere(Vector3 center, float radius, Color color)
    {
        Center = center;
        Radius = radius;
        Color = color;
    }

    public HitRecord? Hit(Ray ray, float tMin, float tMax)
    {
        var oc = ray.Origin - Center;
        var a = ray.Direction.Dot(ray.Direction);
        var b = oc.Dot(ray.Direction);
        var c = oc.Dot(oc) - Radius * Radius;
        var discriminant = b * b - a * c;
        if (!(discriminant > 0)) return null;
        
        var temp = (-b - MathF.Sqrt(discriminant)) / a;
        if (temp < tMax && temp > tMin)
        {
            var point = ray.At(temp);
            var normal = (point - Center) / Radius;
            return new HitRecord(point, normal, temp, Color);
        }
        temp = (-b + MathF.Sqrt(discriminant)) / a;
        
        if (!(temp < tMax) || !(temp > tMin)) return null;
        {
            var point = ray.At(temp);
            var normal = (point - Center) / Radius;
            return new HitRecord(point, normal, temp, Color);
        }
    }
}