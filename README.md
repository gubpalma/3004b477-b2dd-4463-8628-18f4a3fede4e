# sequence-finder

## Installation instructions
* .NET Core 6.0 
* Open in Visual Studio and set the startup project to `Sequence.Finder.Host`, then run
* Altenratively use the `dotnet run` command
* Hosted on port 5279

## Docker image
* Can be found [here](https://hub.docker.com/repository/docker/gman82/sequence-find-api)
![image](https://github.com/gubpalma/3004b477-b2dd-4463-8628-18f4a3fede4e/assets/19819334/eaa62f77-6e50-4348-8bea-aebe39a6cfff)

## Sending requests
* As per the criteria, the request will consist of a single string of numbers, separated by whitespace
* You can use an API diagnostic tool such as [Postman](https://www.postman.com/downloads/) to send a sample request
* The request should be a simple HTTP POST of a JSON body with the string value set as the `data` JSON property
![image](https://github.com/gubpalma/3004b477-b2dd-4463-8628-18f4a3fede4e/assets/19819334/9760f1e2-88b3-441f-9bc3-809d400853e5)
