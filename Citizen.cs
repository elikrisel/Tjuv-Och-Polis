namespace Tjuv_Och_Polis_Group_Project;

public class Citizen : Person
{
    public Citizen(string name, int startX, int startY) : base(name, startX, startY)
    {
        Character = PersonProperties.CitizenCharacter();
        Description = PersonProperties.CitizenDescription();
        Color = PersonProperties.CitizenColor();
        InventorySystem = PersonProperties.CitizenStartingInventory();
    }

}