namespace Frank.CrossPlatformWindow.Tests.ConsoleApp.RayTracingDemo;

public class Scene
{
    private List<Sphere> Spheres { get; } = new List<Sphere>();

    public void Add(Sphere sphere) => Spheres.Add(sphere);

    public HitRecord? Hit(Ray ray, float tMin, float tMax)
    {
        HitRecord? hitRecord = null;
        var closestSoFar = tMax;

        foreach (var sphere in Spheres)
        {
            var hit = sphere.Hit(ray, tMin, closestSoFar);
            if (hit is null) continue;
            
            closestSoFar = hit.T;
            hitRecord = hit;
        }
        
        return hitRecord;
    }
}