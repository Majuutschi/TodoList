
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TodoList;

TodoDbContext Context = new TodoDbContext();

int option = 0;
bool showMenuAgain = true;
int editOption = 0;
bool showEditMenuAgain = true;
int listOption = 0;
bool showListMenuAgain = true;


List<Task> Tasks = Context.Tasks.ToList();


// Some Todos to the list
Task t1 = new Task("Make lunch", "12/10/2022", Convert.ToDateTime("12/10/2022"), false, "Kitchen");
Context.Tasks.Add(t1);
Task t2 = new Task("Laundry", "12/09/2022", Convert.ToDateTime("12/09/2022"), true, "Laundry");
Context.Tasks.Add(t2);
Task t3 = new Task("Read book", "12/26/2022", Convert.ToDateTime("12/26/2022"), false, "Wellbeing");
Context.Tasks.Add(t3);
Context.SaveChanges();


// Main Menu
void ShowMainMenu()
{
    Console.WriteLine();

    Console.WriteLine("Welcome to ToDoList");
    Console.WriteLine($"You have {Context.Tasks.Count()} tasks todo and {Context.Tasks.Where(x => x.TaskStatus == true).Count()} tasks are done!");

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
    Console.WriteLine();

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

    editOption = Convert.ToInt32(Console.ReadLine());
}

// Task List
void ShowTaskListMenu()
{
    Console.WriteLine();

    Console.WriteLine("Show Task List");
    Console.WriteLine("Pick an option:");
    Console.Write("(");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.Write("1");
    Console.ResetColor();
    Console.WriteLine(") Show List Sorted by Date");
    Console.Write("(");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.Write("2");
    Console.ResetColor();
    Console.WriteLine(") Show List Sorted by Project");
    Console.Write("(");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.Write("3");
    Console.ResetColor();
    Console.WriteLine(") Back to Main Menu");

    listOption = Convert.ToInt32(Console.ReadLine());
}

// Sort List By Date
void ListByDate()
{
    Console.WriteLine("Task".PadRight(15) + "Due Date".PadRight(15) + "Done".PadRight(15) + "Project".PadRight(15));
    Console.WriteLine("----".PadRight(15) + "--------".PadRight(15) + "----".PadRight(15) + "-------".PadRight(15));
    
    List<Task> sortedByDate = Context.Tasks.OrderBy(task => task.TaskDateTime).ToList();

    foreach (Task task in sortedByDate)
    {
        if (task.TaskStatus == true)
        {
            Console.WriteLine(task.TaskTitle.PadRight(15) + task.TaskDueDate.PadRight(15) + "Yes".PadRight(15) + task.TaskProject.PadRight(15));
        }
        else
        {
            Console.WriteLine(task.TaskTitle.PadRight(15) + task.TaskDueDate.PadRight(15) + "No".PadRight(15) + task.TaskProject.PadRight(15));
        }
    }

    Console.WriteLine();
}

void SortByDate()
{
    ListByDate();

    MainMenu();
}

//Sort List By Project
void SortByProject()
{
    Console.WriteLine("Task".PadRight(15) + "Due Date".PadRight(15) + "Done".PadRight(15) + "Project".PadRight(15));
    Console.WriteLine("----".PadRight(15) + "--------".PadRight(15) + "----".PadRight(15) + "-------".PadRight(15));

    List<Task> sortedByProject = Context.Tasks.OrderBy(task => task.TaskProject).ToList();

    foreach (Task task in sortedByProject)
    {
        if (task.TaskStatus == true)
        {
            Console.WriteLine(task.TaskTitle.PadRight(15) + task.TaskDueDate.PadRight(15) + "Yes".PadRight(15) + task.TaskProject.PadRight(15));
        }
        else
        {
            Console.WriteLine(task.TaskTitle.PadRight(15) + task.TaskDueDate.PadRight(15) + "No".PadRight(15) + task.TaskProject.PadRight(15));
        }
    }
    MainMenu();
}


//Add New Task
void AddNewTask()
{
    Task Task1 = new Task();

    Console.WriteLine("Add New Task");
    Console.WriteLine("Enter a Task:");
    string taskTitle = Console.ReadLine();

    Console.WriteLine("Enter Due Date for the Task (MM/DD/YYYY):");
    string taskDueDate = Console.ReadLine();
    Regex dateFormat = new Regex(@"((([0][1-9])|([1][0-2]))\/(([0-2][0-9])|([3][0-1]))\/([1-2][0,1,9][0-9][0-9]))$");
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


    // Save to Database
    Task1.TaskTitle = taskTitle;
    Task1.TaskDueDate = taskDueDate;
    Task1.TaskDateTime = Convert.ToDateTime(taskDueDate);
    Task1.TaskStatus = taskStatus;
    Task1.TaskProject = taskProject;
    Context.Tasks.Add(Task1);
    Context.SaveChanges();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"{Task1.TaskTitle} was successfully added to the ToDo List!");
    Console.ResetColor();
    MainMenu();
}

