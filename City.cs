namespace Tjuv_Och_Polis_Group_Project;

class City : Place
{
    public City(int rows, int columns, char[,] mapGrid, char border, ConsoleColor color) : base(rows, columns, mapGrid, border, color)
    {
    }

    public void GenerateLayout()
    {
        
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (row == 0 || row == Rows - 1 || col == 0 || col == Columns - 1)
                {
                    //Console.Write(" ");
                    MapGrid[row, col] = Border;
                }
                else
                {
                    MapGrid[row, col] = ' ';
                }
            }

            //Console.WriteLine();
        }

    }

    public void PrintLayout()
    {
        
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (MapGrid[row, col] == Border)
                {
                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = Color;
                    Console.Write($" {MapGrid[row, col]} ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($" {MapGrid[row, col]} ");
                }
            }

            Console.WriteLine();
        }
    }
}
    