namespace Tjuv_Och_Polis_Group_Project;
public class Prison : Grid
{
    public Prison()
    {
        Rows = 9;
        Columns = 20;
        Matrix = new char[Rows, Columns];
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
    public override void PrintLayout()
    {
        PrintBarbedWire("top");

        for (int row = 0; row < Rows; row++)
        {
            PrintBarbedWire("left");

            for (int col = 0; col < Columns; col++)
            {
                SetColorBasedOnCharacterAndPrint(row,col);
            }

            PrintBarbedWire("right");
            Console.WriteLine();
        }

        PrintBarbedWire("bottom");
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

    protected override void SetColorBasedOnCharacterAndPrint(int row, int col)
    {
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

        //ADDING EXTRA EMPTY SPACE WITHIN THE BORDER
        if (col != 0 && col != Columns - 1)
        {
            Console.Write(' ');
        }
        Console.ResetColor();
    }
    private void PrintBarbedWire(string position)
    {
        if (position == "top" || position == "bottom")
        {
            Console.WriteLine(new string('x', Columns * 2));
        }
        else if (position == "left" || position == "right")
        {
            Console.Write('x');
        }
    }

}