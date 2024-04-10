namespace AoC_2015
{
    internal class Day2
    {
        public Day2(string puzzelInput)
        {
            PartOneandtwo(puzzelInput);
        }

        private static void PartOneandtwo(string puzzelInput)
        {
            string[] stringSeparators = new string[] { "\r\n" };
            string[] lines = puzzelInput.Split(stringSeparators, StringSplitOptions.None);

            int allPaperNeeded = 0;
            int allRibonNeeded = 0;

            foreach (string line in lines)
            {
                List<int> presentDimensions = line.Split('x').Select(int.Parse).ToList();

                allPaperNeeded += CalculateWrappingForGift(presentDimensions[0], presentDimensions[1], presentDimensions[2]);
                allRibonNeeded += CalculateRibbonForGift(presentDimensions[0], presentDimensions[1], presentDimensions[2]);
            }

            Console.WriteLine($"Wrapping paper needed is {allPaperNeeded} feet");
            Console.WriteLine($"Ribbon needed is {allRibonNeeded} feet");
        }

        private static int CalculateWrappingForGift(int length, int width, int height)
        {
            List<int> sides = new List<int>
            {
                2 * length * width,
                2 * width * height,
                2 * height * length
            };

            var areaOfSmalestSide = sides.Min()/2;

            return sides[0] + sides[1] + sides[2] + areaOfSmalestSide;
        }

        private static int CalculateRibbonForGift(int length, int width, int height)
        {
            List<int> sides = new List<int>
            {
                length,
                width,
                height 
            };

            sides.Sort();

            return (sides[0] * 2) + (sides[1] * 2) + (length * width * height);
        }
    }
}
