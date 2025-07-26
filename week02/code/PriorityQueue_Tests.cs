using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities ("A":2, "B":5, "C":3). 
    // The highest priority item ("B") should be dequeued first.
    // Expected Result: The Dequeue method should return "B".
    // Defect(s) Found: 
    // 1. The item is not actually removed from the queue after being dequeued. Calling Dequeue() again would still return "B".
    // 2. The loop for finding the highest priority item skips the last element in the queue. If the highest priority item were last, it would not be found.
    public void TestPriorityQueue_BasicDequeue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items where two have the same highest priority ("B":5, "C":5).
    // According to FIFO rules for ties, the one added first ("B") should be dequeued.
    // Expected Result: The first Dequeue() should return "B". The second should return "C".
    // Defect(s) Found: 
    // 1. The logic for handling ties is incorrect. The code uses '>=' which finds the LAST item with the highest priority, violating the FIFO rule. It should use '>'.
    // 2. The item is not removed from the queue, so subsequent calls to Dequeue() would be incorrect.
    public void TestPriorityQueue_TieBreaking()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);
        priorityQueue.Enqueue("D", 1);

        var result1 = priorityQueue.Dequeue();
        Assert.AreEqual("B", result1, "First item with highest priority should be dequeued.");

        var result2 = priorityQueue.Dequeue();
        Assert.AreEqual("C", result2, "Second item with highest priority should be dequeued next.");
    }

    [TestMethod]
    // Scenario: Call Dequeue() on an empty queue.
    // Expected Result: An InvalidOperationException should be thrown with the message "The queue is empty."
    // Defect(s) Found: No defect found. The original code correctly throws the specified exception when the queue is empty.
    public void TestPriorityQueue_EmptyQueueException()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("An exception should have been thrown for an empty queue.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught.");
        }
    }

    [TestMethod]
    // Scenario: Enqueue multiple items and dequeue all of them to ensure they are removed in the correct priority order.
    // The sequence is ("A":2), ("B":5), ("C":3), ("D":5).
    // Expected Result: The dequeued order should be "B", "D", "C", "A".
    // Defect(s) Found: All three defects combine to fail this test. 
    // 1. The tie-breaking logic is wrong (finds D before B).
    // 2. The item is not removed, so the queue size never decreases, leading to an infinite loop if we were to check queue.Length.
    // 3. The loop boundary is wrong.
    public void TestPriorityQueue_DequeueAll()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 5);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: The item with the highest priority is the last one in the list.
    // This tests the loop boundary condition specifically.
    // Expected Result: The Dequeue method should return "C".
    // Defect(s) Found: The loop in Dequeue() has an off-by-one error (`index < _queue.Count - 1`),
    // which causes it to completely ignore the last element in the queue. Therefore, it fails to find "C".
    public void TestPriorityQueue_HighestPriorityIsLast()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("C", result);
    }
}