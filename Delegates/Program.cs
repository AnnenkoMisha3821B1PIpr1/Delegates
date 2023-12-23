using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace TaskM
{
    delegate void Update_Stat(Task task);
    class Task
    {
        public Update_Stat? Update;
        public string Name;
        public bool Status;
        public string Description;

        public Task(string name, bool status, string description)
        {
            Name = name;
            Status = status;
            Description = description;
        }
    }

    class TaskManager
    {
        public Task Add_New_Task(string name, bool status, string description)
        {
            Task task = new Task(name, status, description);
            return task;
        }

        public void CompleteTask(Task task)
        {
            task.Status = true;
            Some_Kind_Of_Class random = new Some_Kind_Of_Class();
            task.Update = random.TaskCompletedNotification;
            task.Update(task);
        }
    }

    class Some_Kind_Of_Class
    {
        public void TaskCompletedNotification(Task task) => Console.WriteLine("Выполнена задача под названием: {0}", task.Name);
    }

    class Program
    {
        static void Main()
        {
            List<Task> tasks = new List<Task>();
            TaskManager taskManager = new TaskManager();

            Task task1 = taskManager.Add_New_Task("Задача 1", false, "Помыть посуду");
            Task task2 = taskManager.Add_New_Task("Задача 2", false, "Вынести мусор");
            Task task3 = taskManager.Add_New_Task("Задача 3", false, "Забрать сестру из школы");

            tasks.Add(task1);
            tasks.Add(task2);
            tasks.Add(task3);

            foreach (Task task in tasks)
            {
                Console.WriteLine("{0} : Статус: {1} ", task.Name, task.Status);
            }
            Console.WriteLine();


            taskManager.CompleteTask(task3);

            foreach (Task task in tasks)
            {
                Console.WriteLine("{0} : Статус: {1} ", task.Name, task.Status);
            }
            Console.WriteLine();
        }
    }
}