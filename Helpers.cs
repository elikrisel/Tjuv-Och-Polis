namespace Tjuv_Och_Polis_Group_Project;

public class Helpers
{
    public static string BreakPoint(int number)
    {
        return new string('-', number);
    }

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

    public static List<Person> AddCitizensToPersonList(int cityRows, int cityCols, int numberOfCitizens)
    {
        List<Person> citizens = new List<Person>();
        for (int number = 0; number < numberOfCitizens; number++)
        {
            int positionX = Random.Shared.Next(1, cityRows - 1);
            int positionY = Random.Shared.Next(1, cityCols - 1);
            citizens.Add(new Citizen(Person.GenerateNamesOfPersons(), positionX, positionY));
        }
        return citizens;
    }

    public static List<Person> AddThievesToPersonList(int cityRows, int cityCols, int numberOfThieves)
    {
        List<Person> thieves = new List<Person>();
        
        for (int number = 0; number < numberOfThieves; number++)
        {
            int positionX = Random.Shared.Next(1, cityRows - 1);
            int positionY = Random.Shared.Next(1, cityCols - 1);
            thieves.Add(new Thief(Person.GenerateNamesOfPersons(), positionX, positionY));
        }
        return thieves;
    }

    public static List<Person> AddPoliceOfficersToPersonList(int cityRows, int cityCols, int numberOfPoliceOfficers)
    {
        List<Person> policeOfficers = new List<Person>();
        
        for (int number = 0; number < numberOfPoliceOfficers; number++)
        {
            int positionX = Random.Shared.Next(1, cityRows - 1);
            int positionY = Random.Shared.Next(1, cityCols - 1);
            policeOfficers.Add(new Police(Person.GenerateNamesOfPersons(), positionX, positionY));
        }
        return policeOfficers;
    }
    
    public static List<Person> PersonList(int cityRows, int cityCols, int numberOfCitizens, int numberOfThieves,int numberOfPoliceOfficers)
    {
        List<Person> persons = new List<Person>();
        persons.AddRange(AddCitizensToPersonList(cityRows, cityCols, numberOfCitizens));
        persons.AddRange(AddThievesToPersonList(cityRows, cityCols, numberOfThieves));
        persons.AddRange(AddPoliceOfficersToPersonList(cityRows, cityCols, numberOfPoliceOfficers));
        
        return persons;
        
    }
    
    
}