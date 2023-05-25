namespace RouteDistanceFinder.Tests
{
    [TestFixture]
    public class RouteCalculatorTests
    {
        private IRouteCalculator _routeCalculator;

        [SetUp]
        public void Setup()
        {
            // Create an instance of RouteCalculator or use a mock
            _routeCalculator = new RouteCalculator();
            _routeCalculator.InitializeRoutes("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
        }

        [TestCase("A-B-C", 9)]
        [TestCase("A-E-B-C-D", 22)]
        public void CalculateDistance_ReturnsDistance(string route, int expectedDistance)
        {
            // Arrange and Act
            int distance = _routeCalculator.CalculateRouteDistance(route);

            // Assert
            Assert.AreEqual(expectedDistance, distance);
        }

        [TestCase("C", "C", 3, 2)]
        public void CountRoutesWithMaxStops_ReturnsCount(string startAcademy, string endAcademy, int maxStops, int expectedCount)
        {
            // Arrange and Act
            int count = _routeCalculator.CountRoutesWithMaxStops(startAcademy, endAcademy, maxStops);

            // Assert
            Assert.AreEqual(expectedCount, count);
        }

        [TestCase("A", "C", 4, 3)]
        public void CountRoutesWithExactStops_ReturnsCount(string startAcademy, string endAcademy, int exactStops, int expectedCount)
        {
            // Arrange and Act
            int count = _routeCalculator.CountRoutesWithExactStops(startAcademy, endAcademy, exactStops);

            // Assert
            Assert.AreEqual(expectedCount, count);
        }

        [TestCase("A", "C", 9)]
        [TestCase("B", "B", 9)]
        public void ShortestRouteDistance_ReturnsDistance(string startAcademy, string endAcademy, int expectedDistance)
        {
            // Arrange and Act
            int distance = _routeCalculator.FindShortestRouteDistanceBFS(startAcademy, endAcademy);

            // Assert
            Assert.AreEqual(expectedDistance, distance);
        }

        [TestCase("C", "C", 30, 7)]
        public void CountRoutesWithDistanceLessThanThreshold_ReturnsCount(string startAcademy, string endAcademy, int maxDistance, int expectedCount)
        {
            // Arrange and Act
            int count = _routeCalculator.CountRoutesWithDistanceLessThanThreshold(startAcademy, endAcademy, maxDistance);

            // Assert
            Assert.AreEqual(expectedCount, count);
        }
    }
}
