@echo off
setlocal

rem Set the source directory and the build directory
set "source_dir=./"
set "build_dir=C:/Program Files (x86)/Steam/steamapps/workshop/content/2394070/3176136103/Mods/ItemRumbleMod/"

rem Remove the existing build directory if it exists
if exist "%build_dir%" rmdir /s /q "%build_dir%"

rem Create the build directory
mkdir "%build_dir%"

rem Copy files from the source directory to the build directory excluding specific files and folders
robocopy "%source_dir%" "%build_dir%" /E /XD .git bin obj .github .vscode build /XF *.sln *.meta ~$*

echo Files copied successfully.

endlocal