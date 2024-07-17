using System.Numerics;

namespace Frank.CrossPlatformWindow.Tests.ConsoleApp.RayTracingDemo;

public static class CameraExtensions
{
    public static Ray GetRay(this Camera camera, float u, float v) => new Ray(camera.Position, camera.Direction + new Vector3(u, v, 0));
    
    public static Ray GetRay(this Camera camera, Vector2 uv) => camera.GetRay(uv.X, uv.Y);
    
    public static Ray GetRay(this Camera camera, int x, int y, int width, int height)
    {
        var aspectRatio = width / (float)height;
        var scale = MathF.Tan(MathF.PI * camera.FieldOfView / 360);
        
        var u = (2f * (x + 0.5f) / width - 1) * aspectRatio * scale;
        var v = (1 - 2f * (y + 0.5f) / height) * scale;
        
        return camera.GetRay(u, v);
    }
    
    public static Ray GetRay(this Camera camera, Pixel pixel, int width, int height) => camera.GetRay(pixel.X, pixel.Y, width, height);
    
    public static Ray GetRay(this Camera camera, int x, int y, int width, int height, float u, float v) => camera.GetRay(x + u, y + v);
    
    public static void SetPosition(this Camera camera, Vector3 position) => camera.Position = position;
    
    public static void SetDirection(this Camera camera, Vector3 direction) => camera.Direction = direction;
    
    public static void SetFieldOfView(this Camera camera, float fieldOfView) => camera.FieldOfView = fieldOfView;
    
    public static void LookAt(this Camera camera, Vector3 target) => camera.Direction = DirectionHelper.LookAt(camera.Position, target);
    
    public static void LookAt(this Camera camera, float x, float y, float z) => camera.LookAt(new Vector3(x, y, z));
    
    public static void LookAt(this Camera camera, Vector2 target) => camera.LookAt(target.X, target.Y);
    
    public static void LookAt(this Camera camera, int x, int y, int z) => camera.LookAt(new Vector3(x, y, z));
    
    public static void LookAt(this Camera camera, int x, int y) => camera.LookAt(new Vector2(x, y));
    
    public static void LookAt(this Camera camera, float x, float y) => camera.LookAt(new Vector2(x, y));
    
    public static void LookAt(this Camera camera, Pixel target) => camera.LookAt(target.X, target.Y);
    
    public static void Move(this Camera camera, Vector3 direction) => camera.Position += direction;
    
    public static void Move(this Camera camera, float x, float y, float z) => camera.Move(new Vector3(x, y, z));
    
    public static void Move(this Camera camera, Vector2 direction) => camera.Move(direction.X, direction.Y);
    
    public static void Move(this Camera camera, int x, int y, int z) => camera.Move(new Vector3(x, y, z));
    
    public static void Move(this Camera camera, int x, int y) => camera.Move(new Vector2(x, y));
    
    public static void Move(this Camera camera, float x, float y) => camera.Move(new Vector2(x, y));
    
    public static void Move(this Camera camera, Direction direction, float distance) => camera.Move(DirectionHelper.GetVector(direction) * distance);
    
    public static void Move(this Camera camera, Direction direction) => camera.Move(direction, 1);
    
    public static void MoveLeft(this Camera camera, float distance) => camera.Move(Direction.Left, distance);
    
    public static void MoveLeft(this Camera camera) => camera.MoveLeft(1);
    
    public static void MoveRight(this Camera camera, float distance) => camera.Move(Direction.Right, distance);
    
    public static void MoveRight(this Camera camera) => camera.MoveRight(1);
    
    public static void MoveUp(this Camera camera, float distance) => camera.Move(Direction.Up, distance);
    
    public static void MoveUp(this Camera camera) => camera.MoveUp(1);
    
    public static void MoveDown(this Camera camera, float distance) => camera.Move(Direction.Down, distance);
    
    public static void MoveDown(this Camera camera) => camera.MoveDown(1);
    
    public static void MoveForward(this Camera camera, float distance) => camera.Move(Direction.Forward, distance);
    
    public static void MoveForward(this Camera camera) => camera.MoveForward(1);
    
    public static void MoveBackward(this Camera camera, float distance) => camera.Move(Direction.Backward, distance);
    
    public static void MoveBackward(this Camera camera) => camera.MoveBackward(1);
    
    public static void Rotate(this Camera camera, Vector3 rotation) => camera.Direction = Vector3.Transform(camera.Direction, Quaternion.CreateFromYawPitchRoll(rotation.Y, rotation.X, rotation.Z));
    
    public static void Rotate(this Camera camera, float x, float y, float z) => camera.Rotate(new Vector3(x, y, z));
    
    public static void Rotate(this Camera camera, Vector2 rotation) => camera.Rotate(rotation.X, rotation.Y);
    
    public static void Rotate(this Camera camera, int x, int y, int z) => camera.Rotate(new Vector3(x, y, z));
    
    public static void Rotate(this Camera camera, int x, int y) => camera.Rotate(new Vector2(x, y));
    
    public static void Rotate(this Camera camera, float x, float y) => camera.Rotate(new Vector2(x, y));
    
    public static void Rotate(this Camera camera, Direction direction, float angle) => camera.Rotate(DirectionHelper.GetVector(direction) * angle);
    
    public static void Rotate(this Camera camera, Direction direction) => camera.Rotate(direction, 1);
    
    public static void RotateLeft(this Camera camera, float angle) => camera.Rotate(Direction.Left, angle);
    
    public static void RotateLeft(this Camera camera) => camera.RotateLeft(1);
    
    public static void RotateRight(this Camera camera, float angle) => camera.Rotate(Direction.Right, angle);
    
    public static void RotateRight(this Camera camera) => camera.RotateRight(1);
    
    public static void RotateUp(this Camera camera, float angle) => camera.Rotate(Direction.Up, angle);
    
    public static void RotateUp(this Camera camera) => camera.RotateUp(1);
    
    public static void RotateDown(this Camera camera, float angle) => camera.Rotate(Direction.Down, angle);
    
    public static void RotateDown(this Camera camera) => camera.RotateDown(1);
    
    public static void RotateForward(this Camera camera, float angle) => camera.Rotate(Direction.Forward, angle);
    
    public static void RotateForward(this Camera camera) => camera.RotateForward(1);
    
    public static void RotateBackward(this Camera camera, float angle) => camera.Rotate(Direction.Backward, angle);
    
    public static void RotateBackward(this Camera camera) => camera.RotateBackward(1);
    
    public static void Reset(this Camera camera)
    {
        camera.ResetPosition();
        camera.ResetDirection();
        camera.ResetFieldOfView();
    }
    
    public static void ResetPosition(this Camera camera) => camera.Position = Vector3.Zero;
    
    public static void ResetDirection(this Camera camera) => camera.Direction = Vector3.Zero;
    
    public static void ResetFieldOfView(this Camera camera) => camera.FieldOfView = 90;
}