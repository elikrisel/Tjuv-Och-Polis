using System.Reflection.PortableExecutable;

namespace Tjuv_Och_Polis_Group_Project;

public class Person
{
    public string Name { get; set; } //NAMN

    public string Description { get; set; } //BESKRIVNING

    public int[,] CoordinationSystem { get; set; }

    //public bool InAction { get; set; } // OM DE ÄR PÅ SAMMA PLATS?

    public List<string> InventorySystem { get; set; }

    public char Character { get; set; }

    public Person(string name, string description, int[,] coordinationSystem, char character)
    {
        Name = name;
        Description = description;
        CoordinationSystem = coordinationSystem;
        Character = character;
    }
    
}