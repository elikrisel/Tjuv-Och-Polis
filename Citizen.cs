namespace Tjuv_Och_Polis_Group_Project;

public class Citizen : Person
{
    public Citizen(string name, int startX, int startY) : base(name, startX, startY)
    {
        Character = PersonManager.CitizenCharacter();
        Description = PersonManager.CitizenDescription();
        Color = PersonManager.CitizenColor();
        InventorySystem = PersonManager.CitizenStartingInventory();
    }
}