// Update Task
void UpdateTask()
{
    ListByDate();
    Console.WriteLine("Enter the Title of the Task you want to Update:");
    string updateTitle = Console.ReadLine();

    List<Task> searchedTask = Context.Tasks.OrderBy(task => task.TaskTitle).ToList();
    foreach (Task task in searchedTask)
    {
        if (task.TaskTitle == updateTitle)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(task.TaskTitle.PadRight(15) + task.TaskDueDate.PadRight(15) + "No".PadRight(15) + task.TaskProject.PadRight(15));
            Console.WriteLine("--------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Enter new title to the Task");
            string newTitle = Console.ReadLine();
            Console.ResetColor();
            Console.WriteLine();

            task.TaskTitle = newTitle;
            Context.Tasks.Update(task);
            Context.SaveChanges();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(task.TaskTitle.PadRight(15) + task.TaskDueDate.PadRight(15) + "No".PadRight(15) + task.TaskProject.PadRight(15));
            Console.WriteLine("--------------------------------------------------");

            EditMenu();
        }
    }
}

// Mark Task As Done
void MarkAsDone()
{
    ListByDate();
    Console.WriteLine("Enter the Title of the Task you want to Mark As Done:");
    string titleDone = Console.ReadLine();

    List<Task> searchedTask = Context.Tasks.OrderBy(task => task.TaskTitle).ToList();
    foreach (Task task in searchedTask)
    {
        if (task.TaskTitle == titleDone)
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(task.TaskTitle.PadRight(15) + task.TaskDueDate.PadRight(15) + "No".PadRight(15) + task.TaskProject.PadRight(15));
            Console.WriteLine("--------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Mark as Done? y/n");
            string done = Console.ReadLine();
            Console.ResetColor();

            if (done == "y")
            {   
                task.TaskStatus = true;
                Context.Tasks.Update(task);
                Context.SaveChanges();

                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine(task.TaskTitle.PadRight(15) + task.TaskDueDate.PadRight(15) + "Yes".PadRight(15) + task.TaskProject.PadRight(15));
                Console.WriteLine("--------------------------------------------------");

                EditMenu();
            }
            else
            {
                EditMenu();
            }
        }
    }
}

// Remove Task
void RemoveTask()
{
    ListByDate();
    Console.WriteLine("Enter the Title of the Task you want to Delete:");
    string removeTitle = Console.ReadLine();

    List<Task> searchedTask = Context.Tasks.OrderBy(task => task.TaskTitle).ToList();
    foreach (Task task in searchedTask)
    {
        if (task.TaskTitle == removeTitle)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(task.TaskTitle.PadRight(15) + task.TaskDueDate.PadRight(15) + "No".PadRight(15) + task.TaskProject.PadRight(15));
            Console.WriteLine("--------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Remove Task? y/n");
            string remove = Console.ReadLine();
            Console.ResetColor();

            if (remove == "y")
            {
                Context.Tasks.Remove(task);
                Context.SaveChanges();
                ListByDate();

                EditMenu();
            }
            else
            {
                EditMenu();
            }
        }
    }
}


// Show Task List Options
void TaskList()
{
    ShowTaskListMenu();

    while (showListMenuAgain)
    {
        switch (listOption)
        {
            case 1:
                SortByDate();
                break;

            case 2:
                SortByProject();
                break;

            case 3:
                MainMenu();
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid option");
                Console.ResetColor();
                ShowTaskListMenu();
                break;
        }
    }
}


// Edit Tasks Options
void EditMenu()
{
    Console.WriteLine();
    EditTaskMenu();

    while (showEditMenuAgain)
    {
        switch (editOption)
        {
            case 1:
                UpdateTask();
                break;

            case 2:
                MarkAsDone();
                break;

            case 3:
                RemoveTask();
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
    Console.WriteLine();
    ShowMainMenu();

    while (showMenuAgain)
    {
        switch (option)
        {
            case 1:
                showListMenuAgain = true;
                TaskList();
                break;

            case 2:
                AddNewTask();
                break;

            case 3:
                showEditMenuAgain = true;
                EditMenu();
                break;

            case 4:
                Console.WriteLine("Save and Quit");
                Environment.Exit(0);
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid option");
                Console.ResetColor();
                ShowMainMenu();
                break;
        }

    }
}


// Call the Main Menu the first time
MainMenu();



class Task
{
    public Task()
    {
    }

    public Task(string taskTitle, string taskDueDate, DateTime taskDateTime, bool taskStatus, string taskProject)
    {
        TaskTitle = taskTitle;
        TaskDueDate = taskDueDate;
        TaskDateTime = taskDateTime;
        TaskStatus = taskStatus;
        TaskProject = taskProject;
    }
    public int Id { get; set; }
    public string TaskTitle { get; set; }
    public string TaskDueDate { get; set; }
    public DateTime TaskDateTime { get; set; }
    public bool TaskStatus { get; set; }
    public string TaskProject { get; set; }
}
