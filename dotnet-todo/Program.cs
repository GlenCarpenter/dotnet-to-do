using System;

namespace dotnet_todo
{
    class Program
    {
        static void Main(string[] args)
        {
            // initializing todo list
            ToDoList myToDos = new ToDoList();
            int selection = 0;

            // vars for current selection
            String newTask;
            int currentToDo;

            Console.WriteLine("Welcome to the to-do list!\n\n");

            // main program
            do
            {
                Console.WriteLine("\nWhat would you like to do?\n");
                Console.WriteLine("1. Add a to-do.");
                Console.WriteLine("2. Complete a to-do.");
                Console.WriteLine("3. Update a to-do item.");
                Console.WriteLine("4. Show all to-do items.");
                Console.WriteLine("5. Delete a to-do item.");
                Console.WriteLine("6. Quit.");

                selection = Convert.ToInt32(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        Console.WriteLine("\nEnter the new to-do item: ");
                        newTask = Console.ReadLine();
                        myToDos.AddToDo(newTask);
                        Console.WriteLine("\nNew item added.\n");
                        break;
                    case 2:
                        myToDos.PrintToDos();
                        Console.WriteLine("\nEnter the number of the task you would like to mark as completed:");
                        currentToDo = Convert.ToInt32(Console.ReadLine()) - 1;
                        myToDos.CompleteToDo(currentToDo);
                        Console.WriteLine($"\nTask #{currentToDo + 1} marked as 'Complete'.\n");
                        break;
                    case 3:
                        myToDos.PrintToDos();
                        Console.WriteLine("\nEnter the number of the task you would like to update:");
                        currentToDo = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.WriteLine("Enter the new task:");
                        newTask = Console.ReadLine();
                        myToDos.UpdateTask(newTask, currentToDo);
                        Console.WriteLine($"\nTask #{currentToDo + 1} updated.\n");
                        break;
                    case 4:
                        myToDos.PrintToDos();
                        break;
                    case 5:
                        myToDos.PrintToDos();
                        Console.WriteLine("\nEnter the number of the task you would like to delete:");
                        currentToDo = Convert.ToInt32(Console.ReadLine()) - 1;
                        myToDos.RemoveToDo(currentToDo);
                        Console.WriteLine($"\nTask #{currentToDo + 1} deleted.\n");
                        break;
                    case 6:
                        Console.WriteLine("\nGood bye!\n");
                        break;
                    default:
                        Console.WriteLine("\nInvalid selection!\n");
                        break;
                }

            }
            while (selection != 6);

        }
    }
}
