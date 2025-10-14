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


        ((Place)city).GenerateLayout();
        ((Place)prison).GenerateLayout();

         //cityGrid[posX, posY] = citizen.Character;



        Console.CursorVisible = false;
        while (true)
        {
            Console.SetCursorPosition(0, 0);

            //((Place)city).PrintLayout();
            ((Place)city).PrintLayout(posX, posY, citizen);
            ((Place)prison).PrintLayout();


            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.W: posX--; break;
                case ConsoleKey.S: posX++; break;
                //case ConsoleKey.S: Console.WriteLine(citizen.CoordinationSystem[0,0]); break;
                case ConsoleKey.A: posY--; break;
                case ConsoleKey.D: posY++; break;
            }

            //Console.ReadKey(true);

        }
    }
}