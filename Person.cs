namespace Tjuv_Och_Polis_Group_Project;

public class Person
{
    public string Name { get; set; } 
    public string Description { get; set; } 
    public int[,] CoordinationSystem { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public bool InPrison { get; set; }
    public List<string> InventorySystem { get; set; }
    public char Character { get; set; }
    public ConsoleColor Color { get; set; }

    public Person(string name,int startX,int startY)
    {
        Name = name;
        CoordinationSystem = new int[startX, startY];
        X = startX;
        Y = startY;
        InventorySystem = new List<string>();
    }
    public void MovementInCity(City city)
    {
        switch (Random.Shared.Next(0, 8))
        {
            case 0: X--; if (X == 0) X = city.Rows - 2; break;
            case 1: X++; if (X == city.Rows - 1) X = 1; break;
            case 2: Y--; if (Y == 0) Y = city.Columns - 2; break;
            case 3: Y++; if (Y == city.Columns - 1) Y = 1; break;
            case 4: X--; if (X == 0) X = city.Rows - 2; Y--; if (Y == 0) Y = city.Columns - 2; break;
            case 5: X--; if (X == 0) X = city.Rows - 2; Y++; if (Y == city.Columns - 1) Y = 1; break;
            case 6: X++; if (X == city.Rows - 1) X = 1; Y--; if (Y == 0) Y = city.Columns - 2; break;
            case 7: X++; if (X == city.Rows - 1) X = 1; Y++; if (Y == city.Columns - 1) Y = 1; break;
        }
    }
    //DIFFERENT TYPE OF MOVEMENT IN PRISON IN 4 AXIS - CHECK FURTHER ON MONDAY
    public void MovementInPrison(Prison prison) 
    {
        switch (Random.Shared.Next(0, 8))
        {
            case 0: X--; if (X == 0) X = prison.Rows - 2; break;
            case 1: X++; if (X == prison.Rows - 1) X = 1; break;
            case 2: Y--; if (Y == 0) Y = prison.Columns - 2; break;
            case 3: Y++; if (Y == prison.Columns - 1) Y = 1; break;
            case 4: X--; if (X == 0) X = prison.Rows - 2; Y--; if (Y == 0) Y = prison.Columns - 2; break;
            case 5: X--; if (X == 0) X = prison.Rows - 2; Y++; if (Y == prison.Columns - 1) Y = 1; break;
            case 6: X++; if (X == prison.Rows - 1) X = 1; Y--; if (Y == 0) Y = prison.Columns - 2; break;
            case 7: X++; if (X == prison.Rows - 1) X = 1; Y++; if (Y == prison.Columns - 1) Y = 1; break;
        }
    }
}