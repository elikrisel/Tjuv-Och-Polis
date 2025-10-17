namespace Tjuv_Och_Polis_Group_Project;

class Citizen : Person
{
    
    public Citizen(string name, string description, int startX, int startY) : base(name, description, startX, startY)
    {
        Character = 'C';
         Color = Console.BackgroundColor = ConsoleColor.Green;
        InventorySystem = new List<string>
        {
            "Nycklar", "Mobiltelefon", "Pengar", "Klocka"
        };
    }


    
    
}