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
                    
                    if (person1 is Police && person2 is Thief)
                    {
                        IfThiefHasInventoryPoliceConfiscateAllItemsAndPutTheThiefInPrison(person1, person2, prison, newsFeed);
                    }
                    else if (person1 is Thief && person2 is Police)
                    {
                        IfThiefHasInventoryPoliceConfiscateAllItemsAndPutTheThiefInPrison(person2, person1, prison, newsFeed);
                    }
                    
                    if (person1 is Citizen && person2 is Police)
                    {
                        CitizenGreetsThePolice(person1, person2, newsFeed);
                    }
                    else if (person1 is Police && person2 is Citizen)
                    {
                        CitizenGreetsThePolice(person2, person1, newsFeed);
                    }
                }
            }
        }
    }
    private static void CitizenGreetsThePolice(Person citizen, Person police, NewsFeed newsFeed)
    {
        newsFeed.NewsList.Add($"{citizen.Description} {citizen.Name} hälsar på {police.Description} {police.Name}");
    }
    private static void IfThiefHasInventoryPoliceConfiscateAllItemsAndPutTheThiefInPrison(Person police, Person thief, Prison prison,
        NewsFeed newsFeed)
    {
        if (thief.InventorySystem.Count > 0)
        {
            police.InventorySystem.AddRange(thief.InventorySystem);
            thief.InventorySystem.Clear();
            ((Thief)thief).MoveToJail(prison);
            newsFeed.NewsList.Add($"{police.Description} {police.Name} sätter {thief.Description} {thief.Name} i fängelset");
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
    }
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