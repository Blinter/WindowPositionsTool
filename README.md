# WindowPositionsTool

![Screenshot of Tool GUI](repo\images\WindowPsositionsToolScreenShot.jpg)

I personally use this tool to automate tasks, such as for batch loading multiple SSH connections to servers in order to debug issues or load workspaces.

## Main Features:
- Arrange Windows from a simple window list
- Load or Save from a Configuration File

## Miscellaneous
+ Load Current Windows Positions and modify the X Position,Y Position, Width, and/or Height of Window
+ View your current mouse position while getting initial X and Y positions for exact positioning
+ Launch programs that aren't found on the Window list and run any specialized commands with arguments while arranging them
+ Matches windows using Window Title or Arguments (and path)
+ Does not affect windows unless they match the exact command line and arguments from the configuration.
+ Complementary to RDP Session configurations for those looking for custom resolutions or window management: 
	+ Add width to the X and height to the Y to retrieve the end positions when using this tool
	+ Look for `winposstr` and documentation in RDP configuration files.
	+ 
---

### 

Configuration Format:

```text
Window Title....X....Y....Width....Height....Process Path....Arguments
```

---

Written in C# using .NET 9.0 and WinForms, accessing the user32.dll Windows Library. 

Synchronous Threading: DLL calls currently run from a single thread
