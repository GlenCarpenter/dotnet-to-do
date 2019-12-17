using System;

namespace dotnet_todo
{
    class ToDo
    {
        public String Task { get; set; }
        public bool IsComplete { get; set; }

        public ToDo(String task)
        {
            this.Task = task;
            this.IsComplete = false;
        }

    }
}
