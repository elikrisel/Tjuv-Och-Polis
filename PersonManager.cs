using System.Diagnostics.Tracing;

namespace Tjuv_Och_Polis_Group_Project;

public class PersonManager
{
    public static void HandleInteractions(List<Person> persons)
    {
        // LÄGGA IN LISTA?
        // KOLLA VÄRDERNA MED ROW OCH COLUMN OCH SPARA I LISTAN?


        //JÄMFÖRA BÅDA PERSONERNAS KOORDINATER

        //OM PERSON ÄR PÅ SAMMA KOORDINATVÄRDE SOM DEN ANDRA PERSONEN
        //SÅ SKA JAG PRINTA UT DETTA
        //JÄMFÖRA VÄRDERNA

        for (int i = 0; i < persons.Count - 1; i++)
        {
            Person person1 = persons[i];
            for (int j = i + 1; j < persons.Count; j++)
            {
                Person person2 = persons[j];
                if (person1.X == person2.X && person1.Y == person2.Y)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{persons[i].Description} {persons[i].Name} and {persons[j].Description} {persons[j].Name} are at same place");
                }
                // else
                // {
                //     Console.ForegroundColor = ConsoleColor.Red;
                //     Console.WriteLine($"{persons[i].Description} {persons[i].Name} and {persons[j].Description} {persons[j].Name} are NOT at same place");
                // }
            }

            // Console.ReadKey();
            Console.ResetColor();
        }

        // for (int i = 0; i < persons.Count - 1; i++)
        // {
        //     
        //     if (persons[i].X == persons[persons.Count + 1].X && persons[i].Y == persons[i + 1].Y)
        //     {
        //         Console.ForegroundColor = ConsoleColor.Green;
        //         Console.WriteLine($"{persons[i].Description} {persons[i].Name} and {persons[i + 1].Description} {persons[i + 1].Name} are at same place");
        //     }
        //     else
        //     {
        //         Console.ForegroundColor = ConsoleColor.Red;
        //         Console.WriteLine($"{persons[i].Description} {persons[i].Name} and {persons[i + 1].Description} {persons[i + 1].Name} are NOT at same place");
        //     }
        //     
        // }


        Console.ResetColor();
        Console.ReadKey();
    }
}