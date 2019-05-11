# ragemp-server-events
OOP Implementation of the RAGEMP server events (so you don't have to use [Command] or [ServerEvent] annotations). It allows you to add event handlers and commands at runtime.

## How to use
1. Copy `/client_packages/cs_packages/CustomCommands.cs` to your server client resources (`server-files/client_packages/cs_packages`).

2. From folder '[server](https://github.com/robertnisipeanu/ragemp-server-events/tree/master/server "server")' import `Delegates.cs` and `Events.cs` into your server-side project.

3. Add `using robearded;` at the top of the files where you want to use my API.

4. Use `Events.*EventName* += EventHandler;` to add an event handler and `Events.AddCommand("*commandName*", CommandHandler);` to add a command handler.

## Added events

- `OnPlayerReady(Client client)` -> This event is not available by default on the C# API

If any other events will be custom implemented they will be added here ^

## Example

You can find an example inside the '[example](https://github.com/robertnisipeanu/ragemp-server-events/tree/master/example "`/example`")' folder.

## Need help?
Please do not contact me if you didn't followed the above steps, I'm not gonna tell you again the steps in private when you have them here.

If you any other help, feel free to contact me on Discord at `@rumble06#4127` or on RAGE.MP Forums at https://rage.mp/profile/45121-robearded/
