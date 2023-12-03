using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace code;

public class Processor1
{
    public static long Process(string[] input, int red, int blue, int green)
    {
        long sum = 0;
        for (int i = 0; i < input.Length; i++)
        {
            string gameData = input[i].Substring(input[i].IndexOf(':') + 1).Trim(); // Extracting the game data part

            if (BiggerThanLargestCount(gameData, red,blue,green) )
            {
                sum = sum + 1 + i;
            }                                 
        }

        return sum;

    }

    public static bool BiggerThanLargestCount(string gameData, int red, int blue, int green)
    {
        var parts = gameData.Split(new char[] {';',','},StringSplitOptions.RemoveEmptyEntries);

                foreach (var part in parts)
                {
                    var elements = part.Trim().Split(' ');
                    if (elements.Length == 2 && int.TryParse(elements[0], out int count))
                    {
                        switch (elements[1].ToLower())
                        {
                            case "red":
                                if (count > red)
                                {
                                    return false;
                                }
                                break;
                            case "blue":
                                if (count > blue)
                                {
                                    return false;
                                }
                                break;
                            case "green":
                                if (count > green)
                                {
                                    return false;
                                }
                                break;
                        }
                    }
                }
        return true;
    }
}
