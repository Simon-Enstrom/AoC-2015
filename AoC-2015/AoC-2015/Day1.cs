namespace AoC_2015
{
    internal class Day1
    {
        public Day1(string puzzelInput)
        {
            PartOne(puzzelInput);
            PartTwo(puzzelInput);
        }

        private static void PartOne(string puzzelInput)
        {
            int floorThatSantaIsOn = 0;
            foreach (var c in puzzelInput)
            {
                if (c == '(')
                {
                    floorThatSantaIsOn++;
                }
                else if (c == ')')
                {
                    floorThatSantaIsOn--;
                }
            }

            Console.WriteLine($"Santa is on floor {floorThatSantaIsOn}");
        }

        public class TrackingSanta
        {
            public int FloorLocation { get; set; }
            public int NumberOfMovements { get; set; }
        }

        private static void PartTwo(string puzzelInput)
        {
            TrackingSanta santaLocation = new TrackingSanta();
            foreach (var c in puzzelInput)
            {
                if (c == '(')
                {
                    santaLocation.FloorLocation++;
                }
                else if (c == ')')
                {
                    santaLocation.FloorLocation--;
                }
                santaLocation.NumberOfMovements++;

                if (santaLocation.FloorLocation == -1)
                {
                    Console.WriteLine($"Santa entered the basement on position {santaLocation.NumberOfMovements}");
                    return;
                }
            }
        }
    }
}
