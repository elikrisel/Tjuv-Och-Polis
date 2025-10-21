namespace Tjuv_Och_Polis_Group_Project;

class Citizen : Person
{
    
    public Citizen(string name, int startX, int startY) : base(name, startX, startY)
    {
        Character = PersonManager.CitizenCharacter();
        Description = "Medborgare";
        Color = PersonManager.CitizenColor();
        InventorySystem = new List<string>
        {
            "Nycklar", "Mobiltelefon", "Pengar", "Klocka"
        };
    }


    
    
}