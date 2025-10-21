namespace Tjuv_Och_Polis_Group_Project;

public class Prison : Grid
{
    public Prison(int rows, int columns, char[,] mapGrid) : base(rows, columns, mapGrid)
    {
    }
    
    public override void PrintLayout(List<Person> persons)
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (MapGrid[row, col] == Border)
                {
                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = Color;
                    // Console.Write($"{MapGrid[row, col]} ");
                    // Console.ResetColor();
                }
                // else
                // {
                //     foreach (Person person in persons)
                //     {
                //         if (person.X == row && person.Y == col && person.InPrison)
                //         {
                //             MapGrid[row, col] = person.Character;
                //             Console.ForegroundColor = person.Color;
                //
                //         }
                //
                //
                //     }
                    
                //}
                Console.Write($"{MapGrid[row, col]} ");
                Console.ResetColor();
            }
            Console.WriteLine();

        }
    }

    public override void SetLayout(List<Person> persons)
    {
        foreach (Person person in persons)
        {
            if (person.InPrison)
            {
                MapGrid[person.X, person.Y] = person.Character;
            }
        }   
    }
    
    public override void ClearLayout(List<Person> persons)
    {
        foreach (Person person in persons)
        {
            if (person.InPrison)
            {
                MapGrid[person.X, person.Y] = EmptySpace;
            }
        }
    }
    
}