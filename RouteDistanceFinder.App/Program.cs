

List<string> Options = new List<string>() { "1", "2", "3", "4", "5" };

RouteCalculator routeCalculator = new();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("======================================");
Console.WriteLine("     Welcome to Route Distance Finder!");
Console.WriteLine("======================================");
Console.ResetColor();
// User to enter the routes and processes them dynamically.
string input = GetUserInput("Enter the route data: (eg.): AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
routeCalculator.InitializeRoutes(input);
while (true)
{
    Console.WriteLine("Select an option:");
    Console.WriteLine("1. Calculate route distance");
    Console.WriteLine("2. Calculate trips with maximum stops");
    Console.WriteLine("3. Calculate trips with exact stops");
    Console.WriteLine("4. Calculate the shortest path");
    Console.WriteLine("5. Calculate and determine the count of viable routes with a distance shorter than a given limit.");
    Console.WriteLine("Enter your choice: ");
    try
    {
        string selectOption = Console.ReadLine();
        if (!Options.Contains(selectOption))
        {
            Console.WriteLine("Invalid option, please try again:");
            continue;
        }
        Console.WriteLine();// Line space
        if (selectOption == "1")
        {
            string route = GetUserInput("Enter the route: eg. (A-B-C)");
            int distance = routeCalculator.CalculateRouteDistance(route);
            if (distance < 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("======================================");
                Console.WriteLine("       NO SUCH ROUTE                  ");
                Console.WriteLine("======================================");
                Console.ResetColor();
                continue;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("======================================");
            Console.WriteLine($"{route} Distance: {distance} ");
            Console.WriteLine("======================================");
            Console.ResetColor();

        }
        else if (selectOption == "2")
        {
            string route = GetUserInput("Enter the starting point, ending point (e.g., 'C C'):");
            if (InputValidator.ValidateInput(route, out string startAcademy, out string endAcademy, out int maxStops))
            {
                // Input is valid, continue with processing
                // startAcademy, endAcademy, and maxStops variables
                int maxNumberOfStops = routeCalculator.CountRoutesWithMaxStops(startAcademy, endAcademy, maxStops);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("======================================");
                Console.WriteLine($"{route} Max stops: {maxNumberOfStops}");
                Console.WriteLine("======================================");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Invalid input, please try again:");
                continue;
            }
        }
        else if (selectOption == "3")
        {
            string route = GetUserInput("Enter the starting point, ending point, and exact number of stops (e.g., 'C C 3'):");
            if (InputValidator.ValidateInput(route, out string startAcademy, out string endAcademy, out int exactNumberOfStops))
            {
                // Input is valid, continue with processing
                // startAcademy, endAcademy, and exactNumberOfStops variables
                int exactStops = routeCalculator.CountRoutesWithExactStops(startAcademy, endAcademy, exactNumberOfStops);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("======================================");
                Console.WriteLine($"{route} Exact number of stops: {exactStops}");
                Console.WriteLine("======================================");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Invalid input, please try again:");
                continue;
            }
        }
        else if (selectOption == "4")
        {
            string route = GetUserInput("Enter the starting point, ending point, and exact number of stops (e.g., 'C C 3'):");
            if (InputValidator.ValidateInput(route, out string startAcademy, out string endAcademy))
            {
                // Input is valid, continue with processing
                // startAcademy, endAcademy, and exactNumberOfStops variables
                int exactStops = routeCalculator.FindShortestRouteDistanceBFS(startAcademy, endAcademy);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("======================================");
                Console.WriteLine($"{route} Exact number of stops: {exactStops}");
                Console.WriteLine("======================================");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Invalid input, please try again:");
                continue;
            }
        }
        else if (selectOption == "5")
        {
            string route = GetUserInput("Enter the starting point, ending point, and threshold (e.g., 'C C 30'):");
            if (InputValidator.ValidateInput(route, out string startAcademy, out string endAcademy, out int threshold))
            {
                // Input is valid, continue with processing
                // startAcademy, endAcademy, and exactNumberOfStops variables
                int routes = routeCalculator.CountRoutesWithDistanceLessThanThreshold(startAcademy, endAcademy, threshold);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("======================================");
                Console.WriteLine($"{route} Number of routes less than {threshold}: {routes}");
                Console.WriteLine("======================================");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Invalid input, please try again:");
                continue;
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Please try again.");
        }
    }
    catch (InvalidRouteException ex)
    {
        Console.WriteLine("Invalid route: " + ex.Message);
    }
    catch (DistanceCalculationException ex)
    {
        Console.WriteLine("Error calculating distance: " + ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred: " + ex.Message);
    }
}

string GetUserInput(string prompt)
{
    Console.WriteLine(prompt);
    string input = Console.ReadLine();
    if (input is not null)
    {
        return input;
    }
    throw new ArgumentNullException();
}