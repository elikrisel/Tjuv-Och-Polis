namespace Tjuv_Och_Polis_Group_Project;
public class Thief : Person
{
    public int TimerInPrison { get; set; }
    public Thief(string name, int startX, int startY) : base(name, startX, startY)
    {
        Description = PersonProperties.ThiefDescription();
        Character = PersonProperties.ThiefCharacter();
        Color = PersonProperties.ThiefColor();
    }
    public void MoveToJail(Prison prison)
    { 
        InPrison = true;
        SetPositionBasedOnPersonLocation(prison);
    }
    public void MoveToCity(City city)
    {
        InPrison = false;
        SetPositionBasedOnPersonLocation(city);
    } 
    private void SetPositionBasedOnPersonLocation(Grid personLocation)
    {
        X = Random.Shared.Next(1, personLocation.Rows - 1);
        Y = Random.Shared.Next(1, personLocation.Columns - 1);
    }
}