using System;
using System.Text.RegularExpressions;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        // Console.WriteLine("Hello Sandbox World!");

        // List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // for (int i = numbers.Count - 1; i >= 0; i--)
        // {
        //     if (numbers[i] % 2 == 0)
        //     {
        //         numbers.RemoveAt(i);
        //     }


        // }
        // string result = string.Join(", ", numbers);
        // Console.WriteLine(result);


        // int[] nums = { 2, 5, 1, 9, 6 };
        // int max = nums[0];
        // int min = nums[0];
        // foreach (int n in nums)
        // {

        //     if (n > max) max = n;
        //     if (n < min) min = n;

        // }
        // Console.WriteLine("The maximum number is " + max);
        // Console.WriteLine("The minimum number is " + min);

        string text = "The quick brown fox jumps over the lazy dog. The fox is quick.";
        string find = "fox";
        string replace = "cat";

        Console.WriteLine("Original Text:\n" + text);

        // Plain replace (case-sensitive)
        string replacedText = text.Replace(find, replace);
        Console.WriteLine("\nAfter Replace (Plain):\n" + replacedText);

        // Regex replace (case-insensitive)
        string pattern = Regex.Escape(find); // Escape if input has special characters
        string regexReplaced = Regex.Replace(text, pattern, replace, RegexOptions.IgnoreCase);
        Console.WriteLine("\nAfter Replace (Regex - IgnoreCase):\n" + regexReplaced);

        // Optional: find all matches and report positions
        MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);
        Console.WriteLine("\nMatch Positions:");
        foreach (Match match in matches)
        {
            Console.WriteLine($"Found at index {match.Index}: {match.Value}");
        }

    }
}