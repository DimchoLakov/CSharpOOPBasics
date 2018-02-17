public class StreetExtraordinaire : Cat
{
    private int decibelsOfMeows;

    public int DecibelOfMeows
    {
        get { return this.decibelsOfMeows; }
        set { this.decibelsOfMeows = value; }
    }

    public StreetExtraordinaire()
    {
    }

    public StreetExtraordinaire(string name, string breed, int decibelsOfMeows)
    {
        this.Name = name;
        this.Breed = breed;
        this.decibelsOfMeows = decibelsOfMeows;
    }

    public override string ToString()
    {
        return $"{this.Breed} {this.Name} {this.decibelsOfMeows}";
    }
}