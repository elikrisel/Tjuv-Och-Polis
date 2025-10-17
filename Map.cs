namespace Tjuv_Och_Polis_Group_Project;

public class Map
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    public char[,] MapGrid { get; set; }

    public char Border { get; set; } //HA FLER SENARE

    public ConsoleColor Color { get; set; }

    public char EmptySpace { get; set; }
    //DELAY
    //public int DelayTimer { get; set; }

    public Map(int rows, int columns, char[,] mapGrid)
    {
        Rows = rows;
        Columns = columns;
        MapGrid = mapGrid;
        Border = '.';
        Color = ConsoleColor.White;
        EmptySpace = ' ';
    }
    


    public void GenerateLayout()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (row == 0 || row == Rows - 1 || col == 0 || col == Columns - 1)
                {
                    MapGrid[row, col] = Border;
                }
                else
                {
                    MapGrid[row, col] = EmptySpace;
                }
            }
        }
    }

    public virtual void SetLayout(List<Person> persons)
    {
        foreach (Person person in persons)
        {
            if (!person.InPrison)
            {
                MapGrid[person.X, person.Y] = person.Character;
            }
        }
    }
    
    
    public virtual void ClearLayout(List<Person> persons)
    {
        foreach (Person person in persons)
        {
            if (!person.InPrison)
            {
                MapGrid[person.X, person.Y] = EmptySpace;
            }
        }
    }
    
    public virtual void PrintLayout(List<Person> persons)
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (MapGrid[row, col] == Border)
                {
                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = Color;
                }
                // else
                // {
                //     foreach (Person person in persons)
                //     {
                //         if (person.X == row && person.Y == col && !person.InPrison)
                //         {
                //             MapGrid[row, col] = person.Character;
                //             Console.ForegroundColor = person.Color;
                //
                //         }
                //
                //
                //     }
                //
                // }
                Console.Write($"{MapGrid[row, col]} ");
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
    
}