namespace Tjuv_Och_Polis_Group_Project;

class Police : Person
{
    public Police(string name, string description, int startX, int startY) : base(name, description, startX, startY)
    {
        Character = 'P';
    }
}