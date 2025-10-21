namespace Tjuv_Och_Polis_Group_Project;

public class NewsFeed : Grid
{
    public List<string> NewsList { get; set; }
    
    public NewsFeed(int rows, int columns, char[,] matrix) : base(rows, columns, matrix)
    {
        
        NewsList = new List<string>();
    }

    public void PrintLayout()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (Matrix[row, col] == Border)
                {
                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = Color;
                }
                
                Console.Write($"{Matrix[row, col]} ");
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }

    public void Statistics(List<Person> persons, int numberOfCitizens, int numberOfThieves, int numberOfOfficers,City city, Prison prison)
    {
        int thievesInPrison = 0;
        foreach (Person person in persons)
        {
            if (person.InPrison)
            {
                thievesInPrison++;
            }
        }
        Console.SetCursorPosition(2, city.Rows + prison.Rows + 1);
        Console.WriteLine($"Medborgare i Staden: {numberOfCitizens}");
        Console.SetCursorPosition(2, Console.CursorTop); 
        Console.WriteLine($"Tjuvar i Staden: {numberOfThieves - thievesInPrison }. Tjuvar i Fängelse: {thievesInPrison}");
        Console.SetCursorPosition(2, Console.CursorTop);
        //TODO: Poliser mördade av tjuvar?
        Console.WriteLine($"Poliser i Staden: {numberOfOfficers}");
        Console.SetCursorPosition(2, Console.CursorTop);
        Console.WriteLine(Helpers.BreakPoint(Columns * 2 - 4));

        
        
    } 
    
    public void PrintNewsList(City city, Prison prison)
    {
        //Console.SetCursorPosition(0, city.Rows + prison.Rows + 1);
        //foreach (string news in NewsList)
        //{
        //    //TODO: ÄNDRA VARIABELN SENARE
        //    Console.SetCursorPosition(2,Console.CursorTop);
        //    Console.WriteLine(news);
        //    //SKRIVA UT HUR BRED TEXTEN ÄR SOM SKA SKRIVAS UT
        //}
        int count = 0;
        
        for(int i = NewsList.Count - 1; i > 0; i--)
        {
            Console.SetCursorPosition(2, Console.CursorTop);
            Console.WriteLine($"{i}: {NewsList[i]}");
            //Console.WriteLine($"{NewsList.Count}. {NewsList[i]}");
            count++;
            if(count == 5)
            {
                break;
            }
        }


    }
    
}