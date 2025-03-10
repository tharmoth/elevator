public class Elevator
{
    private const int TimePerFloor = 10;
    
    /*
     * Returns a list of integers of the following form:
     *  -first, the total time to traverse all floors.
     *  -then, the order of the floors visited.
     *
     * Traverses the floors in the order input
     * 
     * i.e. [TotalTime, startingFloor, floor1, floor2, floor3]
     */
    public static List<int> ElevatorUnsorted(int start, List<int> floorsToVisit)
    {
        int time = 0;
        List<int> output = [start];
        foreach (var floor in floorsToVisit)
        {
            time += int.Abs(floor - output.Last()) * 10;
            output.Add(floor);
        }
        output.Insert(0, time);
        return output;
    }
    
    /*
     * Returns a list of integers of the following form:
     *  -first, the total time to traverse all floors.
     *  -then, the order of the floors visited.
     *
     * Traverses the floors in the most efficient order by first going to the nearest of either the top or the bottom
     * and then to the farthest of either the top or bottom.
     *
     * i.e. [TotalTime, startingFloor, floor1, floor2, floor3]
     */
    public static List<int> ElevatorSorted(int start, List<int> floorsToVisit)
    {
        if (floorsToVisit.Count == 0)
        {
            return [0, start];
        }
        
        var sortedFloors = floorsToVisit.Distinct().OrderBy(floor => floor).ToList();
        
        var max = sortedFloors.Last();
        var min = sortedFloors.First();
        
    
        var lowerFloors = sortedFloors.Where(floor => floor < start).ToList();
        var higherFloors = sortedFloors.Where(floor => floor > start).ToList();
    
        List<int> output;
       // All stops below
        if (max < start)
        {
            var time = Math.Abs(start - min) * TimePerFloor;
            output = [ time, start ];
            lowerFloors.Reverse();
            output.AddRange(lowerFloors);
        }
        // All stops above
        else if (min > start)
        {
            var time = Math.Abs(max - start) * TimePerFloor;
            output = [ time, start ];
            output.AddRange(higherFloors);
        }
        // The start is closer to the top
        else if (max - start < start - min)
        {
            var time = Math.Abs(max - start) * TimePerFloor + Math.Abs(max - min) * TimePerFloor;
            output = [ time, start ];
            higherFloors.Reverse();
            output.AddRange(higherFloors);
            output.AddRange(lowerFloors);
        }
        // The start is closer to the bottom
        else
        {
            var time = Math.Abs(start - min) * TimePerFloor + Math.Abs(max - min) * TimePerFloor;
            output = [ time, start ];
            lowerFloors.Reverse();
            output.AddRange(lowerFloors);
            output.AddRange(higherFloors);
        }
        
        return output;
    }
    
    /*
     * Parses the input arguments, calls the appropriate elevator function,
     * and prints the resultant string to the console.
     */
    public static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Elevator start=startingFloor floor=floor1,floor2,floor3...");
            return;
        }

        bool sort = false;
        int? start = null;
        List<int> floorsToVisit = null;
        foreach (var arg in args)
        {
            if (arg.Equals("-s"))
            {
                sort = true;
                continue;
            }

            if (arg.StartsWith("start="))
            {
                if (!int.TryParse(arg.Substring("start=".Length), out var value))
                {
                    Console.WriteLine("Invalid Argument: " + arg);
                    return;
                }

                start = value;
            }
            
            if (arg.StartsWith("floor="))
            {
                floorsToVisit = [];
                var floorStrings = arg.Substring("floor=".Length).Split(",");
                foreach (var floor in floorStrings)
                {
                    if (!int.TryParse(floor, out var value))
                    {
                        Console.WriteLine("Invalid Argument: " + arg);
                        return;
                    }
                    floorsToVisit.Add(value);
                }
            }
        }

        if (start == null)
        {
            Console.WriteLine("Could not find starting value.\nUsage: Elevator start=startingFloor floor=floor1,floor2,floor3...");
            return;
        }
        if (floorsToVisit == null)
        {
            Console.WriteLine("Could not find floor value.\nUsage: Elevator start=startingFloor floor=floor1,floor2,floor3...");
            return;
        }

        PrintList(sort ? ElevatorSorted(start.Value, floorsToVisit) : ElevatorUnsorted(start.Value, floorsToVisit));
    }
    
    private static void PrintList<T>(List<T> input)
    {
        Console.WriteLine(string.Join(", ", input));
    }
}
