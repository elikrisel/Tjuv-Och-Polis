using System.Collections;

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

    public void Statistics(List<Person> persons, int numberOfCitizens, int numberOfThieves, int numberOfOfficers,
        City city, Prison prison)
    {
        int thievesInPrison = 0;
        foreach (Person person in persons)
        {
            if (person.InPrison)
            {
                thievesInPrison++;
            }
        }
        string[] lines =
        {
            $"Medborgare i Staden: {numberOfCitizens}",
            $"Tjuvar i Staden: {numberOfThieves - thievesInPrison}. Tjuvar i Fängelse: {thievesInPrison}",
            $"Poliser i Staden: {numberOfOfficers}",
            Helpers.PrintXNumberOfLines(Columns * 2 - 4)
        };
        Console.SetCursorPosition(2, city.Rows + prison.Rows + 1);
        for (int i = 0; i < lines.Length; i++)
        {
            Console.SetCursorPosition(2, Console.CursorTop);
            Console.WriteLine(lines[i]);
        }
        
    }
    public void PrintNewsList(City city, Prison prison)
    {
        int count = 0;
        for (int i = NewsList.Count - 1; i > 0; i--)
        {
            Console.SetCursorPosition(2, Console.CursorTop);
            Console.WriteLine($"{i}: {NewsList[i]}");
            count++;
            if (count == 5)
            {
                break;
            }
        }
    }
}