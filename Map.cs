namespace Tjuv_Och_Polis_Group_Project;

public class Map
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    public char[,] MapGrid { get; set; }

    public char Border { get; set; } //HA FLER SENARE
    
    public ConsoleColor Color { get; set; }

    //DELAY
    //public int DelayTimer { get; set; }

    public Map(int rows, int columns, char[,] mapGrid, char border, ConsoleColor color)
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
                    Console.Write($"{MapGrid[row, col]} ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"{MapGrid[row, col]} ");
                }
            }

            Console.WriteLine();
        }
    }

    // virtual / override f�r jail
    public virtual void PrintLayout(int posX, int posY, Person citizen, bool inJail)
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
                else if (row == posX && col == posY && !inJail)
                {
                    MapGrid[row, col] = citizen.Character;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{MapGrid[row, col]} ");
                    Console.ResetColor();
                }
                else
                {
                    MapGrid[row, col] = ' ';
                    Console.Write($"{MapGrid[row, col]} ");
                }
            }

            Console.WriteLine();
        }
    }
    public virtual void PrintLayout(List<Person> persons)
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
                    for (int i = 0; i < persons.Count; i++)
                    {
                        if (persons[i].X == row && persons[i].Y == col)
                        {
                            MapGrid[row, col] = persons[i].Character;
                        }
                        else if (MapGrid[row, col] != 'M' && MapGrid[row, col] != 'T' && MapGrid[row, col] != 'P') // Fixa PERSON CHAR & COLOR
                        {
                            MapGrid[row, col] = ' ';
                        }
                    }

                    if (MapGrid[row, col] == 'M') // Fixa Citizen CHAR & COLOR
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (MapGrid[row, col] == 'T') // Fixa Thief CHAR & COLOR
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (MapGrid[row, col] == 'P') // Fixa Police CHAR & COLOR
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    
                    Console.Write($"{MapGrid[row, col]} ");
                    Console.ResetColor();
                }
                
               
                // if (MapGrid[row, col] == Border)
                // {
                //     Console.BackgroundColor = Color;
                //     Console.ForegroundColor = Color;
                //     Console.Write($"{MapGrid[row, col]} ");
                //     Console.ResetColor();
                // }
                // else if (row == persons.X && col == persons.Y) //TODO: Lägga in för att hålla koll om Thief är !InJail
                // {
                //     MapGrid[row, col] = persons.Character;
                //     Console.BackgroundColor = ConsoleColor.Red;
                //     Console.ForegroundColor = ConsoleColor.Red;
                //     Console.Write($"{MapGrid[row, col]} ");
                //     Console.ResetColor();
                // }
                
            }

            Console.WriteLine();
        }
    }
    
    

}