namespace Tjuv_Och_Polis_Group_Project;
public class NewsFeed : Grid
{ 
    public List<string> NewsList { get; set; }       
    public NewsFeed()
    {
        NewsList = new List<string>();
        Rows = 11;
        Columns = 40;
        Matrix = new char[Rows, Columns];

    }
    public override void PrintLayout()
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
    public void Statistics(List<Person> persons, int numberOfCitizens, int numberOfThieves, int numberOfPoliceOfficers, City city, Prison  prison)
    { 
        int thievesInPrison = CountThievesInPrison(persons);
        string[] lines =
        {
            $"Medborgare i Staden: {numberOfCitizens}",
            $"Tjuvar i Staden: {numberOfThieves - thievesInPrison}. Tjuvar i Fängelse: {thievesInPrison}",
            $"Poliser i Staden: {numberOfPoliceOfficers}",
            Helpers.PrintXNumberOfLines(Columns * 2 - 4)
        };
        PrintStatisticsWithinTheNewsFeedBorder(city, prison, lines);
    }
    public void PrintNewsList()
    {
        int viableSpaceInNewsFeed = Rows - 6; 
        for (int i = NewsList.Count - 1; i > 0 && viableSpaceInNewsFeed > 0; i--)
        {
            Console.SetCursorPosition(2, Console.CursorTop);
            Console.WriteLine($"{i}: {NewsList[i]}");
            viableSpaceInNewsFeed--;
        }
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
    private void PrintStatisticsWithinTheNewsFeedBorder(City city, Prison prison, string[] lines)
    {
        Console.SetCursorPosition(2, city.Rows + prison.Rows + 1);
        for (int i = 0; i < lines.Length; i++)
        {
            Console.SetCursorPosition(2, Console.CursorTop);
            Console.WriteLine(lines[i]);
        }
    }
}