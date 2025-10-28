namespace Tjuv_Och_Polis_Group_Project;

public class Helpers
{ 
    public static string PrintXNumberOfLines(int number)
    {
        return new string('-', number);
    }
    public static void SetPrintAndClearLayoutsForCityAndPrison(City city, Prison prison, List<Person> persons)
    {
        city.SetLayout(persons);
        city.PrintLayout();
        city.ClearLayout(persons);
        prison.SetLayout(persons);
        prison.PrintLayout();
        prison.ClearLayout(persons);
    }
    public static void GenerateLayoutsForCityPrisonAndNewsFeed(City city, Prison prison, NewsFeed newsFeed)
    {
        city.GenerateLayout();
        prison.GenerateLayout();
        newsFeed.GenerateLayout();   
    }
    public static void PrintStatisticsAndNewsFeed(List<Person> persons,int numberOfCitizens,int numberOfThieves,int numberOfPoliceOfficers,City city,Prison prison, NewsFeed newsFeed)
    {
        newsFeed.PrintLayout();
        newsFeed.Statistics(persons,numberOfCitizens,numberOfThieves,numberOfPoliceOfficers,city,prison);
        newsFeed.PrintNewsList();   
    }
    public static void PrintDebugList(List<Person> persons)
    {
        Console.Clear();

        Console.WriteLine("Personbeskrivning och namn |   Koordinater | Inventarie");
        Console.WriteLine(PrintXNumberOfLines(44));

        foreach (Person person in persons)
        {
            PrintPersonDescriptionWithPersonsColor(person);

            Console.Write($"{person.Name.PadRight(25 - person.Description.Length)} |");

            PrintLocationAndSetColorRedIfInPrison(person);

            Console.Write($"[{person.X,2},{person.Y,2}] |");

            if (!person.InPrison)
            {
                foreach (string inventory in person.InventorySystem)
                {
                    
                    Console.Write($" {inventory}");
                    
                }
            }
            else
            {
                 
                Console.Write($" Tid i fängelset: {((Thief)person).TimerInPrison}");
            }
            Console.WriteLine();
        }

        Console.WriteLine(PrintXNumberOfLines(44));
    }
    public static List<Person> AddCitizensToPersonList(int cityRows, int cityCols, int numberOfCitizens)
    {
        List<Person> citizens = new List<Person>();
        for (int number = 0; number < numberOfCitizens; number++)
        {
            int positionX = Random.Shared.Next(1, cityRows - 1);
            int positionY = Random.Shared.Next(1, cityCols - 1);
            citizens.Add(new Citizen(NamesOfCitizens(number), positionX, positionY));
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
            thieves.Add(new Thief(NamesOfThieves(number), positionX, positionY));
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
            policeOfficers.Add(new Police(NamesOfPoliceOfficers(number), positionX, positionY));
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
    private static void PrintPersonDescriptionWithPersonsColor(Person person)
    {
        Console.ForegroundColor = person.Color;
        Console.Write($"{person.Description} ");
        Console.ResetColor();
    }
    private static void PrintLocationAndSetColorRedIfInPrison(Person person)
    {
        if (person.InPrison)
        {
            Console.ForegroundColor = person.Color;
            Console.Write("Prison".PadLeft(7));
            Console.ResetColor();
        }
        else
        {
            Console.Write("City".PadLeft(7));
        }
    }
    private static string NamesOfCitizens(int index)
    {
        List<string> names = new List<string>()
        {
            "Tilda", "Rasmus", "Matilda", "Oscar", "Ellen",
            "Simon", "Lina", "Tobias", "Selma", "William",
            "Lovisa", "Noah", "Maja", "Joel", "Felicia",
            "Niklas", "Saga", "Patrik", "Sofia", "Emilia",
            "Oliver", "Malin", "Leo", "Tilde", "Alfred",
            "Pontus", "Lukas", "Vera", "Linnea", "Marcus",
            "Sandra", "Sebastian", "Cornelia", "Erika", "Petra",
            "Kevin", "Molly", "Hugo", "Oskar", "Vilma",
            "Elias", "Amanda", "Jonathan", "Agnes", "Robin",
            "Therese", "Anton", "Stina", "Casper", "Rebecka"
        };
        
        return names[index % names.Count];
    }
    private static string NamesOfThieves(int index)
    {
        List<string> names = new List<string>()
        {
            "Natalie", "Victor", "Frans", "Ingrid", "Lucas",
            "Madeleine", "Nora", "Alexander", "Elvira", "Benjamin",
            "Josef", "Helena", "Michaela", "David", "Aron",
            "Sanna", "Rickard", "Clara", "Henrik", "Joline",
            "Viktoria", "Kasper", "Julia", "Dennis", "Felix",
            "Gabriella", "Adam", "Kim", "Alma", "Isak",
            "Theodor", "Emil", "Olle", "Filippa", "Kristian",
            "Klara", "Hampus", "Tove", "Marcus", "Rebecca",
            "Moa", "Philip", "Carl", "Nils", "Sara",
            "Jakob", "Annie", "Tomas", "Lina", "Greta"
        };
        
        return names[index % names.Count];
    }
    private static string NamesOfPoliceOfficers(int index)
    {
        List<string> names = new List<string>()
        {
            "Per", "Ebba", "Sven", "Linn", "Erica",
            "Ture", "Alice", "Magnus", "Estelle", "Olof",
            "Karin", "Harald", "Freja", "Rolf", "Nathalie",
            "Ulf", "Elina", "Bo", "Miriam", "Göran",
            "Astrid", "Björn", "Carina", "Lovis", "Jonas",
            "Rut", "Algot", "Tanja", "Elise", "Kent",
            "Birgitta", "Viggo", "Knut", "Ronja", "Siv",
            "Jörgen", "Tina", "Egon", "Britta", "Hedda",
            "Stig", "Anita", "Greger", "Åsa", "Wilma",
            "Gösta", "Selina", "Veronica", "Leif", "Torsten"
        };
        
        return names[index % names.Count];
    }
}