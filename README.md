# # Production Plan Optimization

This application implements an API for calculating the optimal power production plan for a set of power plants based on given load and fuel cost data.

## Getting Started
1. Clone the repository to your local machine.
2. Make sure you have .NET 7 or higher installed (for C# implementation).
3. Open the project in your preferred development environment.

### C# Implementation

1. Navigate to the `ProductionPlanAPI` folder.
2. Open the solution file (`ProductionPlanAPI.sln`) in Visual Studio or your preferred IDE.
3. Build and run the project.
4. Access the API endpoint at http://localhost:8888/productionplan using an API client (swagger, Postman) to POST the payload JSON.

## Usage

1. Prepare a payload JSON similar to the examples provided in the `payload1.json` .
2. Use an API client (Postman) to make a POST request to the `/productionplan` endpoint with the payload JSON.
3. The API will calculate the optimal power production plan based on the payload and return the result in JSON format.

## Strategy Pattern Implementation

In this application, the Strategy Pattern has been used to enhance the flexibility of power plant calculations. Different strategies are employed for various types of power plants, allowing dynamic algorithm selection based on the power plant type.

![alt text](https://dotnettrickscloud.blob.core.windows.net/img/designpatterns/strategy-design-pattern.png)

## Exposing API on Port 8888

The API is configured to listen on port 8888 for the `ProductionPlanApi` profile. This simplifies deployment and testing while ensuring consistent access.

## Unit Tests

Unit tests have been implemented to validate the correctness of the calculations and ensure the reliability of the API endpoints.

## Feedback

If you have any feedback, please reach out to us at m.drira.ahmed@gmail.com

