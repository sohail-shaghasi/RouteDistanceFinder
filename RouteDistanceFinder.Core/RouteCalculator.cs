namespace RouteDistanceFinder.Core
{
    public class RouteCalculator : IRouteCalculator
    {
        // Adjacency list
        Dictionary<string, Academy> Academies = new Dictionary<string, Academy>();
        
        /*
          * This function calculates the total distance of a given route represented as a string. 
          * It splits the route into individual segments and iterates through each segment. 
          * For each segment, it retrieves the start academy from a dictionary and searches for the route to the end academy based on the provided names. 
          * If the route exists, it adds its distance to the total distance. 
          * If either the start academy or the desired route doesn't exist, it returns -1 to indicate failure.
          * */
        public int CalculateRouteDistance(string route)
        {
            string[] routeArray = route.Split('-');
            int totalDistance = 0;

            for (int i = 0; i < routeArray.Length - 1; i++)
            {
                string startAcademyName = routeArray[i];
                string endAcademyName = routeArray[i + 1];

                //retrieve the start academy from the Academies dictionary and then find the route from the start academy to the end academy based on the given names.
                if (Academies.TryGetValue(startAcademyName, out Academy startAcademy))
                {
                    Route desiredRoute = startAcademy.Routes.FirstOrDefault(r => r.EndAcademy.Name == endAcademyName);

                    if (desiredRoute != null)
                    {
                        totalDistance += desiredRoute.Distance;
                    }
                    else
                    {
                        // If the desired route doesn't exist, return -1 to indicate failure
                        return -1;
                    }
                }
                else
                {
                    // If the start academy doesn't exist, return -1 to indicate failure
                    return -1;
                }
            }

            return totalDistance;
        }
        public int CountRoutesWithMaxStops(string start, string end, int maxStops)
        {
            Academy startAcademy = Academies[start];
            Academy endAcademy = Academies[end];
            int countOfMaxStops = 0;

            CountRoutesWithMaxStopsDFS(startAcademy, endAcademy, 0, maxStops, ref countOfMaxStops);

            return countOfMaxStops;
        }
        public void CountRoutesWithMaxStopsDFS(Academy startAcademy, Academy endAcademy, int stops, int maxStops, ref int countOfMaxStops)
        {
            if (stops > maxStops)
            {
                return;
            }

            if (startAcademy == endAcademy && stops > 0)
            {
                countOfMaxStops++;
            }

            foreach (var nextAdjacentAcademy in startAcademy.Routes)
            {
                // the endAcademy becomes the start academy in the next iteration 
                // this will continue until we get closer to the end academy
                CountRoutesWithMaxStopsDFS(nextAdjacentAcademy.EndAcademy, endAcademy, stops + 1, maxStops, ref countOfMaxStops);
            }
        }
        public int CountRoutesWithExactStops(string start, string end, int exactStops)
        {
            Academy startAcademy = Academies[start];
            Academy endAcademy = Academies[end];
            int count = 0;

            CountRoutesWithExactStopsDFS(startAcademy, endAcademy, 0, exactStops, ref count);

            return count;
        }
        public void CountRoutesWithExactStopsDFS(Academy startAcademy, Academy endAcademy, int stops, int exactStops, ref int count)
        {
            /*
             * When an exact number of stops are reached and both start and end Academies same,
             * then a valid route is found! add 1 to the count.
              */
            if (stops == exactStops && startAcademy == endAcademy)
            {
                count++;
                return;
            }

            if (stops >= exactStops)
            {
                return;
            }

            foreach (var nextAcademy in startAcademy.Routes)
            {
                CountRoutesWithExactStopsDFS(nextAcademy.EndAcademy, endAcademy, stops + 1, exactStops, ref count);
            }
        }
        public int FindShortestRouteDistanceBFS(string start, string end)
        {
            Academy startAcademy = Academies[start];
            Academy endAcademy = Academies[end];
            Dictionary<Academy, int> distances = new Dictionary<Academy, int>();

            foreach (var academy in Academies.Values)
            {
                distances[academy] = int.MaxValue;
            }

            distances[startAcademy] = 0;

            // Hashset data structure is used to ensures that each academy is visited only once
            // to avoid revisiting the same academy and potentially getting stuck in an infinite loop if there are cycles in the graph.
            HashSet<Academy> visited = new HashSet<Academy>();

            // Queue data structure is used to ensures that the Academies are processed in the order
            // they are discovered, exploring the neighboring Academies level by level.
            Queue<Academy> queue = new Queue<Academy>();
            queue.Enqueue(startAcademy);

            while (queue.Count > 0)
            {
                var currentAcademy = queue.Dequeue();
                visited.Add(currentAcademy);

                foreach (var neighbor in currentAcademy.Routes)
                {
                    int distance = distances[currentAcademy] + neighbor.Distance;
                    if (distance < distances[neighbor.EndAcademy] || 
                        (neighbor.EndAcademy == startAcademy && distances[neighbor.EndAcademy] == 0))
                    {
                        distances[neighbor.EndAcademy] = distance;
                    }
                    if (!visited.Contains(neighbor.EndAcademy))
                    {
                        queue.Enqueue(neighbor.EndAcademy);
                    }
                }
            }
            // if end academy still has maxValue, that means there is no shortest path
            return distances[endAcademy] == int.MaxValue ? -1 : distances[endAcademy];
        }

        /*
         * The purpose of the code is to find and count all the routes with distances less than 
         * the specified maximum distance between the starting and ending Academies.
         */
        public int CountRoutesWithDistanceLessThanThreshold(string start, string end, int maxDistance)
        {
            Academy startAcademy = Academies[start];
            Academy endAcademy = Academies[end];
            int count = 0;

            CountRoutesWithDistanceLessThanThresholdDFS(startAcademy, endAcademy, 0, maxDistance, ref count);

            return count;
        }

        public void CountRoutesWithDistanceLessThanThresholdDFS(Academy currentAcademy, Academy endAcademy, int currentDistance, int maxDistance, ref int count)
        {
            if (currentDistance >= maxDistance)
            {
                return;
            }

            if (currentAcademy == endAcademy && currentDistance > 0)
            {
                count++;
            }

            foreach (var nextAcademy in currentAcademy.Routes)
            {
                int distance = nextAcademy.Distance;
                CountRoutesWithDistanceLessThanThresholdDFS(nextAcademy.EndAcademy, endAcademy, currentDistance + distance, maxDistance, ref count);
            }
        }
        public void InitializeRoutes(string input)
        {
            Academies = new Dictionary<string, Academy>();

            string[] routes = input.Split(", ");
            foreach (string route in routes)
            {
                // Identify the source and destination Academies.
                string startAcademyName = route[0].ToString();
                string endAcademyName = route[1].ToString();
                int distance = int.Parse(route.Substring(2));

                // Add the academy to the list if it does not exist.
                if (!Academies.ContainsKey(startAcademyName))
                {
                    Academies[startAcademyName] = new Academy(startAcademyName); ;
                }

                if (!Academies.ContainsKey(endAcademyName))
                {
                    Academies[endAcademyName] = new Academy(endAcademyName); ;
                }

                Academy startAcademy = Academies[startAcademyName];
                Academy endAcademy = Academies[endAcademyName];

                // create the Route object and add it to the Routes list of the start academy.
                Route newRoute = new Route(startAcademy, endAcademy, distance);
                startAcademy.Routes.Add(newRoute);
            }
        }
    }
}
