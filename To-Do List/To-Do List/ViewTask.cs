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

            DisplayTasks(tasks);

            if (viewOptions.Complete)
                CompleteTasks(tasks.Select(o => o.Id).ToList());

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
                    tasks = tasks.Where(o => o.Title.Contains(filter)).ToList();
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

        public static void CompleteTasks(List<int> taskLines)
        {
            throw new NotImplementedException();
        }
    }
}
