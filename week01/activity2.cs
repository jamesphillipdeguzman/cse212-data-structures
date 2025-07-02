
static void DoSomething(int n)
{
    for (int i = 0; i < n; i++)
    {
        Console.WriteLine(n * n);
    }

    for (i = n; i > 0; i--)
    {
        Console.WriteLine(n * n * n);
    }
}
// Solution: O(n + n) => O(2n) => O(n)

static void DoSomethingElse(List<string> words)
{
    for (int i = 0; i < words.Count; i++)
    {
        for (int j = 0; j < words.Count; j++)
        {
            Console.WriteLine(".");
        }
    }
}
// Solution: O(n^2) 

static void DoAnotherThing(List<string> words)
{
    string sentence = "The quick brown fox jumps over the lazy dog";
    for (int i = 0; i < words.Count; i++)
    {
        for (int j = 0; j < sentence.Length; j++)
        {
            Console.WriteLine(".");
        }
    }
}

// Solution: O(n)