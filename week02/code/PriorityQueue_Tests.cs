using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.
//The Enqueue function shall add an item (which contains both data and priority) to the back of the queue.
//The Dequeue function shall remove the item with the highest priority and return its value.
//If there are more than one item with the highest priority, then the item closest to the front of the queue will be removed and 
//its value returned.
//If the queue is empty, then an error exception shall be thrown.

/// A basic implementation of a Priority Queue or (PQ) is a line of people at a check-out counter at Watsons, a medical supplies shop.
/// Sample Codes for customer line implementation and Priority numbers are the ff:
/// Senior Citizens or "SC" as Priority 0 
/// Pregnant Women  or "PW" as Priority 0
/// Person with Disability or "PWD" as Priorty 0
/// Regular Customer or "RC" as Priority 2

/// Author: James Phillip De Guzman
/// Date: July 12, 2025
/// Course/Subject: CSE 212 / Data Structures and Algorithm
/// Instructor: David Quigley


[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // SeniorCitizen

    // Scenario: A senior citizen showed up at the back of the line but was asked by the counter lady to move to the front.
    // Line is maximum of 5 people.
    // Expected Result: Efren, James, Ren, Joy, Gian
    // Defect(s) Found: 
    // Defect 1: Original code does not have a way to check for length of queue.
    // Defect 2: Customer should be of custom class Customer, not a string.
    // Defect 3: Should return only index of customer.
    // Defect 4: Index must start at 0 to check first customer and not to skip the 2nd person in line
    // Defect 5: No Customer class was created to account for the specific PriorityItem which takes a Value and Priority as properties.

    public void TestPriorityQueue_SeniorCitizen()
    {

        var James = new Customer("RC-1", 2);
        var Ren = new Customer("RC-2", 2);
        var Joy = new Customer("RC-3", 2);
        var Gian = new Customer("RC-4", 2);
        var Efren = new Customer("SC-1", 0);

        Customer[] expectedResult = [Efren, James, Ren, Joy, Gian];

        var pq = new PriorityQueue();

        pq.Enqueue(James, James.Priority);
        pq.Enqueue(Ren, Ren.Priority);
        pq.Enqueue(Joy, Joy.Priority);
        pq.Enqueue(Gian, Gian.Priority);
        pq.Enqueue(Efren, Efren.Priority);


        for (int i = 0; i < pq.Length; i++)
        {
            Customer customer = pq.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, customer.Value);
        }


    }

    [TestMethod]
    //PregnantWoman

    // Scenario: A pregnant woman showed up at the back of the line but was asked by the counter lady to move to the front.
    // Line is maximum of 5 people.
    // Expected Result:  Marie, James, Ren, Joy, Gian
    // Defect(s) Found: None
    public void TestPriorityQueue_PregnantWoman()
    {
        var James = new Customer("RC-1", 2);
        var Ren = new Customer("RC-2", 2);
        var Joy = new Customer("RC-3", 2);
        var Gian = new Customer("RC-4", 2);
        var Marie = new Customer("PW-1", 0);

        Customer[] expectedResult = [Marie, James, Ren, Joy, Gian];

        var pq = new PriorityQueue();

        pq.Enqueue(James, James.Priority);
        pq.Enqueue(Ren, Ren.Priority);
        pq.Enqueue(Joy, Joy.Priority);
        pq.Enqueue(Gian, Gian.Priority);
        pq.Enqueue(Marie, Marie.Priority);


        for (int i = 0; i < pq.Length; i++)
        {
            Customer customer = pq.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, customer.Value);
        }

    }

    [TestMethod]
    // PWD

    // Scenario: A PWD showed up at the back of the line but was asked by the counter lady to move to the front.
    // Line is maximum of 5 people.
    // Expected Result:  Angel, James, Ren, Joy, Gian
    // Defect(s) Found: None
    public void TestPriorityQueue_PWD()
    {
        var James = new Customer("RC-1", 2);
        var Ren = new Customer("RC-2", 2);
        var Joy = new Customer("RC-3", 2);
        var Gian = new Customer("RC-4", 2);
        var Angel = new Customer("PWD-1", 0);

        Customer[] expectedResult = [Angel, James, Ren, Joy, Gian];

        var pq = new PriorityQueue();

        pq.Enqueue(James, James.Priority);
        pq.Enqueue(Ren, Ren.Priority);
        pq.Enqueue(Joy, Joy.Priority);
        pq.Enqueue(Gian, Gian.Priority);
        pq.Enqueue(Angel, Angel.Priority);


        for (int i = 0; i < pq.Length; i++)
        {
            Customer customer = pq.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, customer.Value);
        }
    }

    [TestMethod]
    //MixedLine

    // Scenario: 1 pregnant woman, 1 PWD, and 2 senior citizens showed up at the back of the line. Counter lady asked them to move to 
    // the front by priority.
    // Line is maximum of 8 people.
    // Expected Result: Marie, Angel, Amy, Efren, James, Ren, Joy, Gian
    // Defect(s) Found: None
    public void TestPriorityQueue_MixedLine()
    {

        var James = new Customer("RC-1", 2);
        var Ren = new Customer("RC-2", 2);
        var Joy = new Customer("RC-3", 2);
        var Gian = new Customer("RC-4", 2);
        var Marie = new Customer("PW-1", 0);
        var Angel = new Customer("PWD-1", 0);
        var Amy = new Customer("SC-1", 0);
        var Efren = new Customer("SC-2", 0);

        Customer[] expectedResult = [Marie, Angel, Amy, Efren, James, Ren, Joy, Gian];

        var pq = new PriorityQueue();


        pq.Enqueue(James, James.Priority);
        pq.Enqueue(Ren, Ren.Priority);
        pq.Enqueue(Joy, Joy.Priority);
        pq.Enqueue(Gian, Gian.Priority);
        pq.Enqueue(Marie, Marie.Priority);
        pq.Enqueue(Angel, Angel.Priority);
        pq.Enqueue(Amy, Amy.Priority);
        pq.Enqueue(Efren, Efren.Priority);


        for (int i = 0; i < pq.Length; i++)
        {
            Customer customer = pq.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, customer.Value);
        }
    }

    [TestMethod]
    // EqualPriority

    // Scenario: 2 senior citizens showed up at the back of the line. Counter lady asked the first senior citizen who came to move to the front followed by the second senior citizen.
    // Line is maximum of 5 people.
    // Expected Result: 
    // Defect(s) Found: None
    public void TestPriorityQueue_EqualPriority()
    {
        var James = new Customer("RC-1", 2);
        var Ren = new Customer("RC-2", 2);
        var Joy = new Customer("RC-3", 2);
        var Gian = new Customer("RC-4", 2);
        var Amy = new Customer("SC-1", 0); // Equal Priority, but she came at the back of the line first
        var Efren = new Customer("SC-2", 0); // Equal priority, but he only followed Amy at teh back of the line, so he goes second prio.


        Customer[] expectedResult = [Amy, Efren, James, Ren, Joy, Gian];

        var pq = new PriorityQueue();


        pq.Enqueue(James, James.Priority);
        pq.Enqueue(Ren, Ren.Priority);
        pq.Enqueue(Joy, Joy.Priority);
        pq.Enqueue(Gian, Gian.Priority);
        pq.Enqueue(Amy, Amy.Priority);
        pq.Enqueue(Efren, Efren.Priority);



        for (int i = 0; i < pq.Length; i++)
        {
            Customer customer = pq.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, customer.Value);
        }
    }

    [TestMethod]
    // Empty

    // Scenario: Try to get the next customer when the queue is already empty
    // Expected Result: This will throw an exception error
    // Defect(s) Found: 
    // Defect 1: The error message being tested must match the exception/error message in order to pass validation.

    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();
        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}