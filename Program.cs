namespace Tjuv_Och_Polis_Group_Project;

class Program
{
    static void Main(string[] args)
    {

        int rows = 10;
        int cols = 10;
        int[,] mapGrid = new int[rows, cols];

        for(int row  = 0; row < rows; row++)
        {
            for(int col = 0; col < cols; col++)
            {
                if(row == 0 || row == rows -1 || col == 0 || col == cols -1) 
                {
                    Console.Write("=");
                }
                else
                {
                    Console.Write(" ");
                }
                
            }
            Console.WriteLine();
        } 

        
    }
}