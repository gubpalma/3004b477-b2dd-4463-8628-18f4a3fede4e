# sequence-finder

## Installation instructions
* .NET Core 6.0 
* Open in Visual Studio and set the startup project to `Sequence.Finder.Host`, then run
* Altenratively use the `dotnet run` command
* Hosted on port 5279

## Docker image
* Can be found [here](https://hub.docker.com/repository/docker/gman82/sequence-find-api)

## Sending requests
* As per the criteria, the request will consist of a single string of numbers, separated by whitespace
* You can use an API diagnostic tool such as [Postman](https://www.postman.com/downloads/) to send a sample request
* The request should be a simple HTTP POST of a JSON body with the string value set as the `data` JSON property