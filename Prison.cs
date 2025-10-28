namespace Tjuv_Och_Polis_Group_Project;
public class Prison : Grid
{
    public Prison()
    {
        Rows = 9;
        Columns = 20;
        Matrix = new char[Rows, Columns];
    }
    public override void PrintLayout()
    {
        Console.WriteLine(new string('x', Columns * 2));
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (col == 0)
                {
                    Console.Write('x');
                }
                if (Matrix[row, col] == Border)
                {
                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = Color;
                }
                else if (Matrix[row, col] == PersonProperties.ThiefCharacter())
                {
                    Console.ForegroundColor = PersonProperties.ThiefColor();
                }
                Console.Write($"{Matrix[row, col]}");
                if (col != 0 && col != Columns - 1)
                {
                    Console.Write(' ');
                }
                Console.ResetColor();
                if (col == Columns - 1)
                {
                    Console.Write('x');
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine(new string('x', Columns * 2));
    }
    public override void SetLayout(List<Person> persons)
    {
        foreach (Person person in persons)
        {
            if (person.InPrison)
            {
                Matrix[person.X, person.Y] = person.Character;
            }
        }
    }
    public override void ClearLayout(List<Person> persons)
    {
        foreach (Person person in persons)
        {
            if (person.InPrison)
            {
                Matrix[person.X, person.Y] = EmptySpace;
            }
        }
    }
}