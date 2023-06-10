namespace RouteDistanceFinder.Core.Validator
{
    public class InputValidator
    {
        public static bool ValidateInput(string input, out string startAcademy, out string endAcademy, out int maxStops)
        {
            startAcademy = null;
            endAcademy = null;
            maxStops = 0;

            string[] inputParts = input.Split(' ');
            input = input.Trim(); // Trim leading and trailing whitespace

            if (inputParts.Length != 3)
            {
                throw new InvalidRouteException("Invalid input. Input should contain three parts separated by spaces.");
            }

            startAcademy = inputParts[0];
            endAcademy = inputParts[1];

            if (startAcademy.Length != 1 || !startAcademy.All(char.IsLetter))
            {
                throw new InvalidRouteException("Invalid input. The first part should be a single letter.");
            }

            if (endAcademy.Length != 1 || !endAcademy.All(char.IsLetter))
            {
                throw new InvalidRouteException("Invalid input. The second part should be a single letter.");
            }

            if (!int.TryParse(inputParts[2], out maxStops) || maxStops < 0)
            {
                throw new InvalidRouteException("Invalid input. The third part should be a non-negative number.");
            }

            return true;
        }

        public static bool ValidateInput(string input, out string startAcademy, out string endAcademy)
        {
            string[] inputParts = input.Split(' ');
            startAcademy = inputParts[0];
            endAcademy = inputParts[1];

            if (inputParts.Length != 2)
            {
                throw new InvalidRouteException("Invalid input. Input should contain two parts separated by spaces.");
            }


            if (startAcademy.Length != 1 || !startAcademy.All(char.IsLetter))
            {
                throw new InvalidRouteException("Invalid input. The first part should be a single letter.");
            }

            if (endAcademy.Length != 1 || !endAcademy.All(char.IsLetter))
            {
                throw new InvalidRouteException("Invalid input. The second part should be a single letter.");
            }
            return true;
        }
    }
}
