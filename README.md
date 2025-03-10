# Elevator Simulation in C#

This project simulates an elevator system written in C#. It calculates total travel time and visited floors based on inputs.

## Features
- **Unsorted Mode**: Visits floors in provided order.
- **Sorted Mode**: Optimizes route for minimal travel time.

## Assumptions
- Each floor traversal takes **10 seconds**.
- Duplicates are removed automatically.

## Usage

### Compilation
```
dotnet build
```

### Running the Program
In the Elevator\Elevator directory
```
dotnet run -- start=<startingFloor> floor=<floor1,floor2,...> [-s]
```
or with the build
```
elevator.exe start=<startingFloor> floor=<floor1,floor2,...> [-s]
```
### Examples
**Unsorted Mode:**
```
dotnet run -- start=12 floor=2,9,1,32
```
**Output:** `560, 12, 2, 9, 1, 32`

**Sorted Mode:**
```
dotnet run -- start=12 floor=2,9,1,32 -s
```
**Output:** `420, 12, 9, 2, 1, 32`

## License
This project is open-source under the [MIT License](LICENSE).

