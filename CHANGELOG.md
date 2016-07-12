# Change Log

## v1.2.0
* Fix an issue where the parser would throw an exception if the duration field was null

## v1.1.0
* Add FetchOBot.GetHistoryRangeAsync() to retrieve a range of game history based on time or game ID
* Rename FetchOBot.GetHistoryAsync() to FetchOBot.GetHistoryPageAsync()
* Change the type of Game.Id from int to long

## v1.0.0
* Add FetchOBot.GetHistoryAsync() to retrieve a single page from Track-o-Bot's history.json API
