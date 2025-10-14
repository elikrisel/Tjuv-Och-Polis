namespace Tjuv_Och_Polis_Group_Project;

class Program
{
    static void Main(string[] args)
    {

        int rows = 10;
        int cols = 10;
        string[,] mapGrid = new string[rows, cols];
        char border = '=';
        City city = new City(rows, cols, mapGrid, border);
        
        city.Layout();

        
    }
}