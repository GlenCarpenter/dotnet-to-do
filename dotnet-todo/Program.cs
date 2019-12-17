using System;

namespace dotnet_todo
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDoList myToDos = new ToDoList();
            int selection = 0;

            Console.WriteLine("Welcome to the to-do list!\n\n");

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
                        String newTask;
                        Console.WriteLine("\nEnter the new to-do item: ");
                        newTask = Console.ReadLine();
                        myToDos.AddToDo(newTask);
                        Console.WriteLine("\nNew item added.\n");
                        break;
                    case 2:
                        int toDoToComplete;
                        myToDos.PrintToDos();
                        Console.WriteLine("\nEnter the number of the task you would like to mark as completed:");
                        toDoToComplete = Convert.ToInt32(Console.ReadLine()) - 1;
                        myToDos.CompleteToDo(toDoToComplete);
                        Console.WriteLine($"\nTask #{toDoToComplete + 1} marked as 'Complete'.\n");
                        break;
                    case 3:
                        String newTaskForUpdate;
                        int toDoToUpdate;
                        myToDos.PrintToDos();
                        Console.WriteLine("\nEnter the number of the task you would like to update:");
                        toDoToUpdate = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.WriteLine("Enter the new task:");
                        newTaskForUpdate = Console.ReadLine();
                        myToDos.UpdateTask(newTaskForUpdate, toDoToUpdate);
                        Console.WriteLine($"\nTask #{toDoToUpdate + 1} updated.\n");
                        break;
                    case 4:
                        myToDos.PrintToDos();
                        break;
                    case 5:
                        int toDoToDelete;
                        myToDos.PrintToDos();
                        Console.WriteLine("\nEnter the number of the task you would like to delete:");
                        toDoToDelete = Convert.ToInt32(Console.ReadLine()) - 1;
                        myToDos.RemoveToDo(toDoToDelete);
                        Console.WriteLine($"\nTask #{toDoToDelete + 1} deleted.\n");
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
