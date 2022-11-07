
Console.WriteLine("Welcome to ToDoLy");
Console.WriteLine("You have X tasks todo and Y tasks are done!");

Console.WriteLine("Pick an option:");
Console.WriteLine("(1) Show Task List (by date or project)");
Console.WriteLine("(2) Add New Task");
Console.WriteLine("(3) Edit Task (update, mark as done, remove)");
Console.WriteLine("(4) Save and Quit");

int option = Convert.ToInt32(Console.ReadLine());

switch(option)
{
    case 1:
        Console.WriteLine("Show Task List (by date or project)");
        break;
    case 2:
        Console.WriteLine("Add New Task");
        break;
    case 3:
        Console.WriteLine("Edit Task (update, mark as done, remove)");
        break;
    case 4:
        Console.WriteLine("Save and Quit");
        break;
    default:
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Not a valid option");
        Console.ResetColor();
        break;
}
