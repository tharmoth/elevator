namespace Tests;

public class Tests
{
    [Test]
    public void ExampleTest()
    {
        CollectionAssert.AreEqual(new List<int> {420, 12, 9, 2, 1, 32}, Elevator.ElevatorSorted(12, [2, 9, 1, 32]));
    }
    
    [Test]
    public void TestCloseToBottom()
    {
        CollectionAssert.AreEqual(new List<int> {120, 1, 0, 11}, Elevator.ElevatorSorted(1, [0, 11]));
    }

    [Test]
    public void TestCloseToTop()
    {
        CollectionAssert.AreEqual(new List<int> {110, 10, 11, 1}, Elevator.ElevatorSorted(10, [1, 11]));
    }
    
    [Test]
    public void TestAboveAll()
    {
        CollectionAssert.AreEqual(new List<int> {90, 10, 5, 4, 3, 2, 1}, Elevator.ElevatorSorted(10, [1, 2, 3, 4, 5]));
    }
    
    [Test]
    public void TestBelowAll()
    {
        CollectionAssert.AreEqual(new List<int> {90, 1, 2, 3, 4, 10}, Elevator.ElevatorSorted(1, [2, 3, 4, 10]));
    }
    
    [Test]
    public void NegativeFloorsFirst()
    {
        CollectionAssert.AreEqual(new List<int> {400, 0, -10, 20}, Elevator.ElevatorSorted(0, [20, -10]));
    }
    
    [Test]
    public void NegativeFloorsSecond()
    {
        CollectionAssert.AreEqual(new List<int> {400, 0, 10, -20}, Elevator.ElevatorSorted(0, [10, -20]));
    }

    [Test]
    public void NoFloors()
    {
        CollectionAssert.AreEqual(new List<int> {0, 0}, Elevator.ElevatorSorted(0, []));
    }
    
    [Test]
    public void OneFloor()
    {
        CollectionAssert.AreEqual(new List<int> {100, 0, 10}, Elevator.ElevatorSorted(0, [10]));
    }

    [Test]
    public void UnsortedExample()
    {
        CollectionAssert.AreEqual(new List<int> {560, 12, 2, 9, 1, 32}, Elevator.ElevatorUnsorted(12, [2, 9, 1, 32]));
    }
}