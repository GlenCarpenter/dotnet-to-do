using System;

namespace dotnet_todo
{
    class Program
    {
        // initializing todo list
        static ToDoList myToDos = new ToDoList();
        static String Input { get; set; }
        static int selection;

        // vars for current selection
        static String NewTask { get; set; }
        static String currentInput;
        static int currentToDo;

        // declare delegate for callbacks
        public delegate void Callback();
        static bool callbackExecuted = false;
        static void Main(string[] args)
        {
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

                Input = Console.ReadLine();
                if (int.TryParse(Input, out selection))
                {
                    switch (selection)
                    {
                        case 1:
                            Console.WriteLine("\nEnter the new to-do item: ");
                            NewTask = Console.ReadLine();
                            myToDos.AddToDo(NewTask);
                            Console.WriteLine("\nNew item added.\n");
                            break;
                        case 2:
                            if (CheckNoOfToDos())
                            {
                                myToDos.PrintToDos();
                                Console.WriteLine("\nEnter the number of the task you would like to mark as completed:");
                                do
                                { GetInput(MarkAsComplete); }
                                while (!callbackExecuted);
                                break;
                            }
                            break;
                        case 3:
                            if (CheckNoOfToDos())
                            {
                                myToDos.PrintToDos();
                                Console.WriteLine("\nEnter the number of the task you would like to update:");
                                do
                                { GetInput(UpdateToDo); }
                                while (!callbackExecuted);
                                break;
                            }
                            break;
                        case 4:
                            myToDos.PrintToDos();
                            break;
                        case 5:
                            if (CheckNoOfToDos())
                            {
                                myToDos.PrintToDos();
                                Console.WriteLine("\nEnter the number of the task you would like to delete:");
                                do
                                { GetInput(DeleteToDo); }
                                while (!callbackExecuted);
                                break;
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

        // Option methods
        static void MarkAsComplete()
        {
            myToDos.CompleteToDo(currentToDo - 1);
            Console.WriteLine($"\nTask #{currentToDo} marked as 'Complete'.\n");
        }

        static void UpdateToDo()
        {
            Console.WriteLine("Enter the new task:");
            NewTask = Console.ReadLine();
            myToDos.UpdateTask(NewTask, currentToDo - 1);
            Console.WriteLine($"\nTask #{currentToDo} updated.\n");
        }

        static void DeleteToDo()
        {
            myToDos.RemoveToDo(currentToDo - 1);
            Console.WriteLine($"\nTask #{currentToDo} deleted.\n");
        }

        // Helper methods
        static bool CheckNoOfToDos()
        {
            if (myToDos.Count() == 0)
            {
                Console.WriteLine("Error: You need to create a to-do item to perform this task.");
                return false;
            }
            return true;
        }
        static void GetInput(Callback callBack)
        {
            callbackExecuted = false;
            currentInput = Console.ReadLine();

            if (int.TryParse(currentInput, out currentToDo))
            {
                ValidateInput();
                callBack();
                callbackExecuted = true;
            }
            else
            {
                Console.WriteLine("\nInvalid selection! Please enter a number:");
            }
        }

        static bool CheckRange()
        {
            if (currentToDo < 1 || currentToDo > myToDos.Count())
            {
                Console.WriteLine($"\nInvalid selection. Select a number between 1 and {myToDos.Count()}.");
                return true;
            }
            return false;
        }

        static void ValidateInput()
        {
            while (CheckRange())
            {
                currentInput = Console.ReadLine();
                if (int.TryParse(currentInput, out currentToDo))
                {
                    CheckRange();
                }
                else
                {
                    Console.WriteLine("\nInvalid selection! Please enter a number.\n");
                }
            }
        }
    }
}
