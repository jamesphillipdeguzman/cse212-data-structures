/// <summary>
/// A basic implementation of a Priority Queue or (PQ) is a line of people at a check-out counter at Watsons, a medical supplies shop.
/// Sample Codes for customer line implementation and Priority numbers are the ff:
/// Senior Citizens or "SC" as Priority 0 
/// Pregnant Women  or "PW" as Priority 0
/// Person with Disability or "PWD" as Priorty 0
/// Regular Customer or "RC" as Priority 2

/// The Enqueue function shall add a item (which contains both data and priority) to the back of the queue.
/// The Dequeue function shall remove the item with the highest priority and return its value.
/// If there are more than one item with the highest priority, then the item closest to the front of the queue will be removed and 
/// its value returned.
/// If the queue is empty, then an error exception shall be thrown.
/// </summary>

public class PriorityQueue
{
    private readonly List<Customer> _queue = new();

    public int Length => _queue.Count; // Defect: Original code does not have a way to check for length of queue.

    /// <summary>
    /// Add a new value to the queue with an associated priority.  
    /// The customer is always added to the back of the queue regardless of the priority.
    /// </summary>
    /// <param name="customer">The customer</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(Customer customer, int priority) // Defect: customer should be of custom class Customer, not a string.
    {

        var newCustomer = new Customer(customer.Value, priority);
        _queue.Add(newCustomer); // Add new customer at the end of the queue    

    }


    public Customer Dequeue()
    {
        if (_queue.Count == 0) // Check the queue if not empty
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority to remove
        var highPrioIndex = 0;
        var person = "";
        int highPrioCount = 0;
        int index = 0;
        Customer customer = _queue[highPrioIndex]; // Defect: Should return only index of customer
        for (; index < _queue.Count; index++)  // Defect: Index must start at 0 to check first customer and not to skip the 2nd person in line
        {
            person = _queue[index].Value; // Check who is the person currently being validated for high priority

            if (_queue[index].Priority >= _queue[highPrioIndex].Priority)
                highPrioIndex = index;
            else if (_queue[index].Priority == 0) // Check priority 0 
            {
                // Remove and return the item with the highest priority
                highPrioCount += 1; // high prio customer detected
                highPrioIndex += 1; // position of high prio customer
                customer = _queue[highPrioIndex]; // Get customer name
                _queue.RemoveAt(highPrioIndex); // Defect: Remove code not included in initial codebase. 
                _queue.Insert(0, customer); // Insert high prio customer to the front
                _queue.RemoveAt(0); // Serve the high prio customer
                index = -1; // reset to -1 to check for next customer. This gets incremented by 1 and becomes 0 again.
                highPrioCount = 0; // reset to 0
                return customer; // return high prio customer for validation in test cases

            }

        }

        _queue.RemoveAt(0); // Start processing regular customer once high prio customers have been served.

        return customer;

    }


    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

