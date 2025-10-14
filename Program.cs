namespace Tjuv_Och_Polis_Group_Project;

class Program
{
    static void Main(string[] args)
    {
        int cityRows = 25;
        int cityCols = 25;
        int prisonRows = 10;
        int prisonCols = 10;
        char[,] cityGrid = new char[cityRows, cityCols];
        char[,] prisonGrid = new char[prisonRows, prisonCols];
        char border = '.';
        ConsoleColor color = ConsoleColor.White;

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