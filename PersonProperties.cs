namespace Tjuv_Och_Polis_Group_Project;

public class PersonProperties
{
    public static List<string> CitizenStartingInventory()
    {
        return new List<string>
        {
            "Nycklar", "Mobil", "Pengar", "Klocka"
        };
    }
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