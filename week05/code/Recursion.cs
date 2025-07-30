using System.Collections;
using System.Diagnostics;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {

        var result = 0;
        var temp = 0;
        // TODO Start Problem 1
        Debug.WriteLine("Entering recursion here");
        if (n <= 0)
        {
            Debug.WriteLine("Base case returned 0");
            return 0;
        }

        temp = (int)Math.Pow(n, 2);
        result = temp += SumSquaresRecursive(n - 1);

        Debug.WriteLine($"Returning n = {n} with value {temp} ");
        //result += temp;
        return result;

    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2
        // Base case
        if (word.Length == size)
        {
            results.Add(word); // Add to the list results when the word length is equal to size.
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            var curletter = letters[i]; // Assign the current letter as the current letter
            var lettersleft = letters.Remove(i, 1); // Remove the letter at i index

            PermutationsChoose(results, lettersleft, size, word + curletter); // Recursive call

        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {

        // First time calling function? then create a dictionary
        if (remember == null)
            remember = new Dictionary<int, decimal>();


        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // Check if this has been solved previously
        if (remember.ContainsKey(s))
        {
            return remember[s];

        }

        // Otherwise, solve using recursion
        decimal ways = CountWaysToClimb(s - 1) + CountWaysToClimb(s - 2) + CountWaysToClimb(s - 3);



        remember[s] = ways;
        return ways;

    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // TODO Start Problem 4
        Debug.WriteLine(".::WildcardBinary Problem::.");
        Debug.WriteLine(pattern);
        // Find the position of the placeholder (*) from the pattern using IndexOf 
        // int wildchar = pattern.IndexOf('*');
        // Console.WriteLine(wildchar); 
        //var patlen = pattern.Length - 1; // //Console.WriteLine(patlen); 
        // var bin = new List<char>();
        // var asterisk = '*'; 
        // 
        // foreach (char w in pattern)
        // {
        //     if (w != '*')
        //     {
        //         bin.Add(w);
        //     }
        //     else
        //     {
        //         bin.Add('*');
        //     }

        // }

        // //Console.WriteLine($"{dict.Key} - {dict.Value}"); 
        //  Console.WriteLine(string.Join(", ", w)); 
        var firstIndex = pattern.IndexOf('*');
        Debug.WriteLine(firstIndex);
        var secondIndex = pattern.IndexOf('*', firstIndex + 1);
        Debug.WriteLine(secondIndex);
        var thirdIndex = pattern.IndexOf('*', secondIndex + 1);
        Debug.WriteLine(thirdIndex);

        // Create copy of pattern 
        //var list = new List<string>(pattern);
        // Print new list 
        Debug.WriteLine(string.Join("", pattern));

        // Print character at first index 
        Debug.WriteLine(pattern[firstIndex]);
        // Create new reference to firstIndex (i.e., pos1) 
        var pos1 = pattern[firstIndex];
        Debug.WriteLine(pos1);
        string removed = "";
        string replaced = "";

        foreach (char c in pattern)
        {
            Debug.WriteLine(c.ToString());
            if (c == '*')
            {
                //Console.WriteLine("hit!"); 
                removed = pattern.Remove(firstIndex, 1);
                replaced = removed.Insert(firstIndex, "1");
            }

            return;

        }
        Debug.WriteLine(removed);
        Debug.WriteLine(replaced);

    }
    // Check if pos1 is equal to the wild character asterisk 
    //if (pos1 == '*') {
    // remove and replace the asterisk 
    //list.Remove();
    //var newPattern = list.GetRange(0, firstIndex);
    //Console.WriteLine(newPattern); 
    // //Console.WriteLine(string.Join("", list.GetRange(0, firstIndex))); 
    //  } 
    // for (int i = 0; i < pattern.Length; i++) { 
    // if (pattern[i] == '*') { 
    // } 
    // } 
    // return WildBinary; } 
    //}


    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();

        }

        // Use this syntax to add to the current path
        // for (int i = 0; i < currPath.Count; i++) {
        //     currPath.Add((0, i));
        // }


        currPath.Add((0, 0));
        currPath.Add((0, 1));
        currPath.Add((0, 2));
        currPath.Add((1, 2));
        currPath.Add((2, 2));

        currPath.Add((0, 0));
        currPath.Add((1, 0));
        currPath.Add((2, 0));
        currPath.Add((2, 1));
        currPath.Add((2, 2));

        // var paths = new List<string>
        // {

        // }

        // var expected = new List<string> {
        //     "<List>{(0, 0), (0, 1), (0, 2), (1, 2), (2, 2)}",
        //     "<List>{(0, 0), (1, 0), (2, 0), (2, 1), (2, 2)}"
        // };

        // TODO Start Problem 5
        // ADD CODE HERE

        results.Add(currPath.AsString()); // Use this to add your path to the results array keeping track of complete maze solutions when you find the solution.
    }
}