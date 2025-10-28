namespace Tjuv_Och_Polis_Group_Project;
class Police : Person
{
    public Police(string name, int startX, int startY) : base(name, startX, startY)
    { 
        Description = PersonManager.PoliceDescription();
        Character = PersonManager.PoliceCharacter();
        Color = PersonManager.PoliceColor();
    }
}