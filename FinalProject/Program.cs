using FinalProject;
class Program
{
    public static void Main(string[] args)
    {
        Console.CursorVisible = false;

        Menus gameMenu = new Menus();
        gameMenu.MainMenu();
    }
}
