namespace Tjuv_Och_Polis_Group_Project;
public class Thief : Person
{ 
    public Thief(string name, int startX, int startY) : base(name, startX, startY)
    {
        Description = PersonManager.ThiefDescription();
        Character = PersonManager.ThiefCharacter();
        Color = PersonManager.ThiefColor();
    }
    public void MoveToJail(Prison prison)
    { 
        InPrison = true;
        X = Random.Shared.Next(1, prison.Rows - 1);
        Y = Random.Shared.Next(1, prison.Columns - 1);
    }
    public void MoveToCity(City city)
    {
        InPrison = false;
        X = Random.Shared.Next(1, city.Rows - 1);
        Y = Random.Shared.Next(1, city.Columns - 1);
    } 
}