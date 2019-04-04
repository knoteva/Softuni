using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationAdvanced
{
    class ListManipulationAdvanced
    {
        public static List<int> listOfNumbers = new List<int>();

        static void Main()
        {
            List<int> originalList = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < originalList.Count; i++)
            {
                listOfNumbers.Add(originalList[i]);
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" ").ToArray();

                if (tokens[0].ToLower() == "end")
                {
                    break;
                }

                switch (tokens[0])
                {
                    case "Add":
                        listOfNumbers.Add(int.Parse(tokens[1]));
                        break;
                    case "Remove":
                        listOfNumbers.Remove(int.Parse(tokens[1]));
                        break;
                    case "RemoveAt":
                        listOfNumbers.RemoveAt(int.Parse(tokens[1]));
                        break;
                    case "Insert":
                        listOfNumbers.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
                        break;
                    case "Contains":
                        if (listOfNumbers.Contains(int.Parse(tokens[1])))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        List<int> evens = GetEvens();
                        Console.WriteLine(string.Join(" ", evens));
                        break;
                    case "PrintOdd":
                        List<int> odds = GetOdds();
                        Console.WriteLine(string.Join(" ", odds));
                        break;
                    case "GetSum":
                        Console.WriteLine(GetSum());
                        break;
                    case "Filter":

                        List<int> listOfFulfillCondition = new List<int>();
                        string condition = tokens[1];
                        int numberToCompare = int.Parse(tokens[2]);
                        listOfFulfillCondition = FulfillCondition(condition, numberToCompare);
                        Console.WriteLine(string.Join(" ", listOfFulfillCondition));
                        break;
                    default:
                        break;
                }
            }

            if (listOfNumbers.Count != originalList.Count)
            {
                Console.WriteLine(string.Join(" ", listOfNumbers));
            }
            else
            {
                int count = Math.Min(listOfNumbers.Count, originalList.Count);

                for (int i = 0; i < count; i++)
                {
                    if (listOfNumbers[i] != originalList[i])
                    {
                        Console.WriteLine(string.Join(" ", listOfNumbers));
                        break;
                    }
                }
            }
        }

        private static List<int> FulfillCondition(string condition, int numberToCompare)
        {
            List<int> resultOfConditions = new List<int>();

            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                if (condition == "<" && listOfNumbers[i] < numberToCompare
                    || condition == ">" && listOfNumbers[i] > numberToCompare
                    || condition == ">=" && listOfNumbers[i] >= numberToCompare
                    || condition == "<=" && listOfNumbers[i] <= numberToCompare)
                {
                    resultOfConditions.Add(listOfNumbers[i]);
                }
            }
            return resultOfConditions;
        }

        private static string GetSum()
        {
            long sum = 0;

            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                sum += listOfNumbers[i];
            }

            return sum.ToString();
        }

        private static List<int> GetOdds()
        {
            List<int> listOfOddNumbers = new List<int>();

            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                if (listOfNumbers[i] % 2 != 0)
                {
                    listOfOddNumbers.Add(listOfNumbers[i]);
                }
            }

            return listOfOddNumbers;
        }

        private static List<int> GetEvens()
        {
            List<int> listOfEvenNumbers = new List<int>();

            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                if (listOfNumbers[i] % 2 == 0)
                {
                    listOfEvenNumbers.Add(listOfNumbers[i]);
                }
            }

            return listOfEvenNumbers;
        }
    }
}