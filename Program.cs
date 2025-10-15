namespace Tjuv_Och_Polis_Group_Project;

class Program
{
    static void Main(string[] args)
    {
        #region City variables
        int cityRows = 15;
        int cityCols = 25;
        char[,] cityGrid = new char[cityRows, cityCols];
        #endregion

        #region Prison variables
        int prisonRows = 10;
        int prisonCols = 10;
        char[,] prisonGrid = new char[prisonRows, prisonCols];
        #endregion

        #region Other variables
        char border = '.';
        ConsoleColor color = ConsoleColor.White;
        #endregion

        

        City city = new City(cityRows, cityCols, cityGrid, border, color);
        Prison prison = new Prison(prisonRows, prisonCols, prisonGrid, border, color);

        int posX = -1;
        int posY = -1;
        Citizen citizen = new Citizen("Jonas", "Medborgare", 10,10, 'M');

        

        city.GenerateLayout();
        prison.GenerateLayout();

        //cityGrid[posX, posY] = citizen.Character;


        bool inJail = false;
        bool debugList = false;
        Console.CursorVisible = false;
        while (true)
        {
            Console.SetCursorPosition(0, 0);
            // Innan start sätter vi grundboarders på respektive PLACE

            // Sätt respektive PLACE till tomma celler

            // **Kalla på respektive PERSONS MOVE metoder

            // Sätt dit alla PERSONS på sina POSITIONS

            // Printar ut PLACES

            //((Place)city).PrintLayout();
                        
            
            if (!debugList)
            {
                //city.PrintLayout(posX, posY, citizen, inJail);
                city.PrintLayout(citizen);
                //prison.PrintLayout();
                //prison.PrintLayout(posX, posY, citizen, inJail);
                
                //Console.WriteLine($"Player position: [{posX,2},{posY,2}]");
                //Console.WriteLine($"{citizen.Name} Position: [{citizen.X,2},{citizen.Y,2}]");
            }
            else
            {
                //Console.WriteLine($"Player position: [{posX,2},{posY,2}]");
                Console.WriteLine($"{citizen.Name} Position: [{citizen.X,2},{citizen.Y,2}]");
            }



            #region TESTING: Random inputs med thread.sleep
            //switch (Random.Shared.Next(0, 9))
            //{
            //    case 0: posX--; if (posX == 0) posX = cityRows - 2; break;
            //    case 1: posX++; if (posX == cityRows - 1) posX = 1; break;
            //    case 2: posY--; if (posY == 0) posY = cityCols - 2; break;
            //    case 3: posY++; if (posY == cityCols - 1) posY = 1; break;
            //    case 4: posX--; if (posX == 0) posX = cityRows - 2; posY--; if (posY == 0) posY = cityCols - 2; break;
            //    case 5: posX--; if (posX == 0) posX = cityRows - 2; posY++; if (posY == cityCols - 1) posY = 1; break;
            //    case 6: posX++; if (posX == cityRows - 1) posX = 1; posY--; if (posY == 0) posY = cityCols - 2; break;
            //    case 7: posX++; if (posX == cityRows - 1) posX = 1; posY++; if (posY == cityCols - 1) posY = 1; break;
            //    case 8: Console.WriteLine("Didnt move"); break;
            //}
            //int test = 500;
            //Thread.Sleep(test);
            #endregion
            #region TESTING : WASD movement for debug
            // ConsoleKeyInfo key = Console.ReadKey(true);
            //
            // switch (key.Key)
            // {
            //     case ConsoleKey.W: posX--; if (posX == 0) posX = cityRows - 2; break; // !inJail på alla ifsatser
            //     case ConsoleKey.S: posX++; if (posX == cityRows - 1) posX = 1; break;
            //     case ConsoleKey.A: posY--; if (posY == 0) posY = cityCols - 2; break;
            //     case ConsoleKey.D: posY++; if (posY == cityCols - 1) posY = 1; break;
            //
            //     case ConsoleKey.J: inJail = !inJail; Console.Clear(); break;
            //     case ConsoleKey.L: debugList = !debugList; Console.Clear(); break;
            //     case ConsoleKey.R:
            //         {
            //             switch (Random.Shared.Next(0, 9))
            //             {
            //                 case 0: posX--; if (posX == 0) posX = cityRows - 2; break;
            //                 case 1: posX++; if (posX == cityRows - 1) posX = 1; break;
            //                 case 2: posY--; if (posY == 0) posY = cityCols - 2; break;
            //                 case 3: posY++; if (posY == cityCols - 1) posY = 1; break;
            //                 case 4: posX--; if (posX == 0) posX = cityRows - 2; posY--; if (posY == 0) posY = cityCols - 2; break;
            //                 case 5: posX--; if (posX == 0) posX = cityRows - 2; posY++; if (posY == cityCols - 1) posY = 1; break;
            //                 case 6: posX++; if (posX == cityRows - 1) posX = 1; posY--; if (posY == 0) posY = cityCols - 2; break;
            //                 case 7: posX++; if (posX == cityRows - 1) posX = 1; posY++; if (posY == cityCols - 1) posY = 1; break;
            //                 case 8: Console.WriteLine("Didnt move"); break;
            //             }
            //             break;
            //         }
            // }
            #endregion
            
            citizen.Move(city);
            Console.ReadKey(true);
            
        }
    }
}