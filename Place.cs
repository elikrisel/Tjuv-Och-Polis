namespace Tjuv_Och_Polis_Group_Project;

public class Place
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    public string[,] MapGrid { get; set; }

    public string Border { get; set; } //HA FLER SENARE
    
    public ConsoleColor Color { get; set; }

    //DELAY
    //public int DelayTimer { get; set; }

    public Place(int rows, int columns, string[,] mapGrid, string border, ConsoleColor color)
    {
        Rows = rows;
        Columns = columns;
        MapGrid = mapGrid;
        Border = border;
        Color = color;
    }
    //
    // public virtual void GenerateLayout()
    // {
    //     
    // }
    

    
}