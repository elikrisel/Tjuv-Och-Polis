namespace Tjuv_Och_Polis_Group_Project;

public class Prison : Map
{
    public Prison(int rows, int columns, char[,] mapGrid) : base(rows, columns, mapGrid)
    {
    }
    public override void PrintLayout(List<Person> persons)
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
                        if (person.X == row && person.Y == col && person.InPrison)
                        {
                            MapGrid[row, col] = person.Character;
                            Console.ForegroundColor = person.Color;

                        }


                    }
                    Console.Write($"{MapGrid[row, col]} ");
                    Console.ResetColor();
                }
            }

            Console.WriteLine();
        }
    }
    // public override void PrintLayout(int posX, int posY, Person citizen, bool inJail)
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
    //             else if (row == posX && col == posY && inJail) 
    //             {
    //                 //MapGrid[row, col] = citizen.Character;
    //                 Console.BackgroundColor = ConsoleColor.Red;
    //                 Console.ForegroundColor = ConsoleColor.Red;
    //                 Console.Write($"{MapGrid[row, col]} ");
    //                 Console.ResetColor();
    //             }
    //             else
    //             {
    //                 MapGrid[row, col] = ' ';
    //                 Console.Write($"{MapGrid[row, col]} ");
    //             }
    //         }
    //
    //         Console.WriteLine();
    //     }
    // }

}