namespace Tjuv_Och_Polis_Group_Project;

class Program
{
    static void Main(string[] args)
    {
        #region City variables
        int cityRows = 25;
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

        ((Place)city).GenerateLayout();
        ((Place)prison).GenerateLayout();

        while (true)
        {
            Console.SetCursorPosition(0, 0);

            ((Place)city).PrintLayout();
            ((Place)prison).PrintLayout();



            Console.ReadKey(true);
        }
    }
}