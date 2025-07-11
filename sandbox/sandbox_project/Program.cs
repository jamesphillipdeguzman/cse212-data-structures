using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;

//public class Program
//{
//    static void Main(string[] args)
//    {
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

// string text = "The quick brown fox jumps over the lazy dog. The fox is quick.";
// string find = "fox";
// string replace = "cat";

// Console.WriteLine("Original Text:\n" + text);

// // Plain replace (case-sensitive)
// string replacedText = text.Replace(find, replace);
// Console.WriteLine("\nAfter Replace (Plain):\n" + replacedText);

// // Regex replace (case-insensitive)
// string pattern = Regex.Escape(find); // Escape if input has special characters
// string regexReplaced = Regex.Replace(text, pattern, replace, RegexOptions.IgnoreCase);
// Console.WriteLine("\nAfter Replace (Regex - IgnoreCase):\n" + regexReplaced);

// // Optional: find all matches and report positions
// MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);
// Console.WriteLine("\nMatch Positions:");
// foreach (Match match in matches)
// {
//     Console.WriteLine($"Found at index {match.Index}: {match.Value}");
// }

// Console.WriteLine("\n======================\nSimple Stack\n======================");

// var stack = new Stack<int>();
// stack.Push(1);
// stack.Push(2);
// stack.Push(3);
// stack.Pop();
// stack.Pop();
// stack.Push(4);
// stack.Push(5);
// stack.Pop();
// stack.Push(6);
// stack.Push(7);
// stack.Push(8);
// stack.Push(9);
// stack.Pop();
// stack.Pop();
// stack.Push(10);
// stack.Pop();
// stack.Pop();
// stack.Pop();
// stack.Push(11);
// stack.Push(12);
// stack.Pop();
// stack.Pop();
// stack.Pop();
// stack.Push(13);
// stack.Push(14);
// stack.Push(15);
// stack.Push(16);
// stack.Pop();
// stack.Pop();
// stack.Pop();
// stack.Push(17);
// stack.Push(18);
// stack.Pop();
// stack.Push(19);
// stack.Push(20);
// stack.Pop();
// stack.Pop();

// Console.WriteLine("Final contents:");
// Console.WriteLine(String.Join(", ", stack.ToArray()));

// var q = new Queue<string>();
// q.Enqueue("James");
// q.Enqueue("Angel");
// q.Enqueue("Jarom");

// while (q.Count != 0)
// {
//     string person = q.Dequeue();
//     Console.WriteLine(person);
// }

// Console.WriteLine("The queue is now empty");

// Console.WriteLine("\n======================\nSimple Queue\n======================");

// var queue = new Queue<int>();
// queue.Enqueue(1);
// queue.Enqueue(2);
// queue.Enqueue(3);
// queue.Dequeue();
// queue.Dequeue();
// queue.Enqueue(4);
// queue.Enqueue(5);
// queue.Dequeue();
// queue.Enqueue(6);
// queue.Enqueue(7);
// queue.Enqueue(8);
// queue.Enqueue(9);
// queue.Dequeue();
// queue.Dequeue();
// queue.Enqueue(10);
// queue.Dequeue();
// queue.Dequeue();
// queue.Dequeue();
// queue.Enqueue(11);
// queue.Enqueue(12);
// queue.Dequeue();
// queue.Dequeue();
// queue.Dequeue();
// queue.Enqueue(13);
// queue.Enqueue(14);
// queue.Enqueue(15);
// queue.Enqueue(16);
// queue.Dequeue();
// queue.Dequeue();
// queue.Dequeue();
// queue.Enqueue(17);
// queue.Enqueue(18);
// queue.Dequeue();
// queue.Enqueue(19);
// queue.Enqueue(20);
// queue.Dequeue();
// queue.Dequeue();

// Console.WriteLine("Final contents:");
// Console.WriteLine(String.Join(", ", queue.ToArray()));



//    }
//}

// public static class MysteryStack2
// {
//     private static bool IsFloat(string text)
//     {
//         return float.TryParse(text, out _);
//     }

//     public static float Run(string text)
//     {
//         var stack = new Stack();
//         foreach (var item in text.Split(' '))
//         {
//             if (item == "+" || item == "-" || item == "*" || item == "/") // Check if operator
//             {
//                 if (stack.Count < 2) // ensure the stack has at least 2 or more items when you hit an operator (e.g., "+", "-", "*", "/")
//                     throw new ApplicationException("Invalid Case 1!");

//                 float op2 = (float)stack.Pop();
//                 float op1 = (float)stack.Pop();
//                 float res;
//                 if (item == "+")
//                 {
//                     res = op1 + op2;
//                 }
//                 else if (item == "-")
//                 {
//                     res = op1 - op2;
//                 }
//                 else if (item == "*")
//                 {
//                     res = op1 * op2;
//                 }
//                 else
//                 {
//                     if (op2 == 0) // Division by zero
//                         throw new ApplicationException("Invalid Case 2!");

//                     res = op1 / op2;
//                 }
//                 // Push the results onto the stack after performing the operation on operand 1 and operand 2
//                 stack.Push(res);
//             }
//             else if (IsFloat(item)) // Try to safely parse the itme into float. This will evaluate to either true or false in the IsFloat method above
//             {  // Parse the item to float and push onto the stack
//                 stack.Push(float.Parse(item));
//             }
//             else if (item == "")
//             {
//             }
//             else
//             {
//                 throw new ApplicationException("Invalid Case 3!");
//             }
//         }
//         // Check that there are more than 1 item in the stack!
//         if (stack.Count != 1)
//             throw new ApplicationException("Invalid Case 4!");

//         return (float)stack.Pop();
//     }
// }
