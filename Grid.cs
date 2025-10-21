namespace Tjuv_Och_Polis_Group_Project;

public class Grid
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    public char[,] Matrix { get; set; }

    public char Border { get; set; } //HA FLER SENARE

    public ConsoleColor Color { get; set; }

    public char EmptySpace { get; set; }
    //DELAY
    //public int DelayTimer { get; set; }

    public Grid(int rows, int columns, char[,] matrix)
    {
        Rows = rows;
        Columns = columns;
        Matrix = matrix;
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
                    Matrix[row, col] = Border;
                }
                else
                {
                    Matrix[row, col] = EmptySpace;
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
                Matrix[person.X, person.Y] = person.Character;
            }
        }
    }
    
    
    public virtual void ClearLayout(List<Person> persons)
    {
        foreach (Person person in persons)
        {
            if (!person.InPrison)
            {
                Matrix[person.X, person.Y] = EmptySpace;
            }
        }
    }
    
    public virtual void PrintLayout(List<Person> persons)
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (Matrix[row, col] == Border)
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
                //             Console.ForegroundColor = person.Color;
                //         }
                //
                //
                //     }
                //
                // }
                Console.Write($"{Matrix[row, col]} ");
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
    
}