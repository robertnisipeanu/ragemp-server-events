# ragemp-server-events
OOP Implementation of the RAGEMP server events (so you don't have to use [Command] or [ServerEvent] annotations). It allows you to add event handlers and commands at runtime

# How to use
1. Copy `client_packages/cs_packages/CustomCommands.cs` to your server client resources (`server-files/client_packages/cs_packages`).

2. From directory `server/` import `Delegates.cs` and `Events.cs` into your server-side project.

3. Add `using robearded.Events;` at the top of the files where you want to use my API.

4. Use `Events.*EventName* += EventHandler;` to add an event handler and `Events.AddCommand("*commandName*", CommandHandler);` to add a command handler.


# Need help?
Please do not contact me if you didn't followed the above steps, I'm not gonna tell you again the steps in private when you have them here.

If you any other help, feel free to contact me on Discord at `@rumble06#4127`
