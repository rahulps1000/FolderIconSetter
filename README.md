# Folder Icon Setter (Persistent Folder Icons)

A **Windows Forms Application** built with **.NET Framework** that allows users to set custom icons for folders. The icons remain persistent even when the folder is copied to another Windows machine.

## Features  
✅ Set a custom icon for any folder  
✅ Icon persists even after copying to another Windows machine  
✅ Simple and user-friendly **Windows Forms UI**  
✅ Supports **.ico** files for best quality icons  

## How It Works  
1. **Select a folder**  
2. **Choose an icon (.ico file)**  
3. **Apply the icon** – The application modifies folder attributes so the icon remains persistent across different machines  
4. **Verify** – Open the folder on another Windows PC, and the icon stays!  

## Installation  
1. **Download** the latest release from [Releases](https://github.com/rahulps1000/FolderIconSetter/releases).
2. Run the **FolderIconSetter.exe**  

## Requirements  
- **Windows OS** (Tested on Windows 10 & 11)  
- **.NET Framework 4.x** (Pre-installed on most Windows versions)  

## Usage  
1. Launch the application  
2. Click **"Select Folder"** and choose a folder  
3. Click **"Select Icon"** and choose an `.ico` file  
4. Click **"Apply Icon"**  
5. Done! The folder now has a custom icon  

## Screenshots  
*(Add images here, e.g., application UI, before/after folder icons)*  

## How It Works Internally  
- Copies the Icon to the folder
- Creates a hidden `desktop.ini` file inside the selected folder  
- Updates folder attributes to make the `desktop.ini` file effective  
- Embeds the icon within the folder structure to ensure persistence  

## Contributing  
Pull requests are welcome! If you have any suggestions or find a bug, feel free to create an **issue**.  

## License  
[MIT License](LICENSE)  

## Author  
👤 **Rahul P S**  
🔗 [Portfolio](https://rahulps.dev)  
