namespace AoC_2015
{
    internal class Day5
    {
        public Day5(string puzzelInput)
        {
            string[] stringSeparators = new[] { "\r\n" };
            string[] stringsToValidate = puzzelInput.Split(stringSeparators, StringSplitOptions.None);

            PartOne(stringsToValidate);
            PartTwo(stringsToValidate);
        }

        private static void PartOne(string[] puzzelInput)
        {
            List<string> invalidStrings = new List<string> { "ab", "cd", "pq", "xy" };
            List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
            List<string> niceStrings = new List<string>();
            bool isNiceString = true;


            foreach (string line in puzzelInput)
            {
                isNiceString = true;
                if (invalidStrings.Any(line.Contains))
                {
                    isNiceString = false;
                }

                if (!StringContainsAtLeastThreeVowels(vowels, line))
                {
                    isNiceString = false;
                }

                if (!StringContainsLetterThatAppearsTwiceInARow(line))
                {
                    isNiceString = false;
                }

                if (isNiceString)
                {
                    niceStrings.Add(line);
                }
            }
            Console.WriteLine($"Number of nice strings are {niceStrings.Count()}");
        }

        private static void PartTwo(string[] puzzelInput)
        {
            List<string> niceNames = new List<string>();
            foreach (string line in puzzelInput)
            {

                bool letterWhichRepeatsWithExactlyOneLetterBetweenThem = false;

                HashSet<string> pairs = new HashSet<string>();

                for (int i = 0; i < line.Length - 1; i++)
                {
                    for (int j = i + 2; j < line.Length - 1; j++)
                    {
                        if (j + 1 < line.Length)
                        {
                            string currentPair = line.Substring(i, 2);
                            string nextPair = line.Substring(j, 2);

                            if (currentPair == nextPair)
                            {
                                pairs.Add(currentPair);
                                break;
                            }
                        }
                    }
                }

                for (int i = 0; i < line.Length - 2; i++)
                {
                    if (line[i] == line[i+2])
                    {
                        letterWhichRepeatsWithExactlyOneLetterBetweenThem = true;
                    }
                }

                
                if (pairs.Count > 0 && letterWhichRepeatsWithExactlyOneLetterBetweenThem)
                {
                    niceNames.Add(line);
                }
            }

            Console.WriteLine($"Number of nice strings are {niceNames.Count()}");
        }

        private static bool StringContainsLetterThatAppearsTwiceInARow(string line)
        {
            char charFromPreviousItteration = default;

            foreach (char c in line)
            {
                if (charFromPreviousItteration == c)
                {
                    return true;
                }
                charFromPreviousItteration = c;

            }

            return false;
        }

        private static bool StringContainsAtLeastThreeVowels(List<char> vowels, string s)
        {
            int numberOfvowels = default;

            foreach (var item in s)
            {
                if (vowels.Contains(item))
                {
                    numberOfvowels++;
                }
            }

            return numberOfvowels >= 3 ? true : false;
        }
    }
}
