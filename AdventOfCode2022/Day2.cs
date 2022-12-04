namespace AdventOfCode2022
{
    internal static class Day2
    {
        public static void Execute()
        {
            var data = File.ReadAllLines("input.txt");

            int RoundScore(string round) =>
                round switch
                {
                    "A X" => 4,
                    "A Y" => 8,
                    "A Z" => 3,
                    "B X" => 1,
                    "B Y" => 5,
                    "B Z" => 9,
                    "C X" => 7,
                    "C Y" => 2,
                    "C Z" => 6,
                    _ => throw new ArgumentException("oops")
                };

            int RoundScore2(string round) =>
                round switch
                {
                    "A X" => 3,
                    "A Y" => 4,
                    "A Z" => 8,
                    "B X" => 1,
                    "B Y" => 5,
                    "B Z" => 9,
                    "C X" => 2,
                    "C Y" => 6,
                    "C Z" => 7,
                    _ => throw new ArgumentException("oops")
                };

            var total1 = 0;
            var total2 = 0;

            foreach (var value in data)
            {
                total1 += RoundScore(value.Trim());
                total2 += RoundScore2(value.Trim());
            }

            Console.WriteLine(total1);
            Console.WriteLine(total2);
            Console.ReadKey();
        }
    }
}