# Auto-Clicker
An auto-clicker application that is capable of sending keystrokes to background applications.

**Project Status**: In Development

## Features
-   Ability to send keystrokes to background applications
-   Ability to broadcast keystrokes to multiple applications at the same time
-   Adjustable click rate
-   Easy to use user interface

## Limitations
*Windows* isn't designed to send keystrokes to background windows, so the app has to play tricks with the *Windows* API to make it happen.

> Background sending can never work perfectly because *Windows* isn't designed to do it. 
> It works with some programs, but not all.

The project takes advantage of `WM_KEYDOWN` and `WM_KEYUP` messages to deliver keystrokes, sending them using `SendMessage` and `PostMessage` API calls.

## User Interface
![enter image description here](https://media.discordapp.net/attachments/770084138249617438/1063300446963372103/image.png?width=1281&height=683)
