namespace Tjuv_Och_Polis_Group_Project;

public class PersonProperties
{
    // Person inventories
    public static List<string> CitizenStartingInventory()
    {
        return new List<string>
        {
            "Nycklar", "Mobil", "Pengar", "Klocka"
        };
    }
    
    
    // Person descriptions
    public static string CitizenDescription()
    {
        return "Medborgare";
    }
    public static string ThiefDescription()
    {
        return "Tjuv";
    }
    public static string PoliceDescription()
    {
        return "Polis";
    }
    
    
    // Person characters
    public static char CitizenCharacter()
    {
        return 'C';
    }
    public static char ThiefCharacter()
    {
        return 'T';
    }
    public static char PoliceCharacter()
    {
        return 'P';
    }
    
    
    // Person colors
    public static ConsoleColor CitizenColor()
    {
        return ConsoleColor.Green;
    }
    public static ConsoleColor ThiefColor()
    {
        return ConsoleColor.Red;
    }
    public static ConsoleColor PoliceColor()
    {
        return ConsoleColor.Blue;
    }

}