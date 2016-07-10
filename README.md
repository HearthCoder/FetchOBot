# Fetch-o-Bot
A .Net library for accessing the Track-o-bot API

## Installation

You can install Fetch-o-Bot via nuget.  In Visual Studio, run the following command in the Package Manager Console:

```
Install-Package FetchOBot
```

## Usage

In an async method:

```c#
var fetchOBot = new FetchOBot();
var history = await fetchOBot.GetHistoryAsync(username, apiToken, page);
```

In a synchronous method (such as a console application):

```c#
var fetchOBot = new FetchOBot();
var history = fetchOBot.GetHistoryAsync(username, apiToken, page).Result;
```

Fetch-o-Bot will throw `FetchOBotUnauthorizedException` if the Track-o-Bot username or API token is invalid.

## Feedback

For bugs or suggestions, you can [open an issue](https://github.com/HearthCoder/FetchOBot/issues) on GitHub.  Or feel free to submit a pull request!
