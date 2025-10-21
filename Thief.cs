using System.Globalization;

namespace Tjuv_Och_Polis_Group_Project;

public class Thief : Person
{
    
    public Thief(string name, int startX, int startY) : base(name, startX, startY)
    {
        
        Description = "Tjuv";
        Character = 'T';
        Color = PersonManager.ThiefColor();
    }

    public void MoveToJail(Person person, Prison prison)
    {
        InPrison = true;
        person.X = Random.Shared.Next(1, prison.Rows - 1);
        person.Y = Random.Shared.Next(1, prison.Columns - 1);
        
    }

    public void MoveToCity(Person person, City city)
    {
        InPrison = false;
        person.X = Random.Shared.Next(1, city.Rows - 1);
        person.Y = Random.Shared.Next(1, city.Columns - 1);
    } 
    
    
}