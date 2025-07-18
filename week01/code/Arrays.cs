using System.Diagnostics;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Initialization of an empty result double array
        double[] result = [];
        // Set the size of this array to the given length
        result = new double[length];

        // Use a for loop to get the starting number and length or size
        for (int i = 1; i <= length; i++)
        {
            // Multiply the given start number (e.g., 7) each pass to i (e.g., 1, 2, 3, 4, 5)
            double multiple = number * i;
            // Add the results to the result array;  cast the number to double
            result[i - 1] = (double)multiple;
        }
        Debug.WriteLine("The result is: " + string.Join(",", result));
        return result; // return the result
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Get the startIndex (e.g., start) and amountToReturn (e.g., amount)
        int amountToReturn = amount;
        int start = data.Count - amount;

        // Use GetRange to slice the data beginning at the starting index and return number of values using amountToReturn.
        // This will return your slicedSet that you will need to rotate.
        List<int> slicedSet = data.GetRange(start, amountToReturn);

        // Return the numbers on the left side
        int amountToReturn2 = start;
        // Start at 0 index and return the rest of the numbers to the right. This will be your appendSet.
        List<int> appendSet = data.GetRange(0, amountToReturn2);

        // Append the appendSet to the slicedSet
        slicedSet.AddRange(appendSet);

        // Clear the original data set
        data.Clear();
        // Re-assign the newly arranged set of numbers to data
        data.AddRange(slicedSet);
        // Optional check to see if their count are the same
        if (data.Count == slicedSet.Count)
            Debug.WriteLine(string.Join(","), data);

        return;

    }
}
