namespace Tjuv_Och_Polis_Group_Project;
public class PersonManager
{
    public static char CitizenCharacter()
    {
        return 'C';
    }
    public static char ThiefCharacter()
    {
        return 'T';
    }
    public static char PoliceCharacter()
    {
        return 'P';
    }
    public static ConsoleColor CitizenColor()
    {
        return ConsoleColor.Green;
    }
    public static ConsoleColor ThiefColor()
    {
        return ConsoleColor.Red;
    }
    public static ConsoleColor PoliceColor()
    {
        return ConsoleColor.Blue;
    }
    public static void HandleInteractions(List<Person> persons, Prison prison, NewsFeed newsFeed)
    {
        for (int i = 0; i < persons.Count - 1; i++)
        {
            Person person1 = persons[i];
            for (int j = i + 1; j < persons.Count; j++)
            {
                Person person2 = persons[j];
                if (person1.X == person2.X && person1.Y == person2.Y && !person1.InPrison && !person2.InPrison)
                {
                    if (person1 is Citizen && person2 is Thief)
                    {
                        ThiefStealsRandomInventoryFromCitizen(person1, person2, newsFeed);
                        
                    }
                    else if(person1 is Thief && person2 is Citizen)
                    {
                        ThiefStealsRandomInventoryFromCitizen(person2, person1, newsFeed);
                    }
                    HandleThiefAndPoliceInteraction(person1, person2, prison, newsFeed);
                    HandleCitizenAndPoliceInteraction(person1, person2, newsFeed);
                }
            }
        }
    }
    private static void HandleCitizenAndPoliceInteraction(Person person1, Person person2, NewsFeed newsFeed)
    {
        if (person1 is Citizen && person2 is Police)
        {
            newsFeed.NewsList.Add($"{person1.Description} {person1.Name} hälsar på {person2.Description} {person2.Name}");
        }
        else if (person1 is Police && person2 is Citizen)
        {
            newsFeed.NewsList.Add($"{person2.Description} {person2.Name} hälsar på {person1.Description} {person1.Name}");
        }
    }
    private static void HandleThiefAndPoliceInteraction(Person person1, Person person2, Prison prison,
        NewsFeed newsFeed)
    {
        if (person1 is Police && person2 is Thief && person2.InventorySystem.Count > 0)
        {
            person1.InventorySystem.AddRange(person2.InventorySystem);
            person2.InventorySystem.Clear();
            ((Thief)person2).MoveToJail(prison);
            newsFeed.NewsList.Add($"{person1.Description} {person1.Name} sätter {person2.Description} {person2.Name} i fängelset");
        }
        else if (person1 is Thief && person2 is Police && person1.InventorySystem.Count > 0)
        {
            person2.InventorySystem.AddRange(person1.InventorySystem);
            person1.InventorySystem.Clear();
            ((Thief)person1).MoveToJail(prison);
            newsFeed.NewsList.Add($"{person2.Description} {person2.Name} sätter {person1.Description} {person1.Name} i fängelset");
        }
    }
    private static void ThiefStealsRandomInventoryFromCitizen(Person citizen, Person thief, NewsFeed newsFeed)
    {
        if (citizen.InventorySystem.Count > 0)
        {
            int randomIndex = Random.Shared.Next(0,citizen.InventorySystem.Count);
            thief.InventorySystem.Add(citizen.InventorySystem[randomIndex]);
            newsFeed.NewsList.Add($"{thief.Description} {thief.Name} tar {citizen.InventorySystem[0]} från {citizen.Description} {citizen.Name}");
            citizen.InventorySystem.RemoveAt(randomIndex);
            
        }
        
        
        // if (citizen is Citizen && thief is Thief && citizen.InventorySystem.Count > 0)
        // {
        // }
        // else if (citizen is Thief && thief is Citizen && thief.InventorySystem.Count > 0)
        // {
        //     citizen.InventorySystem.Add(thief.InventorySystem[randomIndex]);
        //     newsFeed.NewsList.Add($"{citizen.Description} {citizen.Name} tar {thief.InventorySystem[0]} från {thief.Description} {thief.Name}");
        //     thief.InventorySystem.RemoveAt(randomIndex);
        // }
    }
    // private static void HandleCitizenAndThiefInteraction(Person person1, Person person2, NewsFeed newsFeed)
    // {
    //     int index = Random.Shared.Next(0,person1.InventorySystem.Count);
    //     if (person1 is Citizen && person2 is Thief && person1.InventorySystem.Count > 0)
    //     {
    //         person2.InventorySystem.Add(person1.InventorySystem[index]);
    //         newsFeed.NewsList.Add($"{person2.Description} {person2.Name} tar {person1.InventorySystem[0]} från {person1.Description} {person1.Name}");
    //         person1.InventorySystem.RemoveAt(index);
    //     }
    //     else if (person1 is Thief && person2 is Citizen && person2.InventorySystem.Count > 0)
    //     {
    //         person1.InventorySystem.Add(person2.InventorySystem[index]);
    //         newsFeed.NewsList.Add($"{person1.Description} {person1.Name} tar {person2.InventorySystem[0]} från {person2.Description} {person2.Name}");
    //         person2.InventorySystem.RemoveAt(index);
    //     }
    // }
    public static void MoveEachPerson(List<Person> persons, City city, Prison prison)
    {
        foreach (Person person in persons)
        {
            if (!person.InPrison)
            {
                person.MovementInCity(city);
            }
            else
            {
                person.MovementInPrison(prison);
            }
        }
    }
}