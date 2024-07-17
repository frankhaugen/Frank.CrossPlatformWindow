# Frank.CrossPlatformWindow
A base library only displaying the simplest form of a window on Windows, Linux and MacOS. This library is intended to be used as a base for more complex libraries that require a window to be displayed.

## Mechanis
The library uses the SDL2 library to create a window and display it. 

## Usage
To use the library, you need just inject IWindow interface into your class and call the methods you need. The library is designed to be as simple as possible, so it only provides the most basic methods to create a window and display it.

## Example
```csharp
using Frank.CrossPlatformWindow;
using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            IWindow window = new Window();
            window.CreateWindow("Example", 800, 600);
            window.ShowWindow();
            window.Run();
        }
    }
}
```