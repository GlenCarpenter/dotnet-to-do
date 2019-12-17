using System;

namespace dotnet_todo
{
    class Program
    {
        static void Main(string[] args)
        {
            // initializing todo list
            ToDoList myToDos = new ToDoList();
            String input;
            int selection;

            // vars for current selection
            String newTask;
            String currentInput;
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

                input = Console.ReadLine();
                if (int.TryParse(input, out selection))
                {
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
                            currentInput = Console.ReadLine();
                            if (int.TryParse(currentInput, out currentToDo))
                            {
                                while (CheckRange(myToDos, currentToDo))
                                {
                                    currentInput = Console.ReadLine();
                                    if (int.TryParse(currentInput, out currentToDo))
                                    {
                                        CheckRange(myToDos, currentToDo);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nInvalid selection! Please enter a number.\n");
                                    }
                                }
                                myToDos.CompleteToDo(currentToDo - 1);
                                Console.WriteLine($"\nTask #{currentToDo} marked as 'Complete'.\n");
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid selection! Please enter a number.\n");
                            }
                            break;
                        case 3:
                            myToDos.PrintToDos();
                            Console.WriteLine("\nEnter the number of the task you would like to update:");
                            currentInput = Console.ReadLine();
                            if (int.TryParse(currentInput, out currentToDo))
                            {
                                while (CheckRange(myToDos, currentToDo))
                                {
                                    currentInput = Console.ReadLine();
                                    if (int.TryParse(currentInput, out currentToDo))
                                    {
                                        CheckRange(myToDos, currentToDo);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nInvalid selection! Please enter a number.\n");
                                    }
                                }
                                Console.WriteLine("Enter the new task:");
                                newTask = Console.ReadLine();
                                myToDos.UpdateTask(newTask, currentToDo - 1);
                                Console.WriteLine($"\nTask #{currentToDo} updated.\n");
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid selection! Please enter a number.\n");
                            }
                            break;
                        case 4:
                            myToDos.PrintToDos();
                            break;
                        case 5:
                            myToDos.PrintToDos();
                            Console.WriteLine("\nEnter the number of the task you would like to delete:");
                            currentInput = Console.ReadLine();
                            if (int.TryParse(currentInput, out currentToDo))
                            {
                                while (CheckRange(myToDos, currentToDo))
                                {
                                    currentInput = Console.ReadLine();
                                    if (int.TryParse(currentInput, out currentToDo))
                                    {
                                        CheckRange(myToDos, currentToDo);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nInvalid selection! Please enter a number.\n");
                                    }
                                }
                                myToDos.RemoveToDo(currentToDo - 1);
                                Console.WriteLine($"\nTask #{currentToDo} deleted.\n");
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid selection! Please enter a number.\n");
                            }
                            break;
                        case 6:
                            Console.WriteLine("\nGood bye!\n");
                            break;
                        default:
                            Console.WriteLine("\nInvalid selection!\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid selection! Please enter a number.\n");
                }

            }
            while (selection != 6);

        }

        static bool CheckRange(ToDoList list, int index)
        {
            if (index < 1 || index > list.Count())
            {
                Console.WriteLine($"\nInvalid selection. Select a number between 1 and {list.Count()}.");
                return true;
            }
            return false;
        }
    }
}
