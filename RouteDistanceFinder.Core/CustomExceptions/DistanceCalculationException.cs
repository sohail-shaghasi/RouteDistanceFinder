using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDistanceFinder.Core.CustomExceptions
{
    // Custom exception for distance calculation errors
    public class DistanceCalculationException : Exception
    {
        public DistanceCalculationException(string message) : base(message)
        {
        }
    }
}
