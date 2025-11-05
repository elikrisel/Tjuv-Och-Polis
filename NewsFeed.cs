namespace Tjuv_Och_Polis_Group_Project;
public class NewsFeed : Grid
{
    internal static bool interactionOccured;

    public List<string> NewsList { get; set; }       
    public NewsFeed()
    {
        NewsList = new List<string>();
        Rows = 11;
        Columns = 40;
        Matrix = new char[Rows, Columns];

    }
    
    // Main printing methods
    public void PrintLayout(Prison prison, City city)
    {
        Console.SetCursorPosition((prison.Columns * 2), city.Rows);

        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (Matrix[row, col] == Border)
                {
                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = Color;
                }

                Console.SetCursorPosition((prison.Columns * 2) + (col * 2), Console.CursorTop);
                Console.Write($"{Matrix[row, col]} ");
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
    public void PrintNewsList(Prison prison)
    {
        WriteEachNewsFeedLineWithinNewsFeedBorder(prison);

        if (interactionOccured)
        {
            Thread.Sleep(1000);
        }
    }
    public void PrintStatistics(List<Person> persons, int numberOfCitizens, int numberOfThieves, int numberOfPoliceOfficers, City city, Prison prison)
    { 
        int thievesInPrison = CountThievesInPrison(persons);
        string[] statistics = Statistics(persons, numberOfCitizens, numberOfThieves, numberOfPoliceOfficers);

        WriteEachStatisticsLineWithinNewsFeedBorder(city, prison, statistics);
    }


    // Writing each line of text at a specific location
    private void WriteEachNewsFeedLineWithinNewsFeedBorder(Prison prison)
    {
        int viableSpaceInNewsFeed = Rows - 6;

        Console.SetCursorPosition((prison.Columns * 2) + 2, Console.CursorTop);

        for (int i = NewsList.Count - 1; i > 0 && viableSpaceInNewsFeed > 0; i--)
        {
            Console.SetCursorPosition((prison.Columns * 2) + 2, Console.CursorTop);
            Console.WriteLine($"{i}: {NewsList[i]}");
            viableSpaceInNewsFeed--;
        }
    }
    private void WriteEachStatisticsLineWithinNewsFeedBorder(City city, Prison prison, string[] statistics)
    {
        Console.SetCursorPosition((prison.Columns * 2), city.Rows + 1);

        for (int i = 0; i < statistics.Length; i++)
        {
            Console.SetCursorPosition((prison.Columns * 2) + 2, Console.CursorTop);
            Console.WriteLine(statistics[i]);
        }
    }
    

    // Returns statistics list and thieves in prison
    private string[] Statistics(List<Person> persons, int numberOfCitizens, int numberOfThieves, int numberOfPoliceOfficers)
    {
        int thievesInPrison = CountThievesInPrison(persons);

        string[] statistics =
        {
            $"Medborgare i Staden: {numberOfCitizens}",
            $"Tjuvar i Staden: {numberOfThieves - thievesInPrison}. Tjuvar i Fängelse: {thievesInPrison}",
            $"Poliser i Staden: {numberOfPoliceOfficers}",
            Helpers.PrintXNumberOfLines(Columns * 2 - 4)
        };

        return statistics;
    }
    private int CountThievesInPrison(List<Person> persons)
    {
        int thievesInPrison = 0;

        foreach (Person person in persons)
        {
            if (person.InPrison)
            {
                thievesInPrison++;
            }
        }

        return thievesInPrison;
    }

}