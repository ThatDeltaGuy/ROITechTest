using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using To_Do_List.Models;

namespace To_Do_List
{
    public static class CompleteTask
    {
        public static bool MarkTaskComplete(CompleteOptions completeOptions)
        {
            SharedMethods.CheckForFile();
            Console.WriteLine($"Are you sure you wish to update Task ID:{completeOptions.Id}? Y/N");
            var response = Console.ReadLine();

            if (response != "Y" && response != "y")
                return false;

            SharedMethods.CompleteTasksById(completeOptions.Id);
            var task = ReadFile(completeOptions.Id);
            DisplayTask(task);
            return true;
        }

        public static Task ReadFile(int Id)
        {
            Task task = File.ReadAllLines(Config.Path)
                                           .Skip(Id)
                                           .Take(1)
                                           .Select((v, i) => Task.FromCsv(v, Id))
                                           .First();
            return task;
        }
        public static void DisplayTask(Task task)
        {
            Console.WriteLine($"Task Updated:");

            var props = typeof(Task).GetProperties();
            Console.WriteLine(string.Join(Config.Delimiter, props.Select(o => o.Name)));
            var strings = new List<string>();
            foreach (PropertyInfo prop in props)
            {
                var propValue = prop.GetValue(task)?.ToString();
                strings.Add(propValue);
            }
            Console.WriteLine(string.Join(Config.Delimiter, strings));
        }

        
    }
}
