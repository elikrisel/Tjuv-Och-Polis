namespace Tjuv_Och_Polis_Group_Project;

public abstract class Person
{
    public string Name { get; set; } 
    public string Description { get; set; } 
    public int X { get; set; }
    public int Y { get; set; }
    public bool InPrison { get; set; }
    public List<string> InventorySystem { get; set; }
    public char Character { get; set; }
    public ConsoleColor Color { get; set; }
    public int Direction { get; set; }
    public int StepsUntilNewDirection { get; set; }
    public int StepsTaken { get; set; }

    public Person(string name,int startX,int startY)
    {
        Name = name;
        X = startX;
        Y = startY;
        InventorySystem = new List<string>();
        Direction = SetNewRandomDirection();
        StepsUntilNewDirection = SetNewStepsUntilNewDirection();
    }
    
    public void MoveInGrid(City city, Prison prison)
    {
        Grid personLocation = !InPrison ? city : prison;
        
        switch (Direction)
        {
            case 0: X--; if (X == 0) X = personLocation.Rows - 2; break;
            case 1: X++; if (X == personLocation.Rows - 1) X = 1; break;
            case 2: Y--; if (Y == 0) Y = personLocation.Columns - 2; break;
            case 3: Y++; if (Y == personLocation.Columns - 1) Y = 1; break;
            case 4: X--; if (X == 0) X = personLocation.Rows - 2; Y--; if (Y == 0) Y = personLocation.Columns - 2; break;
            case 5: X--; if (X == 0) X = personLocation.Rows - 2; Y++; if (Y == personLocation.Columns - 1) Y = 1; break;
            case 6: X++; if (X == personLocation.Rows - 1) X = 1; Y--; if (Y == 0) Y = personLocation.Columns - 2; break;
            case 7: X++; if (X == personLocation.Rows - 1) X = 1; Y++; if (Y == personLocation.Columns - 1) Y = 1; break;
            case 8: break; //Stand still
        }
        CountStepsAndCheckIfStepsCounterIsMet();
    }
    private int SetNewRandomDirection()
    {
        return Random.Shared.Next(0, 9);
    }
    private int SetNewStepsUntilNewDirection()
    {
        return Random.Shared.Next(10, 31);
    }
    private void CountStepsAndCheckIfStepsCounterIsMet()
    {
        StepsTaken++;
        if (StepsTaken == StepsUntilNewDirection)
        {
            Direction = SetNewRandomDirection();
            StepsUntilNewDirection = SetNewStepsUntilNewDirection(); 
            StepsTaken = 0;
        }
    }
    
}