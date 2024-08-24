using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

class Task
{
    public Task(int id, string description, bool isCompleted)
    {
        ID = id;
        Description = description;
        IsCompleted = isCompleted;
    }

    public int ID { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public override string ToString()
    {
        return $"Task ID: {ID}, Task description: {Description}, " +
            $"Task condition: {(IsCompleted ? "Completed" : "Pending")}";
    }
}
class Program
{
    static List<Task> tasks = new List<Task>();
    static int taskIdCounter = 0;
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("To-Do List:");
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark Task as Complete");
            Console.WriteLine("4. Remove Task");
            Console.WriteLine("5. Exit");
            Console.ResetColor();
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    MarkTaskComplete();
                    break;
                case "4":
                    RemoveTask();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.\n");
                    break;
            }
        }
    }
    static void AddTask()
    {
        Console.Write("Enter task description: ");
        string description = Console.ReadLine();
        tasks.Add(new Task(++taskIdCounter, description, false));
        Console.WriteLine("Task added.\n");
    }
    static void ViewTasks()
    {
        if (tasks.Count > 0)
        {
            Console.WriteLine("Tasks:");
            foreach (Task task in tasks)
            {
                Console.WriteLine(task);
            }
            Console.WriteLine();
        }
        else
            Console.WriteLine("No tasks to show.\n");
    }
    static void MarkTaskComplete()
    {
        try
        {
            if (tasks.Count > 0)
            {
                Console.Write("Enter the task ID to mark as complete: ");
                int id = int.Parse(Console.ReadLine());
                Task taskToMark = tasks.FirstOrDefault(t => t.ID == id);
                if (taskToMark != null)
                {
                    taskToMark.IsCompleted = true;
                    Console.WriteLine("Task marked as complete.\n");
                }
                else
                    Console.WriteLine("Task not found.\n");
            }
            else
                Console.WriteLine("No available tasks.\n");
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input.");
        }
    }
    static void RemoveTask()
    {
        try
        {
            if (tasks.Count > 0)
            {
                Console.Write("Enter the task ID to remove: ");
                int id = int.Parse(Console.ReadLine());
                Task taskToRemove = tasks.FirstOrDefault(t => t.ID == id);
                if (taskToRemove != null)
                {
                    tasks.Remove(taskToRemove);
                    Console.WriteLine("Task removed.\n");
                }
                else
                    Console.WriteLine("Task not found.\n");
            }
            else
                Console.WriteLine("No available tasks.\n");
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input.");
        }
    }
}
