namespace Tjuv_Och_Polis_Group_Project;

class Tjuv : Person
{
    public bool InJail { get; set; }
    public Tjuv(string name, string description, int startX, int startY, bool inJail) : base(name, description, startX, startY)
    {
        Character = 'T';
        InJail = inJail;
    }

    
}