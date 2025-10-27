namespace Tjuv_Och_Polis_Group_Project;
class Program
{ 
    static void Main(string[] args)
    {
        #region Variables

        int cityRows = 14;
        int cityCols = 40;
        char[,] cityGrid = new char[cityRows, cityCols];
        
        int prisonRows = 4;
        int prisonCols = 30;  
        char[,] prisonGrid = new char[prisonRows, prisonCols];

        int newsFeedRows = 11; // MUST BE ABOVE 6 TO SHOW STATISTICS AND 1 ROW FOR NEWSFEED - INSPECT FURTHER 
        //newsFeedRows = newsFeedRows < 11 ? 11 : newsFeedRows; //ALWAYS MAKE SURE NEWSFEED ROWS  IS 11 OR ABOVE
        int newsFeedCols = 40; 
        char[,] newsFeedGrid = new char[newsFeedRows, newsFeedCols];
        
        bool debugList = false;
        Console.CursorVisible = false;
        
        //TODO: SÄTT VÄRDERNA ENLIGT DOKUMENTET
        int numberOfCitizens = 10;
        int numberOfThieves = 10;
        int numberOfPoliceOfficers = 10; 

        #endregion
        City city = new City(cityRows, cityCols, cityGrid);
        Prison prison = new Prison(prisonRows, prisonCols, prisonGrid);
        NewsFeed newsFeed = new(newsFeedRows, newsFeedCols, newsFeedGrid);
        List<Person> persons = Helpers.PersonList(cityRows, cityCols, numberOfCitizens, numberOfThieves, numberOfPoliceOfficers);
        
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