namespace AoC_2015
{
    internal class Day3
    {
        public Day3(string puzzelInput)
        {
            PartOne(puzzelInput);
            PartTwo(puzzelInput);
        }

        private static void PartOne(string puzzelInput)
        {
            List<Coordinate> coordinatesVisited = new List<Coordinate>();

            Coordinate currentCoordinate = new Coordinate();
            coordinatesVisited.Add(new Coordinate() { X = currentCoordinate.X, Y = currentCoordinate.Y });
            foreach (char c in puzzelInput)
            {
                MoveCoordinateByChar(c, currentCoordinate);

                coordinatesVisited.Add(new Coordinate() { X = currentCoordinate.X, Y = currentCoordinate.Y });
            }

            var distinctItems = coordinatesVisited.DistinctBy(x => new { x.X, x.Y }).ToList();
            Console.WriteLine($"Houses visited {distinctItems.Count()}");
        }   

        private static void PartTwo(string puzzelInput)
        {
            List<Coordinate> coordinatesVisited = new List<Coordinate>();
            Coordinate currentSantaCoordinate = new Coordinate();
            Coordinate currentRobotCoordinate = new Coordinate();
            int iterationNumber = 0;
            coordinatesVisited.Add(new Coordinate() { X = currentSantaCoordinate.X, Y = currentSantaCoordinate.Y });
            coordinatesVisited.Add(new Coordinate() { X = currentRobotCoordinate.X, Y = currentRobotCoordinate.Y });
            foreach (char c in puzzelInput)
            {
                iterationNumber++;
                if (iterationNumber % 2 == 0)
                {
                    MoveCoordinateByChar(c, currentSantaCoordinate);
                    coordinatesVisited.Add(new Coordinate() { X = currentSantaCoordinate.X, Y = currentSantaCoordinate.Y });
                }
                else if (iterationNumber % 2 == 1)
                {
                    MoveCoordinateByChar(c, currentRobotCoordinate);
                    coordinatesVisited.Add(new Coordinate() { X = currentRobotCoordinate.X, Y = currentRobotCoordinate.Y });
                }
            }
            var distinctItems = coordinatesVisited.DistinctBy(x => new { x.X, x.Y }).ToList();
            Console.WriteLine($"Houses visited next year {distinctItems.Count()}");
        }

        private static Coordinate MoveCoordinateByChar(char c, Coordinate currentCoordinate)
        {
            switch (c)
            {
                case '^':
                    currentCoordinate.Y++;
                    break;
                case 'v':
                    currentCoordinate.Y--;
                    break;
                case '>':
                    currentCoordinate.X++;
                    break;
                case '<':
                    currentCoordinate.X--;
                    break;
            }

            return currentCoordinate;
        }

        public class Coordinate
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
