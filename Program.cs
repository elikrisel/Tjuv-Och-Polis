namespace Tjuv_Och_Polis_Group_Project;
class Program
{ 
    static void Main(string[] args)
    {
        #region Variables
        
        bool debugList = false;
        Console.CursorVisible = false;
        
        //TODO: SÄTT VÄRDERNA ENLIGT DOKUMENTET
        int numberOfCitizens = 10;
        int numberOfThieves = 10;
        int numberOfPoliceOfficers = 10;

        int numberOfSteps = 0;

        #endregion
        City city = new City();
        Prison prison = new Prison();
        NewsFeed newsFeed = new NewsFeed();
        List<Person> persons = Helpers.PersonList(city, numberOfCitizens, numberOfThieves, numberOfPoliceOfficers);
        
        Helpers.GenerateLayoutsForCityPrisonAndNewsFeed(city,prison,newsFeed);
        
        while (true) 
        {
            Console.SetCursorPosition(0, 0);
            if (!debugList)
            { 
                Helpers.SetPrintAndClearLayoutsForCityAndPrison(city, prison, persons);
                Helpers.PrintStatisticsAndNewsFeed(persons, numberOfCitizens, numberOfThieves, numberOfPoliceOfficers, city, prison, newsFeed);
            }
            else
            {
                Helpers.PrintDebugList(persons);
            }
            PersonManager.HandleInteractions(persons, prison, newsFeed);
            PersonManager.MoveEachPerson(persons, city, prison);
            numberOfSteps++;
            if (numberOfSteps == 20)
            {
                foreach (Person person in persons)
                {
                    person.Direction = Random.Shared.Next(0, 9);
                }
                numberOfSteps = 0;
            }
            
            #region TESTING : Prison och Debug
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.J:
                    foreach (Person person in persons)
                    {
                        if (person is Thief && !person.InPrison)
                        {
                            ((Thief)person).MoveToJail(prison);
                        }
                        else if (person is Thief && person.InPrison)
                        {
                            ((Thief)person).MoveToCity(city);
                        }
                    }
                    break;     
                case ConsoleKey.L:
                    debugList = !debugList;
                    Console.Clear();
                    break;
            }
            #endregion
            foreach(Person person in persons)
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
            // Console.Clear();
        }
    }
}