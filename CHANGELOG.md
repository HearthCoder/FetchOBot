# Change Log

## v1.3.1
* Fix bug in FetchOBot.GetHistoryRangeAsync() where it would on rare occasions return duplicate copies of the same game

## v1.3.0
* Change enums to serialize as strings so they match Track-o-Bot's JSON

## v1.2.0
* Fix an issue where the parser would throw an exception if the duration field was null

## v1.1.0
* Add FetchOBot.GetHistoryRangeAsync() to retrieve a range of game history based on time or game ID
* Rename FetchOBot.GetHistoryAsync() to FetchOBot.GetHistoryPageAsync()
* Change the type of Game.Id from int to long

## v1.0.0
* Add FetchOBot.GetHistoryAsync() to retrieve a single page from Track-o-Bot's history.json API
