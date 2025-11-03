namespace Tjuv_Och_Polis_Group_Project;
public class PersonManager
{
    public static void HandleInteractions(List<Person> persons, Prison prison, NewsFeed newsFeed)
    {
        for (int i = 0; i < persons.Count - 1; i++)
        {
            Person person1 = persons[i];
            for (int j = i + 1; j < persons.Count; j++)
            {
                Person person2 = persons[j];
                if (IfTwoPersonsAreOnTheSameCoordinatesInCity(person1, person2))
                {
                    IfPersonsAreThiefAndCitizen(person1, person2, newsFeed);
                    
                    IfPersonsArePoliceAndThief(person1 , person2, prison, newsFeed);

                    IfPersonsAreCitizenAndPolice(person1 , person2, newsFeed);
                }
            }
        }
    }
    private static void CitizenGreetsThePolice(Person citizen, Person police, NewsFeed newsFeed)
    {
        newsFeed.NewsList.Add($"{citizen.Description} {citizen.Name} hälsar på {police.Description} {police.Name}");
    }
    private static void IfThiefHasInventoryPoliceConfiscateAllItemsAndPutTheThiefInPrison(Person police, Person thief, Prison prison, NewsFeed newsFeed)
    {
        if (thief.InventorySystem.Count > 0)
        {
            ((Thief)thief).TimerInPrison = thief.InventorySystem.Count * 30;
            police.InventorySystem.AddRange(thief.InventorySystem);
            thief.InventorySystem.Clear();
            ((Thief)thief).MoveToJail(prison);
            newsFeed.NewsList.Add($"{police.Description} {police.Name} sätter {thief.Description} {thief.Name} i fängelset");
        }
        else
        {
            newsFeed.NewsList.Add($"{Helpers.GetThiefAdjective()} {thief.Name} hälsar på {police.Description} {police.Name}");
        }
    }
    private static void ThiefStealsRandomInventoryFromCitizen(Person citizen, Person thief, NewsFeed newsFeed)
    {
        if (citizen.InventorySystem.Count > 0)
        {
            int randomIndex = Random.Shared.Next(0,citizen.InventorySystem.Count);
            thief.InventorySystem.Add(citizen.InventorySystem[randomIndex]);
            newsFeed.NewsList.Add($"{thief.Description} {thief.Name} tar {citizen.InventorySystem[randomIndex]} från {citizen.Description} {citizen.Name}");
            citizen.InventorySystem.RemoveAt(randomIndex);
        }
    }
    public static void MoveEachPerson(List<Person> persons, City city, Prison prison)
    {
        foreach (Person person in persons)
        {
            person.MoveInGrid(city,prison);
        }
    }
    private static bool IfTwoPersonsAreOnTheSameCoordinatesInCity(Person person1, Person person2)
    {
        return person1.X == person2.X && person1.Y == person2.Y && !person1.InPrison && !person2.InPrison;
    }
    private static void IfPersonsAreThiefAndCitizen(Person person1, Person person2, NewsFeed newsFeed)
    {
        if (person1 is Citizen && person2 is Thief)
        {
            ThiefStealsRandomInventoryFromCitizen(person1, person2, newsFeed);
        }
        else if (person1 is Thief && person2 is Citizen)
        {
            ThiefStealsRandomInventoryFromCitizen(person2, person1, newsFeed);
        }
    }
    private static void IfPersonsArePoliceAndThief(Person person1, Person person2, Prison prison, NewsFeed newsFeed)
    {
        
        if (person1 is Police && person2 is Thief)
        {
            IfThiefHasInventoryPoliceConfiscateAllItemsAndPutTheThiefInPrison(person1, person2, prison, newsFeed);
        }
        else if (person1 is Thief && person2 is Police)
        {
            IfThiefHasInventoryPoliceConfiscateAllItemsAndPutTheThiefInPrison(person2, person1, prison, newsFeed);
        }
    }
    private static void IfPersonsAreCitizenAndPolice(Person person1, Person person2, NewsFeed newsFeed)
    {
        if (person1 is Citizen && person2 is Police)
        {
            CitizenGreetsThePolice(person1, person2, newsFeed);
        }
        else if (person1 is Police && person2 is Citizen)
        {
            CitizenGreetsThePolice(person2, person1, newsFeed);
        }
    }
    public static void TimerInPrisonCounter(List<Person> persons, City city)
    {
        foreach (Person person in persons)
        {
            if (person is Thief && person.InPrison)
            {
                Thief thief = (Thief)person;
                thief.TimerInPrison--;

                if (thief.TimerInPrison == 0)
                {
                    thief.MoveToCity(city);
                }
            }
        }
    }
}