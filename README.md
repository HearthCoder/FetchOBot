# Fetch-o-Bot
A .Net library for accessing the Track-o-bot API

## Installation

You can install Fetch-o-Bot via nuget.
In Visual Studio, run the following command in the Package Manager Console:

```
Install-Package FetchOBot
```

## Usage

### GetHistoryPageAsync

GetHistoryPageAsync is a simple wrapper around the Track-o-Bot history.json call.

```c#
var fetchOBot = new FetchOBot();
var historyPage = await fetchOBot.GetHistoryPageAsync(username, apiToken, page);
```

### GetHistoryRangeAsync

GetHistoryRangeAsync will accumulate a range of game history, starting from the most recent game and including all games after a given time (UTC) or up to (but not including) a game with a given ID.
There are various overrides if you only care about one of those criteria.

```c#
var fetchOBot = new FetchOBot();
var historyRange = await fetchOBot.GetHistoryRangeAsync(username, apiToken, gameId, rangeStartTime);
```


### Synchronous usage

In a synchronous method (such as a console application), you won't be able to use the await keyword.
Instead, you can just access the Result property on the returned task.
This will block until the operation is complete.
For example:

```c#
var fetchOBot = new FetchOBot();
var historyPage = fetchOBot.GetHistoryPageAsync(username, apiToken, page).Result;
```

### Exceptions

Fetch-o-Bot will throw `FetchOBotUnauthorizedException` if the Track-o-Bot username or API token is invalid.

## Feedback

For bugs or suggestions, you can [open an issue](https://github.com/HearthCoder/FetchOBot/issues) on GitHub.
Or feel free to submit a pull request!
