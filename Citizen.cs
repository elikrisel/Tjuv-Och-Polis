namespace Tjuv_Och_Polis_Group_Project;

class Citizen : Person
{
    
    public Citizen(string name, int startX, int startY) : base(name, startX, startY)
    {
        Character = 'C';
        Description = "Medborgare";
        Color = ConsoleColor.Green;
        InventorySystem = new List<string>
        {
            "Nycklar", "Mobiltelefon", "Pengar", "Klocka"
        };
    }


    
    
}