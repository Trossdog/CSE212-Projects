using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Adds 2 values with different priorities and dequeues them in order of priority.
    // Expected Result: High priority removed first
    // Defect(s) Found: When dequeuing, it looked at all the values except the last one.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        var expected_value = "high priority";

        priorityQueue.Enqueue("low priority", 1);
        priorityQueue.Enqueue("high priority", 5);
        var dequeuedValue = priorityQueue.Dequeue();

        Assert.AreEqual(dequeuedValue, expected_value);
    }

    [TestMethod]
    // Scenario: More than one value with the same priority, dequeues them in order of addition to the queue.
    // Expected Result: The High priority values are dequeued in order of addition
    // Defect(s) Found: the equals sign messed it up when comparing the index to the highest priority index
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        var expected_value1 = "high priority #1";
        var expected_value2 = "high priority #2";
        
        priorityQueue.Enqueue("high priority #1", 5);
        priorityQueue.Enqueue("low priority", 1);
        priorityQueue.Enqueue("high priority #2", 5);
        var dequeuedValue = priorityQueue.Dequeue();
        var dequeuedValue2 = priorityQueue.Dequeue();

        Assert.AreEqual(dequeuedValue, expected_value1);
        Assert.AreEqual(dequeuedValue2, expected_value2);
    }

    [TestMethod]
    // Scenario: Ensure to get an error message when dequeueing from an empty queue.
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: No errors found :)
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());

        Assert.AreEqual(exception.Message, "The queue is empty.");
    }
}