public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    public string type { get; set; }

    public MetaData metadata { get; set; }

    public Features[] features { get; set; }

}


public class MetaData
{
    public long generated { get; set; }
    public string url { get; set; }
    public string title { get; set; }
    public int status { get; set; }
    public string api { get; set; }
    public int count { get; set; }



}

public class Features
{
    public string type { get; set; }

    public Properties properties { get; set; }
}

public class Properties
{
    public double mag { get; set; }
    public string place { get; set; }
}
