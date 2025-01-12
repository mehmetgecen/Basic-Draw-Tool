# Draw & Paint App for Children

This is my implementation of educational draw app for children.

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
- **Brush Resizer Tool**: Pen and eraser brushes adjustable via brush panel.
- **Eraser Decider**: Users can choose eraser options between Brush and Touch mode eraser.
  

## User Interface
- Tools can be selected via buttons at the bottom of screen.
- Color Picker Panel only visible when Pen or Bucket Fill selected.
- In main scene, start button instantly start draw scene.

## Color Picker Tool
- Color Picker tool has its own panel activating when Pen or Bucket selected.
- Three seperate sliders for Red Blue and Green color (RGB).
- Player can choose desired color intensity for adjusting sliders.
- Panel also has color preview image. User can observe which color he/she has set. 

## Scenes & Progress Track
- Main scene greets player if player plays first time and provide access for draw scene.
- If game played before, player redirecting to draw scene instantly.

## Save / Load System
All the player's in-game preferences are tracked from the moment he first plays the game and are serialized in json format and saved to the file.

When the player plays the game for the first time, he is directed to the clean canvas. The choices made by the player in the games after the first game are saved and loaded when they next enter the application. Additionally, the system automatically records when application exits. Main scene buttons resets player pref for first time entry.

### Saved and restored preferences:
- Background Color
- Brush Color
- Brush Width
- Stamp Locations
- Slider Handle Positions in All Panels
- Preview Image Color in the Color Panel
- Brush Resizer Preview Image Size

Saving the line objects and writing them to the file has been successfully completed. Restoring the line objects and starting them again in the scene could not be completed due to the structure of the line objects.

Except for the restoration of lines, the Save / Load system works perfectly. Due to its generic structure, it can be integrated into many other applications and games.

Generated stamps saved in runtime with Persistancemanager registration.


# Extra Features

## Animated Menu Buttons
- **Background Music Toggle Button**: Toggles background music.
- **Main Scene Button**: Loads main scene and clear user pref for first time entry.
- **Canvas Cleaner Button**: Cleans all lines, stamps and background color when clicked.
- **Options Button**: Opens options panel.
- **Brush Resizer Button**: Opens brush resizer panel.
- All Buttons are animated from main menu button when clicked in order to save draw area on canvas.

## Options Panel
- Options panel contains eraser preference and background music slider.
- Player can choose between touch and brush modes with using eraser decider.
- In the bottom side of panel background music slider adjusts background music volume level.

## Eraser Decider
- There is two type of eraser in game: Brush and Touch.
- Brush mode eraser works like pen. It generates white lines and clear all stamps, lines and background color.
- Touch mode eraser detects nearest line and deletes them single touch. Does not delete stamps and background color.
- When player selects eraser tool, eraser decider panel spawns automaticly.

## Brush Resizer Panel
- Players can resize line and eraser width using brush resizer panel.
- Orange button with slider icon spawns brush resizer panel.
- Panel is placed under menu button hierarchy.

## Others
- Stamp Tool prints random fruit sprites variations instead of one option.
- Every Tool has its own sound played when operated.
- When a tool selected, its' button color signed as green to inform player.
- Buttons have click sounds that plays when user pressed.
- Folder structured in order to practical review both hierarchy and script side.

  





