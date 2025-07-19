using System.Text.Json;
using System.Diagnostics;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

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

        // Solve Anagrams problem 
        // 1) Check if word sets, dict1 and dict2 are both equal in length. Before checking length, make sure to remove the spaces. 
        // 2) Ignore cases by converting the two sets to lowercase 
        // 3) Next, check if each letter from dict1 matches those letters found in dict2. Use Dictionary to test for membership. 
        // Also, ensure the counts of each letter are the same. If this is not the case, then the two sets of words are not anagrams. 
        // 4) If both sets contain the same amount of letters (although they show in a different order), return true, otherwise, return false.


        // Remove spaces and convert to lowercase
        var anagram1 = word1.Replace(" ", "").ToLower();
        Debug.WriteLine(anagram1);
        var anagram2 = word2.Replace(" ", "").ToLower();
        Debug.WriteLine(anagram2);

        // Check if the lengths are equal
        if (anagram1.Length == anagram2.Length)
        {
            Debug.WriteLine("Both dictionaries have equal lengths");
        }
        else
        {
            Debug.WriteLine("Unequal lengths!");
            return false;
        }

        var letters1 = new Dictionary<char, int>();
        var letters2 = new Dictionary<char, int>();


        foreach (char letter1 in anagram1)
        {
            if (!letters1.ContainsKey(letter1))
            {
                letters1[letter1] = 1; // Seen first time
            }
            else
            {
                letters1[letter1]++; // Count all instances of the letter found
            }

        }

        foreach (char letter2 in anagram2)
        {
            if (!letters2.ContainsKey(letter2))
            {
                letters2[letter2] = 1; // Seen first time
            }
            else
            {
                letters2[letter2]++; // Count all instances of the letter found
            }

        }

        foreach (var kvp in letters1) // Loop through each key-value pairs (kvp) in letters1 
        // and take its key and compare if this key exists in letters2; also, compare its value to match to the key-value pair
        {
            int cnt = 0;

            // Find if the key in letters1 had a match with the key in letters2 AND 
            // Check if the key of letters2 did match the value of letters1
            if ((letters2.ContainsKey(kvp.Key) && letters2[kvp.Key] == kvp.Value) && cnt <= letters1.Count)
            {
                Debug.WriteLine($" Match found {kvp.Key} = {kvp.Value}");
                cnt++;
        

            }
            else
            {
                
                return false; // Return false if even one instance of mismatched in the key and value pair was found
            }
        }


        return true; // Otherwise, return true


    }
    
    public static Dictionary<char, int> IntesectSimulator(string text1, string text2)
    {
        // <summary>
        // Solve Intersect Simulator problem (REMINDER: Create your own Intersect function)
        // 1) Remove spaces in both text1 and text2
        // 2) Ignore cases by converting the two inputs to lowercase 
        // 3) Next, check if each character in combination is either a dupe or unique 
        // 4) Duplicates is determined by checking for the value of the key (e.g., greater than 1 is a dupe already)
        //    This simulates the <Intersect> function in Sets.
        // 5) Those with a value of 1 are considered unique characters.
        // 6) Results variable will save every character and remove any duplicates (simulates <Union> in Sets)
        // </summary>

        // Remove spaces and convert to lowercase
        var input1 = text1.Replace(" ", "").ToLower();
        Debug.WriteLine(input1);
        var input2 = text2.Replace(" ", "").ToLower();
        Debug.WriteLine(input2);

        var combinedText = text1 + text2;

        var combination = combinedText.Replace(" ", "").ToLower();

        // Check if the lengths are equal
        if (input1.Length == input2.Length)
        {
            Debug.WriteLine("Both inputs have equal lengths");
        }
        else
        {
            Debug.WriteLine("Unequal lengths!");

        }

        // Create a dictionary for unique, duplicates and combined
        var unique = new Dictionary<char, int>();
        var dupes = new Dictionary<char, int>();
        var combined = new Dictionary<char, int>();

        foreach (char c in combination) // Loop each character in the combination string
        {
            if (!combined.ContainsKey(c))
            {
                combined[c] = 1;  // First time seeing the character
            }
            else
            {
                combined[c]++;  // Count all instances of character
            }
        }

        
        
        var results = new Dictionary<char, int>();
        // Loop through each key-value pairs (or kvp) in combined 
        foreach (var kvp in combined) 
        {
            // Chek if kvp value is greater than 1 (it means a dupe was found)
            if (((kvp.Value) > 1))
            {
                Debug.WriteLine($" Duplicate found {kvp.Key} = {kvp.Value}");
              
                dupes.Add(kvp.Key, kvp.Value); // Filter only duplicates in the string of text (e.g., simulates Intersect)
                results.Add(kvp.Key, kvp.Value); // Capture all unique keys regardless of value (e.g. simulates Union)


            }
            else
            {
                unique.Add(kvp.Key, kvp.Value); // Filter whatever is distince in the string of text 
                results.Add(kvp.Key, kvp.Value); // Capture all unique keys regardless of value 
            }
        }
        

        Debug.WriteLine(string.Join(", ", dupes)); // Dupes is where the two text strings intersects

        Debug.WriteLine(string.Join(", ", unique)); 
             
        return dupes; 

    }

    public static Dictionary<char, int> UnionSimulator(string text1, string text2)
    {
        // <summary>
        // Solve Union Simulator problem (REMINDER: Create your own Union function)
        // 1) Remove spaces in both text1 and text2
        // 2) Ignore cases by converting the two inputs to lowercase 
        // 3) Next, check if each character in combination is either a dupe or unique 
        // 4) Duplicates is determined by checking for the value of the key (e.g., greater than 1 is a dupe already)
        //    This simulates the <Intersect> function in Sets.
        // 5) Those with a value of 1 are considered unique characters.
        // 6) Results variable will save every character and remove any duplicates (simulates <Union> in Sets)
        // </summary>

        // Remove spaces and convert to lowercase
        var input1 = text1.Replace(" ", "").ToLower();
        Debug.WriteLine(input1);
        var input2 = text2.Replace(" ", "").ToLower();
        Debug.WriteLine(input2);

        var combinedText = text1 + text2;

        var combination = combinedText.Replace(" ", "").ToLower();

        // Check if the lengths are equal
        if (input1.Length == input2.Length)
        {
            Debug.WriteLine("Both inputs have equal lengths");
        }
        else
        {
            Debug.WriteLine("Unequal lengths!");

        }

        // Create a dictionary for unique, duplicates and combined
        var unique = new Dictionary<char, int>();
        var dupes = new Dictionary<char, int>();
        var combined = new Dictionary<char, int>();

        foreach (char c in combination) // Loop each character in the combination string
        {
            if (!combined.ContainsKey(c))
            {
                combined[c] = 1;  // First time seeing the character
            }
            else
            {
                combined[c]++;  // Count all instances of character
            }
        }

        

        var results = new Dictionary<char, int>();
        // Loop through each key-value pairs (or kvp) in combined 
        foreach (var kvp in combined) 
        {
            // Chek if kvp value is greater than 1 (it means a dupe was found)
            if (((kvp.Value) > 1))
            {
                Debug.WriteLine($" Duplicate found {kvp.Key} = {kvp.Value}");
              
                dupes.Add(kvp.Key, kvp.Value); // Filter only duplicates in the string of text (e.g., simulates Intersect)
                results.Add(kvp.Key, kvp.Value); // Capture all unique keys regardless of value (e.g. simulates Union)


            }
            else
            {
                unique.Add(kvp.Key, kvp.Value); // Filter whatever is distince in the string of text 
                results.Add(kvp.Key, kvp.Value); // Capture all unique keys regardless of value 
            }
        }
        

        Debug.WriteLine(string.Join(", ", dupes)); // Dupes is where the two text strings intersects

        Debug.WriteLine(string.Join(", ", unique)); 
             
        return results; 

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
        //var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var data = JsonSerializer.Deserialize<FeatureCollection>(json);
        // var feature = JsonSerializer.Deserialize<Features>(json);
        //var features = featureCollection.Features;
        //var metadata = featureCollection.Data;


        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        // string[] summary = new string[featureCollection.metadata.count];
        // for (int i = 0; i < featureCollection.metadata.count; i++)
        // {
        // var place = feature.properties.place;
        //var mag = featureCollection.features.properties.mag;
        //summary[i] = featureCollection.Earthquake.Property.Mag.ToString() + " - Mag " + featureCollection.Features.properties.Mag.ToString();

        //Debug.WriteLine($"{features.Properties.Place} - Mag {features.Properties.Mag}");
        // }

        var summary = new HashSet<string>();
        foreach (var feature in data.features) // Loop through the features array 
        {
            var mag = feature.properties.mag; // Get the earthquakes' magnitude
            var place = feature.properties.place; // Get the location or place 
            summary.Add(place + " - Mag " + mag); // Add each data collected to summary
        }

        return summary.ToArray(); // Output results as array
    }
}