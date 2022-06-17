using FinalProject;
class Porgram
{
    public static void Main(string[] args)
    {
        // Turns text color into selcted color
        // Console.ForegroundColor = ConsoleColor.Green;

        Console.ReadKey();
        Random rnd = new Random();
        var d = new string[rnd.Next(10,30),rnd.Next(30,110)];
        Maps.CreateFrame(d);
        Maps.PrintMap(d);
        Maps.PlayerMovement(1,1,d);
    }
}

// Fluff Ideas:
// Your Character uses EchoLocation to get to know his enviorment
// This is why everything on his way represented in a similiar way 
// because he catagorize is as (foe, reward);

//The Project needs few things but i need to begin on stuff
//1.Create 1st Level for testing
//1.1.Walls need to be created in two catagories 1.unbreakable 2.breakable
//2.Create a logic for player avatar
//3.Create Movment For The Player(Needs to refresh the level)
//4.Every level / map need an entery and exit represented by (E and Ex)
//5.Create Traps
//5.1 Traps are invisible until steped on
//6.Create Enemies
//6.1. must have hp and damge (doi)
//6.2.
//6.3.
//7.Create Chest
//7.1.chest will reward the player with the following (inc damage, inc hp, heal)
//8.Print game data in bottom of map
//8.1. Contains: currentlvl, damage of player and enemy, treasure map interaction, traps.
//9.Battle between player and enemy if the two are 1 tile apart(both will inflict and get damage)
//Advance Ft.
//1. Console Colors.
//2. Progression.
//3. healing poition
//4. Hud
//5. Options Menu
//6. Save and Load system
//7. (Keep an eye for anything extra you can only gain knowledge)
