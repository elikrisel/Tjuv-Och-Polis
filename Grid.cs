namespace Tjuv_Och_Polis_Group_Project;
public abstract class Grid
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    public char[,] Matrix { get; set; }
    public char Border { get; set; } 
    public ConsoleColor Color { get; set; }
    public char EmptySpace { get; set; }
    public Grid()
    {
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
                SetColorBasedOnCharacterAndPrint(row, col);
            }
            Console.WriteLine();
        }
    }
    protected virtual void SetColorBasedOnCharacterAndPrint(int row, int col)
    {
        if (Matrix[row, col] == Border)
        {
            Console.BackgroundColor = Color;
            Console.ForegroundColor = Color;
        }
        else if (Matrix[row, col] == PersonProperties.CitizenCharacter())
        {
            Console.ForegroundColor = PersonProperties.CitizenColor();
        }
        else if (Matrix[row, col] == PersonProperties.ThiefCharacter())
        {
            Console.ForegroundColor = PersonProperties.ThiefColor();
        }
        else if (Matrix[row, col] == PersonProperties.PoliceCharacter())
        {
            Console.ForegroundColor = PersonProperties.PoliceColor(); 
        }
        Console.Write($"{Matrix[row, col]} ");
        Console.ResetColor();
    }
}