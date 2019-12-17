using System;
using System.Collections.Generic;

namespace dotnet_todo
{
    class ToDoList
    {
        // ToDoList is a List<T> of ToDos
        List<ToDo> toDos = new List<ToDo>();
        public ToDoList()
        {
        }
        
        // Add a task
        public void AddToDo(String task)
        {
            toDos.Add(new ToDo(task));
        }

        // Mark task as complete
        public void CompleteToDo(int i)
        {
            toDos[i].IsComplete = true;
        }

        // Update task at index 'i'
        public void UpdateTask(String task, int i)
        {
            toDos[i].Task = task;
        }

        // Remove task as index 'i'
        public void RemoveToDo(int i)
        {
            toDos.RemoveAt(i);
        }

        // Log all items to console
        public void PrintToDos()
        {
            Console.WriteLine("\n\n");
            for (int i = 0; i < toDos.Count; i++)
            {
                String status = toDos[i].IsComplete ? "Complete" : "Not Started";
                Console.WriteLine($"ToDo Item #{i + 1}: {toDos[i].Task}");
                Console.WriteLine($"Status: {status}\n");
            }
        }

        // Returns count of items
        public int Count()
        {
            return toDos.Count;
        }
    }
}
