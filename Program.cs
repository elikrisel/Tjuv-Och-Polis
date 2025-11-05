namespace Tjuv_Och_Polis_Group_Project;
class Program
{ 
    static void Main(string[] args)
    {
        #region Variables
        
        bool debugList = false;
        Console.CursorVisible = false;
        
        int numberOfCitizens = 30;
        int numberOfThieves = 20;
        int numberOfPoliceOfficers = 10;
        
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
            PersonManager.TimerInPrisonCounter(persons, city);

            debugList = Helpers.ShowDebug(persons, prison, city, debugList);
            
            Thread.Sleep(300);
            // Console.Clear();
        }
    }
}



