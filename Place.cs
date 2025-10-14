namespace Tjuv_Och_Polis_Group_Project;

public class Place
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    public char[,] MapGrid { get; set; }

    public char Border { get; set; } //HA FLER SENARE
    
    public ConsoleColor Color { get; set; }

    //DELAY
    //public int DelayTimer { get; set; }

    public Place(int rows, int columns, char[,] mapGrid, char border, ConsoleColor color)
    {
        Rows = rows;
        Columns = columns;
        MapGrid = mapGrid;
        Border = border;
        Color = color;
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
                    MapGrid[row, col] = ' ';
                }
            }
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