namespace Tjuv_Och_Polis_Group_Project;

public class Helpers
{
    public static string BreakPoint(int number) => new('-', number);

    public static void SetPrintAndClearLayouts(City city, Prison prison, List<Person> persons)
    {
        city.SetLayout(persons);
        city.PrintLayout(persons);
        city.ClearLayout(persons);
        prison.SetLayout(persons);
        prison.PrintLayout(persons);
        prison.ClearLayout(persons);
    }

    public static void PrintNewsFeedList(NewsFeed newsFeed)
    {
        
        
    }
    
    public static void PrintDebugList(List<Person> persons)
    {
        Console.WriteLine(BreakPoint(45));
        foreach (Person person in persons)
        {
            string descriptionName = $"{person.Description} {person.Name}";
            Console.Write($"{descriptionName.PadRight(25)} {(person.InPrison ? "Prison" : "City").PadRight(10, ' ')}  [{person.X,2},{person.Y,2}]");
            foreach (string inventory in person.InventorySystem)
            {
                        
                Console.Write(" " + inventory + "");
                        
            }

            Console.WriteLine();
            

        }
        Console.WriteLine(BreakPoint(45));
    }
    
    public static List<Person> PersonList(int cityRows, int cityCols, int numberOfCitizens, int numberOfThieves,int numberOfOfficers)
    {
        List<Person> persons = new List<Person>();
        
        for (int number = 0; number < numberOfCitizens; number++)
        {
            int positionX = Random.Shared.Next(1, cityRows - 1);
            int positionY = Random.Shared.Next(1, cityCols - 1);
            persons.Add(new Citizen(Person.GenerateNamesOfPersons(), positionX, positionY));
        }

        for (int number = 0; number < numberOfThieves; number++)
        {
            int positionX = Random.Shared.Next(1, cityRows - 1);
            int positionY = Random.Shared.Next(1, cityCols - 1);
            persons.Add(new Thief(Person.GenerateNamesOfPersons(), positionX, positionY));
        }

        for (int number = 0; number < numberOfOfficers; number++)
        {
            int positionX = Random.Shared.Next(1, cityRows - 1);
            int positionY = Random.Shared.Next(1, cityCols - 1);
            persons.Add(new Police(Person.GenerateNamesOfPersons(), positionX, positionY));
        }
        
        return persons;
        
        
    }
    
    
}