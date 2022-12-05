using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal static class Day5
    {
        public static void Execute()
        {
            // Setup
            var data = File.ReadAllLines("input.txt");

            var index = data.ToList().IndexOf(data.First(x => x == string.Empty));

            var size = Int32.Parse(data[index - 1].Substring(data[index - 1].Trim().Length, 1));

            // Part 1
            var stacks1 = SetupStacks(data, size, index);

            var instructionRegex = new Regex("[0-9]+");

            for(int i = index+1; i < data.Length; i++)
            {
                var instructions = instructionRegex.Matches(data[i].ToString()).Select(x => Int32.Parse(x.Value)).ToArray();
                for(int action = 0; action < instructions[0]; action++)
                {
                    var box = stacks1[instructions[1]-1].Pop();
                    stacks1[instructions[2]-1].Push(box);
                }
            }
            var result1 = string.Empty;
            foreach(var stack in stacks1)
            {
                result1 += stack.Pop();
            }

            // Part 2
            var stacks2 = SetupStacks(data, size, index);
            for (int i = index + 1; i < data.Length; i++)
            {
                var instructions = instructionRegex.Matches(data[i].ToString()).Select(x => Int32.Parse(x.Value)).ToArray();
                var theClaw = new List<char>();
                for (int action = 0; action < instructions[0]; action++)
                {
                    theClaw.Add(stacks2[instructions[1] - 1].Pop());
                }
                for(int action = theClaw.Count() - 1; action >= 0; action--)
                {
                    stacks2[instructions[2] - 1].Push(theClaw[action]);
                }
            }
            var result2 = string.Empty;
            foreach (var stack in stacks2)
            {
                result2 += stack.Pop();
            }

            Console.WriteLine(result1);
            Console.WriteLine(result2);

            Console.ReadKey();
        }

        static List<Stack<char>> SetupStacks(string[] data, int size,int index)
        {
            var isLetterRegex = new Regex("[a-zA-Z]");

            var stacks = new List<Stack<char>>();

            for (int i = 0; i < size; i++)
            {
                stacks.Add(new Stack<char>());
            }

            for (int i = index - 2; i >= 0; i--)
            {
                var row = data[i];

                for (int j = 0; j < row.Length; j++)
                {
                    if (isLetterRegex.IsMatch(row[j].ToString()))
                    {
                        stacks[(j - 1) / 4].Push(row[j]);
                    }
                }

            }

            return stacks;
        }
    }
}
