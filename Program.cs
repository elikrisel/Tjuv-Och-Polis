namespace Tjuv_Och_Polis_Group_Project;

class Program
{
    static void Main(string[] args)
    {
        #region City variables

        int cityRows = 15;
        int cityCols = 25;
        char[,] cityGrid = new char[cityRows, cityCols];

        #endregion

        #region Prison variables

        int prisonRows = 10;
        int prisonCols = 10;
        char[,] prisonGrid = new char[prisonRows, prisonCols];

        #endregion

        #region Other variables

        int posX = -1;
        int posY = -1;
        //bool inJail = false;
        bool debugList = false;
        Console.CursorVisible = false;

        #endregion

        #region NumberOfPersonsInCity

        int numberOfCitizens = 12;
        int numberOfThieves = 15;
        int numberOfOfficers = 10;

        #endregion

        City city = new City(cityRows, cityCols, cityGrid);
        Prison prison = new Prison(prisonRows, prisonCols, prisonGrid);


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

        city.GenerateLayout();
        prison.GenerateLayout();

        while (true)
        {
            Console.SetCursorPosition(0, 0);

            if (!debugList)
            {
                city.SetBorder();
                city.PrintLayout(persons);
                prison.SetBorder();
                prison.PrintLayout(persons);
                //city.PrintLayout(posX, posY, citizen, inJail);
                //prison.PrintLayout();
                //prison.PrintLayout(posX, posY, citizen, inJail);
            }
            else
            {
                foreach (Person person in persons)
                {
                    Console.Write($"{person.Name} Position: [{person.X,2},{person.Y,2}]");
                    foreach (string inventory in person.InventorySystem)
                    {
                        Console.Write(inventory + " ");
                    }

                    Console.WriteLine();
                }
            }


            #region TESTING: Random inputs med thread.sleep

            //switch (Random.Shared.Next(0, 9))
            //{
            //    case 0: posX--; if (posX == 0) posX = cityRows - 2; break;
            //    case 1: posX++; if (posX == cityRows - 1) posX = 1; break;
            //    case 2: posY--; if (posY == 0) posY = cityCols - 2; break;
            //    case 3: posY++; if (posY == cityCols - 1) posY = 1; break;
            //    case 4: posX--; if (posX == 0) posX = cityRows - 2; posY--; if (posY == 0) posY = cityCols - 2; break;
            //    case 5: posX--; if (posX == 0) posX = cityRows - 2; posY++; if (posY == cityCols - 1) posY = 1; break;
            //    case 6: posX++; if (posX == cityRows - 1) posX = 1; posY--; if (posY == 0) posY = cityCols - 2; break;
            //    case 7: posX++; if (posX == cityRows - 1) posX = 1; posY++; if (posY == cityCols - 1) posY = 1; break;
            //    case 8: Console.WriteLine("Didnt move"); break;
            //}
            //int test = 500;
            //Thread.Sleep(test);

            #endregion

            #region TESTING : WASD movement for debug

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.W:
                    posX--;
                    if (posX == 0) posX = cityRows - 2;
                    break; // !inJail på alla ifsatser
                case ConsoleKey.S:
                    posX++;
                    if (posX == cityRows - 1) posX = 1;
                    break;
                case ConsoleKey.A:
                    posY--;
                    if (posY == 0) posY = cityCols - 2;
                    break;
                case ConsoleKey.D:
                    posY++;
                    if (posY == cityCols - 1) posY = 1;
                    break;


                case ConsoleKey.J:
                    foreach (Person person in persons)
                    {
                        if (person is Thief && !person.InPrison)
                        {
                            ((Thief)person).MoveToJail(person,prison);
                        }
                        else if(person is Thief && person.InPrison)
                        {
                            ((Thief)person).MoveToCity(person,city);
                        }
                    }

                    break;
                case ConsoleKey.L:
                    debugList = !debugList;
                    Console.Clear();
                    break;
                case ConsoleKey.R:
                {
                    switch (Random.Shared.Next(0, 9))
                    {
                        case 0:
                            posX--;
                            if (posX == 0) posX = cityRows - 2;
                            break;
                        case 1:
                            posX++;
                            if (posX == cityRows - 1) posX = 1;
                            break;
                        case 2:
                            posY--;
                            if (posY == 0) posY = cityCols - 2;
                            break;
                        case 3:
                            posY++;
                            if (posY == cityCols - 1) posY = 1;
                            break;
                        case 4:
                            posX--;
                            if (posX == 0) posX = cityRows - 2;
                            posY--;
                            if (posY == 0) posY = cityCols - 2;
                            break;
                        case 5:
                            posX--;
                            if (posX == 0) posX = cityRows - 2;
                            posY++;
                            if (posY == cityCols - 1) posY = 1;
                            break;
                        case 6:
                            posX++;
                            if (posX == cityRows - 1) posX = 1;
                            posY--;
                            if (posY == 0) posY = cityCols - 2;
                            break;
                        case 7:
                            posX++;
                            if (posX == cityRows - 1) posX = 1;
                            posY++;
                            if (posY == cityCols - 1) posY = 1;
                            break;
                        case 8: Console.WriteLine("Didnt move"); break;
                    }

                    break;
                }
            }

            #endregion

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

            //Console.ReadKey(true);
        }
    }
}