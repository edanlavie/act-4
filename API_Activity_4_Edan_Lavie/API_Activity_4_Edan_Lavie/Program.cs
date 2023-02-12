// Edan Lavie

// Interface for Jukebox Class
interface MyInterface
{
    double AddMoneyToPlay(double Money);
    int Passcode(int passcode);
    string Review(string review);
}


class Jukebox : MyInterface
{
    // Money
    private double money = 0.0;
    public double Money
    {
        get{ return money; }
        set{ money = value; }
    }

    // Add Money method
    // Calls OnLightUp event
    public double AddMoneyToPlay(double Money)
    {
        if (Money >= 0.25)
        {
            Console.WriteLine("WOO!");
            Console.WriteLine("You fed me money!");
            OnLightUp();
            Console.WriteLine("Let's Play:");
            return 1; 
        }
        else
            return 0;
    }

    // Delagate
    public delegate void LightUpEventHander(object source, EventArgs args);

    //Event
    public event LightUpEventHander LightUp;

    // OnLightUp method
    public virtual void OnLightUp()
    {

        if (LightUp != null)
        {
            Console.WriteLine("Light it up!");
            LightUp(this, null);
        }
        //LightUp(this, null);
    }

    // Song 1 by Fabric Bear
    private string fabric_bear = "Waste My Time - Fabric Bear";
    public string FabricBear
    {
        get { return fabric_bear; }
    }

    // Song 2 by The Vanities
    private string the_vanities = "Oh Me Oh My - The Vanities";
    public string TheVanities
    {
        get { return the_vanities; }
    }

    // Passcode method
    // checks passcode
    public int passcode = 1234;
    public int Passcode(int passcode)
    {
        Console.WriteLine("Enter Passcode:");

        if (passcode == 1234)
        {
            Console.WriteLine(passcode);
            Console.WriteLine("I'm Open!");
            return 1;
        }
        else
            return 0;
    }

    // Review method
    public string Review(string review)
    {
        Console.WriteLine("Enter Review:");
        Console.WriteLine(review);
        Console.WriteLine("Review Submitted!");

        return review;
    }
}

// Songs method
class Songs<Tunes>
{
    private Tunes[] arr = new Tunes[2];
    public Tunes this[int i]
    {
        get { return arr[i]; }
        set { arr[i] = value; }
    }

}

// Turn On method
class TurnOn
{
    public void Lights(object source, EventArgs eventArgs)
    {
        Console.WriteLine("*FLICKER* *FLICKER*");
    }
}

// Main 
class Program
{
    static void Main(string[] args)
    {
        var jukebox = new Jukebox();
        var turnOn = new TurnOn();

        // Turn On and Add Money 
        jukebox.LightUp += turnOn.Lights;
        jukebox.AddMoneyToPlay(1);

        // Play Songs
        var songs = new Songs<string>();
        songs[0] = jukebox.FabricBear;
        songs[1] = jukebox.TheVanities;

        Console.WriteLine(songs[0]);
        Console.WriteLine(songs[1]);

        // Enter Passcode and Review
        jukebox.Passcode(1234);
        jukebox.Review("this song stinks");



    }
}

// See https://aka.ms/new-console-template for more information

