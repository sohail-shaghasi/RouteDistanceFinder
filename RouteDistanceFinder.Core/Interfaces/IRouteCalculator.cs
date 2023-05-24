namespace RouteDistanceFinder.Core.Interfaces
{
    public interface IRouteCalculator
    {
        void InitializeRoutes(string input);
        int CalculateRouteDistance(string route);
        int CountRoutesWithMaxStops(string startAcademy, string endAcademy, int maxStops);
        int CountRoutesWithExactStops(string start, string end, int exactStops);
        int FindShortestRouteDistanceBFS(string startAcademy, string endAcademy);
        int CountRoutesWithDistanceLessThanThreshold(string startAcademy, string endAcademy, int maxDistance);
    }
}
