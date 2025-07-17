using System.Diagnostics;
using System.Text.Json;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client.Interfaces;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // Steps to solve Problem 1: Finding Pairs
        // Test Case 1:
        // (FindPairs_TwoPairs)   : ["am", "at", "ma", "if", "fi"];
        //             Returns    : "ma & am", "fi & if" ;

        // Test Case 2: 
        // (FindPairs_OnePair)    : ["ab", "bc", "cd", "de", "ba"];
        //             Returns    : { "ba & ab" };

        // Test Case 3:
        // (FindPairs_SameChar)   : ["ab", "aa", "ba"]
        //             Returns    : { "ba & ab" }

        // Test Case 4:
        // (FindPairs_ThreePairs) : ["ab", "ba", "ac", "ad", "da", "ca"]
        //               Returns  : { "ba & ab", "da & ad", "ca & ac" }

        // Test Case 5: 
        // (FindPairs_ThreePairsNumbers) : ["23", "84", "49", "13", "32", "46", "91", "99", "94", "31", "57", "14"]
        //                       Returns : { "32 & 23", "94 & 49", "31 & 13" }

        // Test Case 6:
        // (FindPairs_NoPairs)   : ["ab", "ac"]
        //               Returns : nothing

        // Steps to solve Problem 1 (FindPairs):
        // 1) Split the string by comma as delimeter to separate each letter or number pair (e.g., am, at, ma, etc.). Save as HashSet<string> called pairs
        // 2) Create a SwapLetters function or find a way to swap each letter-pair and save the results in another HashSet<string> called results.
        // 3) If the two letters or characters were the same (e.g., aa or 11), return the results. 
        //    Otherwise, swap their positions and remove the swapped items to avoid re-scanning.
        // 4) Save the results and return to the calling Test functions.


        // Split the string by comma as delimeter to separate each letter pair (e.g., am, at, ma, etc.). Save as HashSet<string> letterPairs
        var pairs = new HashSet<string>(words);

        var results = new HashSet<string>();

        var swappedPos = "";

        Console.WriteLine(pairs);

        // Swap letters
        foreach (var pair in pairs)
        {
            var pos1 = pair.Substring(0, 1).ToLower().Trim(); // Get first letter or number
            var pos2 = pair.Substring(1, 1).ToLower().Trim(); // Get second letter or number

            if (pos1 == pos2)
            {
                return results.ToArray(); // if the letters or numbers were identical, return the results as an array
            }
            else
            {
                swappedPos = pos2 + pos1;  // Swap the positions (e.g., of letter or numbers)     
            }



            // Check if the swapped letter or number is contained in pairs
            if (pairs.Contains(swappedPos))
            {

                var swappedPairs = pair + " & " + swappedPos; // Combine and concatenate the matched pairs
                pairs.Remove(swappedPos); // Remove the matched pair to avoid re-checking

                results.Add(swappedPairs);
            }

        }


        return results.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        
        // Initialize variables here
        string key = "";
        int value = 0;
    
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            key = fields[3].Trim().ToString(); // Extract the new key for degrees in column 4

            if (fields.Contains(key)) // Does the field contain the key? (e.g., "Bachelors")
            {
                // If yes, get the value and parse it to integer
                value = int.Parse(fields[4].Trim().ToString()); // Get the value or number of people who earned the degree (e.g., column 5)



                if (!degrees.ContainsKey(key)) // if degrees does not contain the key yet, add it
                {

                    degrees.Add(key, value); // add the key and value to degrees dictionary
                    degrees[key] = 1; // first time seeing this key value pair
                }
                else
                {
                    degrees[key]++;// Count the number of people who earned this degree


                }

                
               

                //Debug.WriteLine(String.Join(", ", degrees));
            }


        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        return false;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}