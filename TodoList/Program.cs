
using System.Text.RegularExpressions;

int option = 0;
bool showMenuAgain = true;
int subOption = 0;
bool showSubMenuAgain = true;

List<Task> tasks = new List<Task>();

// Main Menu
void ShowMainMenu()
{
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

    option = Convert.ToInt32(Console.ReadLine());
}

// Edit Task Menu
void EditTaskMenu()
{
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
    Console.Write("(");
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write("4");
    Console.ResetColor();
    Console.WriteLine(") Back to Main Menu");

    subOption = Convert.ToInt32(Console.ReadLine());
}

//Add New Task
void AddNewTask()
{
    Console.WriteLine("Add New Task");
    Console.WriteLine("Enter a Task:");
    string taskTitle = Console.ReadLine();

    Console.WriteLine("Enter Due Date for the Task (DD/MM/YYYY):");
    string taskDueDate = Console.ReadLine();
    Regex dateFormat = new Regex(@"((([0-2][0-9])|([3][0-1]))\/(([0][1-9])|([1][0-2]))\/([1-2][0,1,9][0-9][0-9]))$");
    if (!dateFormat.IsMatch(taskDueDate))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Wrong Date Format");
        Console.ResetColor();
        AddNewTask();
    }

    bool taskStatus = false;

    Console.WriteLine("Enter Task Project Name:");
    string taskProject = Console.ReadLine();

    tasks.Add(new Task(taskTitle, taskDueDate, taskStatus, taskProject));

    MainMenu();
}

// Edit Tasks Options
void SubMenu()
{
    EditTaskMenu();

    while (showSubMenuAgain)
    {
        switch (subOption)
        {
            case 1:
                Console.WriteLine("Update Task");
                break;

            case 2:
                Console.WriteLine("Mark Task as Done");
                break;

            case 3:
                Console.WriteLine("Remove Task");
                break;

            case 4:
                MainMenu();
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid option");
                Console.ResetColor();
                EditTaskMenu();
                break;
        }
    }
}

// Main Menu Options
void MainMenu()
{
    ShowMainMenu();

    while(showMenuAgain)
    {
        switch (option)
        {
            case 1:
                Console.WriteLine("Show Task List (by date or project)");
                break;

            case 2:
                AddNewTask();
                break;

            case 3:
                SubMenu();
                break;

            case 4:
                Console.WriteLine("Save and Quit");
                Environment.Exit(0);
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid option");
                Console.ResetColor();
                break;
        }

    }
}


// Call the Main Menu the first time
MainMenu();



class Task
{
    public Task(string taskTitle, string taskDueDate, bool taskStatus, string taskProject)
    {
        TaskTitle = taskTitle;
        TaskDueDate = taskDueDate;
        TaskStatus = taskStatus;
        TaskProject = taskProject;
    }

    public string TaskTitle { get; set; }
    public string TaskDueDate { get; set; }
    public bool TaskStatus { get; set; }
    public string TaskProject { get; set; }
}
