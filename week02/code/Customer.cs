public class Customer // Defect: No Customer class was created to account for the specific PriorityItem which takes a Value and Priority as properties.
{

    public string Value { get; set; }
    public int Priority { get; set; }

    internal Customer(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Prio:{Priority})";
    }
}