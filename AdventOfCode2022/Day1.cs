namespace AdventOfCode2022
{ 
    internal static class Day1
    {
        public static void Execute() {
            var data = File.ReadAllLines("input.txt");

            var values = new List<int>();
            var elf = 0;

            values.Add(elf);

            foreach (var value in data)
            {
                if (!string.IsNullOrEmpty(value))
                    values[elf] += Int32.Parse(value);
                else
                {
                    elf++;
                    values.Add(0);
                }
            }

            Console.WriteLine(values.Max());
            Console.WriteLine(values.OrderByDescending(x => x).Take(3).Sum());
            Console.ReadKey();
        }
    }
}