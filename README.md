# Otsimo 2024 Game Developer Internship Task

This is my implementation of the task I received at mehmetgecen06@gmail.com

A drawing tool implemented in Unity, suitable for mobile platforms. This tool provides various features such as pen, eraser, bucket fill, and stamp tool.

## Unity Version
- 2022.3.19f1 LTS

## Platform : Mobile
- Build Support : Android &  iOS
- Succesfully tested an ran on Android Platform
- Built version compatible between Android 5.1 - Android 13.0

# Features

## Tools

- **Pen Tool**: Draw lines with customizable colors.
- **Eraser Tool**: Erase drawn lines and stamps.
- **Bucket Fill Tool**: Fill enclosed areas with a selected color.
- **Stamp Tool**: Add predefined stamps to the canvas.
- **Color Picker Tool**: Adds functionality to pick color for color-necessary tools.

## User Interface
- Tools can be selected via buttons at the bottom of screen.
- Color Picker Panel only visible when Pen or Bucket Fill selected.
- In main scene, start button instantly start draw scene.
- If user does not click on start button, draw scene loaded in 4 sec.

## Color Picker Tool
- Color Picker tool has its own panel activating when Pen or Bucket selected.
- Three seperate sliders for Red Blue and Green color (RGB).
- Player can choose desired color intensity for adjusting sliders.
- Panel also has color preview image. User can observe which color he/she has set. 

## Scenes & Progress Track
- Main scene greets player if player plays first time and provide access for draw scene.
- If game played before, player redirecting to draw scene instantly.

## Extra Features
- Stamp Tool prints random fruit sprites variations instead of one option.
- Every Tool has its own sound played when operated.
- When a tool selected, its' button color signed as green to inform player.





