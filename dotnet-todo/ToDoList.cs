using System;
using System.Collections.Generic;

namespace dotnet_todo
{
    class ToDoList
    {
        List<ToDo> toDos = new List<ToDo>();
        public ToDoList()
        {
        }

        public void AddToDo(String task)
        {
            toDos.Add(new ToDo(task));
        }

        public void CompleteToDo(int i)
        {
            toDos[i].IsComplete = true;
        }

        public void UpdateTask(String task, int i)
        {
            toDos[i].Task = task;
        }

        public void RemoveToDo(int i)
        {
            toDos.RemoveAt(i);
        }

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
    }
}
