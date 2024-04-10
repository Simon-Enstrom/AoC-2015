namespace AoC_2015
{
    internal class Day6
    {
        private const string TurnOn = "turn on";
        private const string TurnOff = "turn off";
        private const string Toggle = "toggle";

        bool[,] lightsGridForPartOne = new bool[1000, 1000];
        int[,] lightsGridForPartTwo = new int[1000, 1000];
        public Day6(string puzzelInput)
        {
            string[] stringSeparators = new[] { "\r\n" };
            string[] stringsToValidate = puzzelInput.Split(stringSeparators, StringSplitOptions.None);

            PartOne(stringsToValidate, lightsGridForPartOne);
            PartTwo(stringsToValidate, lightsGridForPartTwo);
        }

        private class Coordinates
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        private static void PartOne(string[] stringsToValidate, bool[,] lightsGrid)
        {
            AdjustLigthsWithStringArray(stringsToValidate, lightsGrid);           
            int numberOfLigthsOn = CheckHowManyLigthsThatAreOnFromBoolArray(lightsGrid);
            Console.WriteLine($"{numberOfLigthsOn} ligths is on");
        }

        private static void AdjustLigthsWithStringArray(string[] stringsToValidate, bool[,] lightsGrid)
        {
            foreach (string s in stringsToValidate)
            {
                List<Coordinates> coordinates = GetListOfCoordinates(s);

                if (s.StartsWith(TurnOn))
                {
                    SetBoolValueOnLigthsFromOneCoordinateToAnother(new Coordinates() { X = coordinates[0].X, Y = coordinates[0].Y }, new Coordinates() { X = coordinates[1].X, Y = coordinates[1].Y }, lightsGrid, true);
                }
                else if (s.StartsWith(TurnOff))
                {
                    SetBoolValueOnLigthsFromOneCoordinateToAnother(new Coordinates() { X = coordinates[0].X, Y = coordinates[0].Y }, new Coordinates() { X = coordinates[1].X, Y = coordinates[1].Y }, lightsGrid, false);
                }
                else if (s.StartsWith(Toggle))
                {
                    ToggleBoolValueOnLigthsFromOneCoordinateToAnother(new Coordinates() { X = coordinates[0].X, Y = coordinates[0].Y }, new Coordinates() { X = coordinates[1].X, Y = coordinates[1].Y }, lightsGrid);
                }
            }
        }

        private static void SetBoolValueOnLigthsFromOneCoordinateToAnother(Coordinates fromCoordinates, Coordinates throughCoordinates, bool[,] multiDimensionalArray1, bool boolValue)
        {
            for (int i = fromCoordinates.X; i <= throughCoordinates.X; i++)
            {
                for (int j = fromCoordinates.Y; j <= throughCoordinates.Y; j++)
                {
                    multiDimensionalArray1[i, j] = boolValue;
                }
            }
        }

        private static void ToggleBoolValueOnLigthsFromOneCoordinateToAnother(Coordinates fromCoordinates, Coordinates throughCoordinates, bool[,] multiDimensionalArray1)
        {
            for (int i = fromCoordinates.X; i <= throughCoordinates.X; i++)
            {
                for (int j = fromCoordinates.Y; j <= throughCoordinates.Y; j++)
                {
                    multiDimensionalArray1[i, j] = !multiDimensionalArray1[i, j];
                }
            }
        }

        private static int CheckHowManyLigthsThatAreOnFromBoolArray(bool[,] multiDimensionalArray1)
        {
            int numberOfLigthsOn = default;
            foreach (bool ligthOn in multiDimensionalArray1)
            {
                if (ligthOn)
                {
                    numberOfLigthsOn++;
                }
            }

            return numberOfLigthsOn;
        }

        private static void PartTwo(string[] stringsToValidate, int[,] lightsGrid)
        {
            AdjustBrightnessOfLigthsWithStringArray(stringsToValidate, lightsGrid);
            int numberOfLigthsOn = CheckHowManyLigthsThatAreOnFromIntArray(lightsGrid);
            Console.WriteLine($"{numberOfLigthsOn} is the brightness level");
        }

        

        private static void AdjustBrightnessOfLigthsWithStringArray(string[] stringsToValidate, int[,] lightsGrid)
        {
            foreach (string s in stringsToValidate)
            {
                List<Coordinates> coordinates = GetListOfCoordinates(s);

                if (s.StartsWith(TurnOn))
                {
                    SetBrightnessValueOnLigthsFromOneCoordinateToAnother(new Coordinates() { X = coordinates[0].X, Y = coordinates[0].Y }, new Coordinates() { X = coordinates[1].X, Y = coordinates[1].Y }, lightsGrid, true);
                }
                else if (s.StartsWith(TurnOff))
                {
                    SetBrightnessValueOnLigthsFromOneCoordinateToAnother(new Coordinates() { X = coordinates[0].X, Y = coordinates[0].Y }, new Coordinates() { X = coordinates[1].X, Y = coordinates[1].Y }, lightsGrid, false);
                }
                else if (s.StartsWith(Toggle))
                {
                    ToggleBrightnessValueOnLigthsFromOneCoordinateToAnother(new Coordinates() { X = coordinates[0].X, Y = coordinates[0].Y }, new Coordinates() { X = coordinates[1].X, Y = coordinates[1].Y }, lightsGrid);
                }
            }
        }

        private static void SetBrightnessValueOnLigthsFromOneCoordinateToAnother(Coordinates fromCoordinates, Coordinates throughCoordinates, int[,] multiDimensionalArray1, bool boolValue)
        {
            for (int i = fromCoordinates.X; i <= throughCoordinates.X; i++)
            {
                for (int j = fromCoordinates.Y; j <= throughCoordinates.Y; j++)
                {
                    if (boolValue)
                    {
                        multiDimensionalArray1[i, j]++;
                    }
                    else
                    {
                        if (multiDimensionalArray1[i, j] > 0)
                        {
                            multiDimensionalArray1[i, j]--;
                        }
                    }
                }
            }
        }

        private static void ToggleBrightnessValueOnLigthsFromOneCoordinateToAnother(Coordinates fromCoordinates, Coordinates throughCoordinates, int[,] multiDimensionalArray1)
        {
            for (int i = fromCoordinates.X; i <= throughCoordinates.X; i++)
            {
                for (int j = fromCoordinates.Y; j <= throughCoordinates.Y; j++)
                {
                    multiDimensionalArray1[i, j] = multiDimensionalArray1[i, j] + 2;
                }
            }
        }

        private static int CheckHowManyLigthsThatAreOnFromIntArray(int[,] multiDimensionalArray1)
        {
            int brigthnessLevel = default;
            foreach (int brigthness in multiDimensionalArray1)
            {
                brigthnessLevel += brigthness;
            }

            return brigthnessLevel;
        }

        private static List<Coordinates> GetListOfCoordinates(string s)
        {
            string numericPhone = new string(s.Where(c => (Char.IsDigit(c) || c == ' ' || c == ',')).ToArray());
            IEnumerable<string> listOfCoordinateStrings = numericPhone.Split("  ").Where(x => x != string.Empty);

            List<Coordinates> coordinates = new List<Coordinates>();
            foreach (var item in listOfCoordinateStrings)
            {
                var separatedCoordinateValues = item.Split(',').Select(int.Parse).ToList();
                coordinates.Add(new Coordinates() { X = separatedCoordinateValues[0], Y = separatedCoordinateValues[1] });
            }

            return coordinates;
        }             
    }
}
