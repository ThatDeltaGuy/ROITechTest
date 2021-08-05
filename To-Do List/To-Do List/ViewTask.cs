using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using To_Do_List.Models;

namespace To_Do_List
{
    public static class ViewTask
    {
        public static bool ViewTasks(ViewOptions viewOptions)
        {
            SharedMethods.CheckForFile();

            var tasks = ReadFile(viewOptions.Sort,viewOptions.Filter);

            if (viewOptions.Complete)
            {
                var ids = tasks.Select(o => o.Id).ToList();
                Console.WriteLine($"Are you sure you wish to update Task IDs:{string.Join(Config.Delimiter, ids)}? Y /N");
                var response = Console.ReadLine();

                if (response != "Y" && response != "y")
                    return false;
                SharedMethods.CompleteTasksById(ids);
            }

            DisplayTasks(tasks);

            return true;
        }

        public static List<Task> ReadFile(string sort = null, string filter = null)
        {
            List<Task> tasks = File.ReadAllLines(Config.Path)
                                           .Skip(1)
                                           .Select((v,i) => Task.FromCsv(v,i+1))
                                           .ToList();

            var props = typeof(Task).GetProperties();

            if (!String.IsNullOrWhiteSpace(filter))
            {
                if(DateTime.TryParse(filter, out DateTime result))
                {
                    tasks = tasks.Where(o => o.Date == result).ToList();
                }
                else
                {
                    tasks = tasks.Where(o => o.Title.ToLower().Contains(filter.ToLower())).ToList();
                }
            }

            if (!string.IsNullOrWhiteSpace(sort)){
                if(props.Select(o => o.Name).Contains(sort))
                {
                    Func<Task, Object> orderByFunc = null;
                    switch (sort)
                    {
                        case "Title":
                            orderByFunc = task => task.Title;
                            break;
                        case "Date":
                            orderByFunc = task => task.Date;
                            break;
                        case "Description":
                            orderByFunc = task => task.Description;
                            break;
                        case "Completed":
                            orderByFunc = task => task.Completed;
                            break;
                    }

                    tasks = tasks.OrderBy(orderByFunc).ToList();
                }
            }

            return tasks;
        }
        public static void DisplayTasks(List<Task> tasks)
        {
            Console.WriteLine($"Total number of Tasks Returned: {tasks.Count}");

            var props = typeof(Task).GetProperties();
            Console.WriteLine(string.Join(Config.Delimiter, props.Select(o => o.Name)));
            foreach (var task in tasks)
            {
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
}
