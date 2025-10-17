using System.Reflection.PortableExecutable;

namespace Tjuv_Och_Polis_Group_Project;

public class Person
{
    public string Name { get; set; } //NAMN

    public string Description { get; set; } //BESKRIVNING

    public int[,] CoordinationSystem { get; set; }

    public int X { get; set; }
    public int Y { get; set; }
    
    //public bool InAction { get; set; } // OM DE ÄR PÅ SAMMA PLATS?

    public List<string> InventorySystem { get; set; }

    public char Character { get; set; }
    
    public ConsoleColor Color { get; set; }

    public Person(string name, string description,int startX,int startY)
    {
        Name = name;
        Description = description;
        CoordinationSystem = new int[startX, startY];
        X = startX;
        Y = startY;
        InventorySystem = new List<string>();
    }
    
    public static string GenerateNamesOfPersons()
    {
        List<string> names = new List<string>()
        {
            "Adam", "Agnes", "Alexander", "Alva", "Amanda",
            "Anders", "Anna", "Anton", "Arvid", "Astrid",
            "Axel", "Beatrice", "Benjamin", "Berit", "Bertil",
            "Carl", "Caroline", "Charlotte", "Christoffer", "Clara",
            "Daniel", "David", "Dennis", "Ebba", "Edvin",
            "Elin", "Elisabeth", "Elliot", "Elsa", "Emil",
            "Emma", "Erik", "Eva", "Filip", "Frida",
            "Gabriel", "Gustav", "Hanna", "Henrik", "Hugo",
            "Ida", "Isak", "Isabella", "Jakob", "Johanna",
            "Johan", "Josefin", "Julia", "Karin", "Karl"
        };

        int randomIndex = Random.Shared.Next(0, names.Count);

        return names[randomIndex];
        
    }

    //OPTIONAL:
    //public virtual char GetCharacter() => '?';
    
    //OPTIONAL:
    //public virtual ConsoleColor GetColor => ConsoleColor.Gray;

    public void Move(City city)
    {
        switch (Random.Shared.Next(0, 8))
        {
            case 0: X--; if (X == 0) X = city.Rows - 2; break;
            case 1: X++; if (X == city.Rows - 1) X = 1; break;
            case 2: Y--; if (Y == 0) Y = city.Columns - 2; break;
            case 3: Y++; if (Y == city.Columns - 1) Y = 1; break;
            case 4: X--; if (X == 0) X = city.Rows - 2; Y--; if (Y == 0) Y = city.Columns - 2; break;
            case 5: X--; if (X == 0) X = city.Rows - 2; Y++; if (Y == city.Columns - 1) Y = 1; break;
            case 6: X++; if (X == city.Rows - 1) X = 1; Y--; if (Y == 0) Y = city.Columns - 2; break;
            case 7: X++; if (X == city.Rows - 1) X = 1; Y++; if (Y == city.Columns - 1) Y = 1; break;
            
        }

    }
    
    
    
}