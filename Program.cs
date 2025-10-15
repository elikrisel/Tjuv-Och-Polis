namespace Tjuv_Och_Polis_Group_Project;

class Program
{
    static void Main(string[] args)
    {
        #region City variables
        int cityRows = 15;
        int cityCols = 15;
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

        int posX = 1;
        int posY = 1;
        Citizen citizen = new Citizen("Jonas", "Medborgare", new int[posX, posY], 'M');



        city.GenerateLayout();
        prison.GenerateLayout();

         //cityGrid[posX, posY] = citizen.Character;



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
            city.PrintLayout(posX, posY, citizen);
            prison.PrintLayout();








            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.W: posX--; if (posX == 0) posX = cityRows - 2 ; break;
                case ConsoleKey.S: posX++; if (posX == cityRows - 1) posX = 1; break;
                //case ConsoleKey.S: Console.WriteLine(citizen.CoordinationSystem[0,0]); break;
                case ConsoleKey.A: posY--; if (posY == 0) posY = cityCols - 2; break;
                case ConsoleKey.D: posY++; if (posY == cityCols - 1) posY = 1; break;
            }

            //Console.ReadKey(true);

        }
    }
}