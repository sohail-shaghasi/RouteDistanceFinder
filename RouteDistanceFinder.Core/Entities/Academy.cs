namespace RouteDistanceFinder.Core.Entities
{
    public class Academy
    {
        public string Name { get; set; }
        public List<Route> Routes { get; set; }

        public Academy(string name)
        {
            Name = name;
            Routes = new List<Route>();
        }
    }
}
