namespace Tjuv_Och_Polis_Group_Project;

class City : Place
{
    public City(int rows, int columns, string[,] mapGrid, char border, ConsoleColor color) : base(rows, columns, mapGrid, border, color)
    {
        
    }

    public void Layout()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (row == 0 || row == Rows - 1 || col == 0 || col == Columns - 1)
                {
                    Console.BackgroundColor = Color;
                    Console.Write(" ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(" ");
                }

            }
            Console.WriteLine();
        }
    }
}