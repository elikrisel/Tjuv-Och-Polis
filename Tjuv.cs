namespace Tjuv_Och_Polis_Group_Project;

class Tjuv : Person
{
    public bool InJail { get; set; }
    public Tjuv(string name, int startX, int startY) : base(name, startX, startY)
    {
        Description = "Tjuv";
        Character = 'T';
        InJail = false;
        Color = ConsoleColor.Red;
    }

    
}