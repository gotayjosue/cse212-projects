using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Adding a new item using the Enqueue function
    // Expected Result:Josue 
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Josue", 5);
        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Josue", result);
    }

    [TestMethod]
    // Scenario: Removing the item with the highest priority
    // Expected Result: Isabella
    // Defect(s) Found: The for loop's upper value was wrong. It was changed to make sure it iterates through the whole queue
    // to evaluate all the values inside it and decide which value have the highest priority
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Andrew", 2);
        priorityQueue.Enqueue("Isabella", 5);
        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Isabella", result);
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: More than one elements with the same priority will be added to queue to prove if the program removes the first one.
    // Expected Result: Patricio
    // Defect(s) Found: The condition at the end of the for loop in the Dequeue method was overwritting the first highest priority value found
    // for the next one with the same priority.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Andrew", 2);
        priorityQueue.Enqueue("Patricio", 5);
        priorityQueue.Enqueue("Isabella", 5);
        priorityQueue.Enqueue("Tony", 5);
        priorityQueue.Enqueue("Lucas", 4);
        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Patricio", result);
    }

    [TestMethod]
    // Scenario: Checking if the program throws error when trying to remove values from an empty queue.
    // Expected Result: The queue is empty.
    // Defect(s) Found: 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
        
        
    }
}