namespace Tjuv_Och_Polis_Group_Project;
public class Grid
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    public char[,] Matrix { get; set; }
    public char Border { get; set; } 
    public ConsoleColor Color { get; set; }
    public char EmptySpace { get; set; }

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
    public virtual void PrintLayout()
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
                else if (Matrix[row, col] == PersonManager.CitizenCharacter())
                {
                    Console.ForegroundColor = PersonManager.CitizenColor();
                }
                else if (Matrix[row, col] == PersonManager.ThiefCharacter())
                {
                    Console.ForegroundColor = PersonManager.ThiefColor();
                }
                else if (Matrix[row, col] == PersonManager.PoliceCharacter())
                {
                    Console.ForegroundColor = PersonManager.PoliceColor(); 
                }
                Console.Write($"{Matrix[row, col]} ");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
    
}