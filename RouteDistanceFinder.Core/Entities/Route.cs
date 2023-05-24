namespace RouteDistanceFinder.Core.Entities
{
    public class Route
    {
        public Route(Academy startAcademy, Academy endAcademy, int distance)
        {
            StartAcademy=startAcademy;
            EndAcademy=endAcademy;
            Distance=distance;
        }
        public int Distance { get; set; }
        public Academy StartAcademy { get; }
        public Academy EndAcademy { get; }
    }
}