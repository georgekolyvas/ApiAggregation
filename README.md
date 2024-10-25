# ApiAggregation

This project was created in order to consolidate data from multiple external APIs and provides a unified endpoint to access the aggregated information. The goal was to create a scalable and efficient system that fetches data from various sources, aggregates it, and delivers it through a single API interface.

*Setup and Configuration*
1) NuGet Packages- 
Swagger:
Swashbuckle.AspNetCore
Swashbuckle.AspNetCore.Annotations

Configuration Interface:
Microsoft.Extensions.Configuration

Dependency Injection:
Microsoft.Extensions.DependencyInjection

Unit Test:
XUnit

2) Environment variables for the external APIs configured in secrets.json.
3) .Net 8
   
*API endpoints*
1) AccuWeather 
Method: Get
URL: http://dataservice.accuweather.com/forecasts/v1/daily/1day/

2) Holiday:
Method: Get
URL: https://holidays.abstractapi.com/v1/

3) Lyrics:
Method: Get
URL: https://api.lyrics.ovh/v1/

![Dependencies](https://github.com/user-attachments/assets/5e36d82b-e98c-4b21-bc04-3d7e9f9577df)

The project's approach is Domain Driven Design (figure) for more flexibility and scalability and implements Unit of Work pattern. 
