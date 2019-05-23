namespace _09.Kamino_Factory
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int lengthOfSamples = int.Parse(Console.ReadLine());

            int[] bestSemple = new int[lengthOfSamples];
            int bestSampleStartOfSequence = lengthOfSamples;
            int bestSampleSequenseLenght = 0;
            int bestSampleSum = 0;
            int bestSampleNumber = 0;

            string sampleStr = string.Empty;

            int sampleCounter = 0;

            while ((sampleStr = Console.ReadLine()) != "Clone them!")
            {
                sampleCounter++;

                int[] currentSample = sampleStr
                                      .Split("!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();

                int currentSampleSum = currentSample.Sum();

                int currentSampleStartOfSequence = 0;
                int currentSampleSequenseLenght = 0;

                for (int i = 0; i < currentSample.Length - 1; i++)
                {
                    int currentStart = i;
                    int currentSequenceLength = 1;

                    for (int j = i + 1; j < currentSample.Length; j++)
                    {
                        if (currentSample[i] == 1 && currentSample[j] == 1)
                        {
                            currentSequenceLength++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (currentSequenceLength > currentSampleSequenseLenght)
                    {
                        currentSampleStartOfSequence = currentStart;
                        currentSampleSequenseLenght = currentSequenceLength;
                    }
                }

                if (currentSampleSequenseLenght > bestSampleSequenseLenght)
                {
                    bestSampleStartOfSequence = currentSampleStartOfSequence;
                    bestSampleSequenseLenght = currentSampleSequenseLenght;
                    bestSampleSum = currentSampleSum;
                    bestSemple = currentSample;
                    bestSampleNumber = sampleCounter;
                }
                else if (currentSampleSequenseLenght == bestSampleSequenseLenght)
                {
                    if (currentSampleStartOfSequence < bestSampleStartOfSequence)
                    {
                        bestSampleStartOfSequence = currentSampleStartOfSequence;
                        bestSampleSequenseLenght = currentSampleSequenseLenght;
                        bestSampleSum = currentSampleSum;
                        bestSemple = currentSample;
                        bestSampleNumber = sampleCounter;
                    }
                    else if (currentSampleStartOfSequence == bestSampleStartOfSequence)
                    {
                        if (currentSampleSum > bestSampleSum)
                        {
                            bestSampleStartOfSequence = currentSampleStartOfSequence;
                            bestSampleSequenseLenght = currentSampleSequenseLenght;
                            bestSampleSum = currentSampleSum;
                            bestSemple = currentSample;
                            bestSampleNumber = sampleCounter;
                        }
                    }
                }
            }

            Console.WriteLine($"Best DNA sample {bestSampleNumber} with sum: {bestSampleSum}.");
            Console.WriteLine(string.Join(" ", bestSemple));
        }
    }
}