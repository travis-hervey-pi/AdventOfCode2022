using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{

    //2-4,6-8
    //2-3,4-5
    //5-7,7-9
    //2-8,3-7
    //6-6,4-6
    //2-6,4-8

    internal class Day4
    {
        public static void Execute()
        {
            var data = File.ReadAllLines("input.txt");
            var part1 = 0;
            var part2 = 0;
            foreach(var line in data)
            {
                var assignment = line.Split(',').Select(x =>
                {
                 var range = x.Split('-');
                    return new Assignment { Low = Int32.Parse(range[0]), High = Int32.Parse(range[1]) };
                }).ToList();

                // Part 1
                if ((assignment[0].High >= assignment[1].High && assignment[0].Low <= assignment[1].Low) ||
                    (assignment[1].High >= assignment[0].High && assignment[1].Low <= assignment[0].Low))
                {
                    part1++;
                }

                // Part 2
                if ((assignment[0].High >= assignment[1].Low  && assignment[0].Low <= assignment[1].High) ||
                    (assignment[1].High >= assignment[0].Low && assignment[1].Low <= assignment[0].High))
                {
                    part2++;
                }

            }
            Console.WriteLine(part1);
            Console.WriteLine(part2);
            Console.ReadKey();

        }
    }

    internal class Assignment
    {
        public int Low { get; set; }
        public int High { get; set; }
    }
}
