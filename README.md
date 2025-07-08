# WindowPositionsTool
Simple Windows tool to help assist Windows multi-monitor positions for multiple window configurations.
Move them so they fit to the exact pixel, built for power users who want to quickly shift workloads and analyzes running windows using DLL calls.
I personally use this tool to automate tasks, such as for batch loading multiple SSH connections to servers in order to debug issues or load workspaces.

Main Features:
Arrange Windows from a simple window list
Load or Save from a Configuration File

+ Load Current Windows Positions and modify the X Position,Y Position, Width, and/or Height of Window
+ View your current mouse position while getting initial X and Y positions for exact positioning
+ Launch programs that aren't found on the Window list and run any specialized commands with arguments while arranging them
+ Matches windows using Window Title or Arguments (and path)
+ Does not affect windows unless they match the exact command line and arguments from the configuration.
+ Complementary to RDP Session configurations for those looking for custom resolutions or window management: 
	+ Add width to the X and height to the Y to retrieve the end positions when using this tool
	+ Accurate positioning can be found through `winposstr` for RDP configuration files.
<hr>

Configuration Format:
Window Title....X....Y....Width....Height....Process Path....Arguments

<hr>
Written in C# using .NET 9.0 and WinForms, accessing the user32.dll Windows Library. 

Synchronous Threading: DLL calls currently run from a single thread
