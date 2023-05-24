using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDistanceFinder.Core.CustomExceptions
{
    // Custom exception for invalid route
    public class InvalidRouteException : Exception
    {
        public InvalidRouteException(string message) : base(message)
        {
        }
    }
}
