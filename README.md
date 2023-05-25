# RouteDistanceFinder
![image](https://github.com/sohail-shaghasi/RouteDistanceFinder/assets/10161791/a7250dd6-4cba-470a-886a-8177b839567d)

### Architecture
In This project, Clean architecture is followed to be able to easily Unit/Integration test all the involved layers. Clean architecture lets infrastructure and implementation details depend on the Application Core.

### App Layer: 
Contains the entry point of the application and handles user interactions.

### Core Layer: 
Contains the core business logic, including the Route Calculator , interfaces, custom exceptions and input validation .

### Tests Layer
The solution includes unit tests to ensure the correctness of the calculation methods and functionality. The tests cover various scenarios and edge cases to provide comprehensive test coverage.

To run the tests, navigate to the test project and execute the test runner of your choice.

Route Calculator
The Route Calculator is a program that calculates various metrics and routes in a given transportation network. It allows users to find distances, count trips, and determine the shortest path between academies (nodes) based on predefined routes (edges) in the network.

### Features
The Route Calculator offers the following features:

Calculate the distance of a specific route: Given a sequence of academies, the program calculates the total distance of the route.

Count trips with a maximum or exact number of stops: The program counts the number of trips between academies with specific constraints, such as the maximum number of stops or an exact number of stops.

Find the shortest path between two academies: Using Breadth first search algorithm, the program determines the shortest path between two academies, considering the weight (distance) of the routes.



### Getting Started
To use the Route Calculator, follow these steps:

Ensure you have .NET 7 installed on your machine.

Clone the repository to your local machine.

Build the solution using your preferred development environment or the command line.

Run the application.

Follow the on-screen instructions to select the desired calculation or route.

### Usage
The Route Calculator prompts the user for input to perform calculations or find routes. The user needs to provide valid inputs according to the specified format. Invalid inputs will result in exceptions with appropriate error messages.

Please refer to the program's instructions for specific input formats and usage details for each calculation or route.



![image](https://github.com/sohail-shaghasi/RouteDistanceFinder/assets/10161791/438b43d4-12a2-4551-9188-e8199d13ee5d)
