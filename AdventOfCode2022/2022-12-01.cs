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

var total = 0;

foreach (var value in data)
{
    total += RoundScore(value.Trim());
}

Console.WriteLine(total);
Console.ReadKey();

//var values = new List<int>();
//var elf = 0;

//values.Add(elf);

//foreach (var value in data)
//{
//    if (!string.IsNullOrEmpty(value))
//        values[elf] += Int32.Parse(value);
//    else
//    {
//        elf++;
//        values.Add(0);
//    }
//}

//Console.WriteLine(values.Max());
//Console.WriteLine(values.OrderByDescending(x => x).Take(3).Sum());
//Console.ReadKey();

