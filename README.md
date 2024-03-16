# WindowPositionsTool
Arrange Windows from a Configuration File
<hr>
Features

+Load/Save Configuration File

+Load Current Windows Positions and modify X,Y, Width, and Height of Window

+Get your current mouse position

+Launch programs that aren't found on the Window list and run with arguments

+Matches windows using Window Title or Arguments (and path)
<hr>

Configuration Format:
Window Title....X....Y....Width....Height....Process Path....Arguments

<hr>
Written in C# using .NET 9.0 and WinForms, accessing the user32.dll Windows Library. 

Synchronous Threading: DLL calls currently run from a single thread
