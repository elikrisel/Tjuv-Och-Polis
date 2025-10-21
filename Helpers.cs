namespace Tjuv_Och_Polis_Group_Project;

public class Helpers
{
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