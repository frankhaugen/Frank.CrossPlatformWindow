// See https://aka.ms/new-console-template for more information

using Frank.CrossPlatformWindow;
using Frank.CrossPlatformWindow.Internals;

Console.WriteLine("Hello, World!");

var window = new Window(100, 100);

window.SetPixel(new Pixel(50, 50, 0xFF0000FF));

window.Run();

Console.WriteLine("Goodbye, World!");