namespace Tjuv_Och_Polis_Group_Project;

class Program
{
    static void Main(string[] args)
    {
        #region City variables

        int cityRows = 15;
        int cityCols = 15;
        char[,] cityGrid = new char[cityRows, cityCols];

        #endregion

        #region Prison variables

        int prisonRows = 5;
        int prisonCols = 5;
        char[,] prisonGrid = new char[prisonRows, prisonCols];

        #endregion

        #region Other variables

        bool debugList = false;
        Console.CursorVisible = false;

        #endregion

        #region NumberOfPersonsInCity

        //TODO: SÄTT VÄRDERNA ENLIGT DOKUMENTET
        int numberOfCitizens = 10;
        int numberOfThieves = 10;
        int numberOfOfficers = 2;

        #endregion


        City city = new City(cityRows, cityCols, cityGrid);
        Prison prison = new Prison(prisonRows, prisonCols, prisonGrid);

        List<Person> persons =
            Helpers.PersonList(cityRows, cityCols, numberOfCitizens, numberOfThieves, numberOfOfficers);
        for (int i = 0; i < 5; i++)
        {
            persons.Add(new Citizen("test", 5, 5));
        }

        city.GenerateLayout();
        prison.GenerateLayout();

        while (true)
        {
            Console.SetCursorPosition(0, 0);

            if (!debugList)
            {
                Helpers.SetPrintAndClearLayouts(city, prison, persons);
            }
            else
            {
                Helpers.PrintDebugList(persons);
            }

            Console.WriteLine("Press any key to move players");
            PersonManager.HandleInteractions(persons, prison);
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
                            ((Thief)person).MoveToJail(person, prison);
                        }
                        else if (person is Thief && person.InPrison)
                        {
                            ((Thief)person).MoveToCity(person, city);
                        }
                    }

                    break;
                case ConsoleKey.L:
                    debugList = !debugList;
                    Console.Clear();
                    break;
            }

            #endregion


            Console.Clear();
            //Console.ReadKey(true);
        }
    }
}