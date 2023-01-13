
# Auto-Clicker
An auto-clicker application that is capable of sending keystrokes to background applications.

**Project Status**: In Development
**Note**: This is an experimental, first release of the project (a proof of concept), and it still requires a lot of work. Expect to encounter rough edges and unfinished features!

## Features
-   Send keyboard keystrokes to background applications
-   Broadcast keystrokes to multiple applications at the same time
-   Adjustable click rate
-   Easy to use user interface

## Features (upcoming)
-   Send mouse keystrokes to background applications
-   Error handling (**Note**: The app will currently crash if the expected conditions (the *happy-path*) are not met)
-   Cross-session state presistance
-   Support for more applications (Currently, if the selected application consists of more than one [nested window](https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumchildwindows), keystrokes may not be handled correctly)

## Limitations
*Windows* isn't designed to send keystrokes to background windows, so the app has to play tricks with the *Windows* API to make it happen.

> Background sending can never work perfectly because *Windows* isn't designed to do it. 
> It works with some programs, but not all.

The project takes advantage of `WM_KEYDOWN` and `WM_KEYUP` messages to deliver keystrokes, sending them using `SendMessage` and `PostMessage` API calls.

## User Interface
![enter image description here](https://media.discordapp.net/attachments/770084138249617438/1063300446963372103/image.png?width=1281&height=683)
