namespace Tjuv_Och_Polis_Group_Project;

class Thief : Person
{
    public bool InJail { get; set; }
    public Thief(string name, int startX, int startY) : base(name, startX, startY)
    {
        Description = "Tjuv";
        Character = 'T';
        Color = ConsoleColor.Red;
    }

    
}