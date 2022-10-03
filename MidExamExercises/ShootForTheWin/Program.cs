using System;
using System.Drawing;
using System.Linq;

namespace ShootForTheWin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            string input = string.Empty;
            int shotTargets = 0;

            while ((input = Console.ReadLine()) != "End")
            {
                int targetIndex = int.Parse(input);

                if (targetIndex < 0 || targetIndex > targets.Length - 1)
                {
                    continue;
                }
                int targetValue = targets[targetIndex];

                if (targetValue == -1)
                {
                    continue;
                }

                targets[targetIndex] = -1;
                shotTargets++;

                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i] > targetValue && targets[i] != targets[targetIndex])
                    {
                        targets[i] -= targetValue;
                        continue;
                    }

                    if (targets[i] <= targetValue && targets[i] != targets[targetIndex])
                    {
                        targets[i] += targetValue;
                    }
                }
            }

            Console.Write($"Shot targets: {shotTargets} -> ");
            Console.Write(string.Join(" ", targets));
        }
    }
}
