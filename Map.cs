namespace Tjuv_Och_Polis_Group_Project;

public class Map
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    public char[,] MapGrid { get; set; }

    public char Border { get; set; } //HA FLER SENARE

    public ConsoleColor Color { get; set; }

    public char EmptySpace { get; set; }
    //DELAY
    //public int DelayTimer { get; set; }

    public Map(int rows, int columns, char[,] mapGrid, char border, ConsoleColor color)
    {
        Rows = rows;
        Columns = columns;
        MapGrid = mapGrid;
        Border = border;
        Color = color;
        EmptySpace = ' ';
    }

    public void EmptyLayout()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                MapGrid[row, col] = EmptySpace;
            }
        }
    }

    public void SetBorder()
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
                    MapGrid[row, col] = EmptySpace;
                }
            }
        }
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
                    MapGrid[row, col] = EmptySpace;
                }
            }
        }
    }


    public void PrintLayout(List<Person> persons)
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (MapGrid[row, col] == Border)
                {
                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = Color;
                    Console.Write($"{MapGrid[row, col]} ");
                    Console.ResetColor();
                }
                else
                {
                    foreach (Person person in persons)
                    {
                        if (person.X == row && person.Y == col)
                        {
                            MapGrid[row, col] = person.Character;
                            Console.BackgroundColor = person.Color;
                        }

                        Console.Write($"{MapGrid[row, col]} ");
                        Console.ResetColor();
                    }
                }
            }

            Console.WriteLine();
        }
    }

    // public void PrintLayout()
    // {
    //     for (int row = 0; row < Rows; row++)
    //     {
    //         for (int col = 0; col < Columns; col++)
    //         {
    //             if (MapGrid[row, col] == Border)
    //             {
    //                 Console.BackgroundColor = Color;
    //                 Console.ForegroundColor = Color;
    //                 Console.Write($"{MapGrid[row, col]} ");
    //                 Console.ResetColor();
    //             }
    //             else
    //             {
    //                 Console.Write($"{MapGrid[row, col]} ");
    //             }
    //         }
    //
    //         Console.WriteLine();
    //     }
    // }

    // virtual / override f�r jail
    // public virtual void PrintLayout(int posX, int posY, Person citizen, bool inJail)
    // {
    //     for (int row = 0; row < Rows; row++)
    //     {
    //         for (int col = 0; col < Columns; col++)
    //         {
    //             if (MapGrid[row, col] == Border)
    //             {
    //                 Console.BackgroundColor = Color;
    //                 Console.ForegroundColor = Color;
    //                 Console.Write($"{MapGrid[row, col]} ");
    //                 Console.ResetColor();
    //             }
    //             else if (row == posX && col == posY && !inJail)
    //             {
    //                 //MapGrid[row, col] = citizen.Character;
    //                 Console.BackgroundColor = ConsoleColor.Red;
    //                 Console.ForegroundColor = ConsoleColor.Red;
    //                 Console.Write($"{MapGrid[row, col]} ");
    //                 Console.ResetColor();
    //             }
    //             else
    //             {
    //                 MapGrid[row, col] = EmptySpace;
    //                 Console.Write($"{MapGrid[row, col]} ");
    //             }
    //         }
    //
    //         Console.WriteLine();
    //     }
    // }


    // public virtual void PrintLayout(Person citizen)
    // {
    //     for (int row = 0; row < Rows; row++)
    //     {
    //         for (int col = 0; col < Columns; col++)
    //         {
    //             if (MapGrid[row, col] == Border)
    //             {
    //                 Console.BackgroundColor = Color;
    //                 Console.ForegroundColor = Color;
    //                 Console.Write($"{MapGrid[row, col]} ");
    //                 Console.ResetColor();
    //             }
    //             else if (row == citizen.X && col == citizen.Y) //TODO: Lägga in för att hålla koll om Thief är !InJail
    //             {
    //                 //MapGrid[row, col] = citizen.Character;
    //                 Console.BackgroundColor = ConsoleColor.Red;
    //                 Console.ForegroundColor = ConsoleColor.Red;
    //                 Console.Write($"{MapGrid[row, col]} ");
    //                 Console.ResetColor();
    //             }
    //             else
    //             {
    //                 MapGrid[row, col] = EmptySpace;
    //                 Console.Write($"{MapGrid[row, col]} ");
    //             }
    //         }
    //
    //         Console.WriteLine();
    //     }
    // }
}