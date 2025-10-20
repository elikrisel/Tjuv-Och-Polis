using System.Diagnostics.Tracing;

namespace Tjuv_Och_Polis_Group_Project;

public class PersonManager
{
    
    
    public static void HandleInteractions(List<Person> persons, Prison prison)
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
                    if (person1 is Citizen && person2 is Thief)
                    {
                        // Console.WriteLine("person1 medborgare stöter på person2 tjuv");
                        if (person1.InventorySystem.Count > 0)
                        {
                            person2.InventorySystem.Add(person1.InventorySystem[0]);
                            person1.InventorySystem.RemoveAt(0);    
                        }  
                        
                    }
                    else if (person1 is Thief && person2 is Citizen)
                    {
                        // Console.WriteLine("person1 tjuv stöter på person2 medborgare");
                        if (person2.InventorySystem.Count > 0)
                        {
                            person1.InventorySystem.Add(person2.InventorySystem[0]);
                            person2.InventorySystem.RemoveAt(0);
                        }
                        
                    }
                    else if(person1 is Police && person2 is Thief)
                    {
                        if (person2.InventorySystem.Count > 0)
                        {
                            person1.InventorySystem.AddRange(person2.InventorySystem);
                            person2.InventorySystem.Clear();
                            ((Thief)person2).MoveToJail(person2,prison);
                            
                        }
                    }
                    else if (person1 is Thief && person2 is Police)
                    {
                        if (person1.InventorySystem.Count > 0)
                        {
                            person2.InventorySystem.AddRange(person1.InventorySystem);
                            person1.InventorySystem.Clear();
                            ((Thief)person1).MoveToJail(person1,prison);
                        }
                    }
                    
                }
                // else
                // {
                //     Console.ForegroundColor = ConsoleColor.Red;
                //     Console.WriteLine($"{persons[i].Description} {persons[i].Name} and {persons[j].Description} {persons[j].Name} are NOT at same place");
                // }
            }
            
            Console.ResetColor();
        }
        



    }
}