
Console.WriteLine("Welcome to ToDoLy");
Console.WriteLine("You have X tasks todo and Y tasks are done!");

Console.WriteLine("Pick an option:");
Console.Write("(");
Console.ForegroundColor = ConsoleColor.Magenta;
Console.Write("1");
Console.ResetColor();
Console.WriteLine(") Show Task List (by date or project)");
Console.Write("(");
Console.ForegroundColor = ConsoleColor.Magenta;
Console.Write("2");
Console.ResetColor();
Console.WriteLine(") Add New Task");
Console.Write("(");
Console.ForegroundColor = ConsoleColor.Magenta;
Console.Write("3");
Console.ResetColor();
Console.WriteLine(") Edit Task (update, mark as done, remove)");
Console.Write("(");
Console.ForegroundColor = ConsoleColor.Magenta;
Console.Write("4");
Console.ResetColor();
Console.WriteLine(") Save and Quit");

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
        Console.WriteLine("Pick an option:");
        Console.Write("(");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("1");
        Console.ResetColor();
        Console.WriteLine(") Update Task");
        Console.Write("(");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("2");
        Console.ResetColor();
        Console.WriteLine(") Mark Task as Done");
        Console.Write("(");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("3");
        Console.ResetColor();
        Console.WriteLine(") Remove Task");
        int suboption = Convert.ToInt32(Console.ReadLine());
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


class Task
{
    public Task(string taskTitle, DateTime taskDueDate, bool taskStatus, string taskProject)
    {
        TaskTitle = taskTitle;
        TaskDueDate = taskDueDate;
        TaskStatus = taskStatus;
        TaskProject = taskProject;
    }

    public string TaskTitle { get; set; }
    public DateTime TaskDueDate { get; set; }
    public bool TaskStatus { get; set; }
    public string TaskProject { get; set; }
}
