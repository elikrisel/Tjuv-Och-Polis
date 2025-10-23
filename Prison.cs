namespace Tjuv_Och_Polis_Group_Project;
public class Prison : Grid
{
    public Prison(int rows, int columns, char[,] matrix) : base(rows, columns, matrix)
    {
    }
    public override void PrintLayout(List<Person> persons)
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
                else if (Matrix[row, col] == PersonManager.ThiefCharacter())
                {
                    Console.ForegroundColor = PersonManager.ThiefColor();
                }
                Console.Write($"{Matrix[row, col]} ");
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