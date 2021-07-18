# ASB Card Validation Back-end
This project has a basic backend for the ASB card validation challenge. It uses MVC for ASP.Net and Swagger for documentation. This repo also contains tests for the API.

### Running the project
The main solution file is `back-end/ASB.sln`. Please follow the below steps:
* Restore packages using nuget
* Build the solution
* Run the IIS Server
* navigate to https://localhost:44379/index.html to see the swagger documentation

### Running the tests
The solution contains the integration tests for each API call
* Open test explore 
* Run all tests