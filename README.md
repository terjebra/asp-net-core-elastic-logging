# POC with ASP.NET Core with Elastic Search Logging 

## Tech
* ASP.NET Core
* Serilog
* Elastic Search with Kibana
* Docker - mulistage

## Usage
* docker-compose build
* docker-compuse up

## API
* http://localhost:5000/api/persons
* http://localhost:5000/api/persons/[id] 
  * Specifying id=2, will throw an exception in order to test the error-logging

## Log
* http://localhost:5601
