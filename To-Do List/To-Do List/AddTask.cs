using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using To_Do_List.Models;

namespace To_Do_List
{
    public static class AddTask
    {
        public static bool AddNewTask(AddOptions addOptions)
        {
            CheckForFile();
            Console.WriteLine(addOptions.Title);
            Console.WriteLine(addOptions.Date);
            Console.WriteLine(addOptions.Description);
            WriteToFile(addOptions);
            return true;
        }

        private static void CheckForFile()
        {
            if (File.Exists(Config.Path))
                return;

            var props = typeof(AddOptions).GetProperties().Select(o=>o.Name);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Join(Config.Delimiter, props));
            File.WriteAllText(Config.Path, sb.ToString());
        }

        private static void WriteToFile(AddOptions addOptions)
        {
            var props = typeof(AddOptions).GetProperties();
            var strings = new List<string>();
            foreach (PropertyInfo prop in props)
            {
                var propValue = prop.GetValue(addOptions)?.ToString();
                strings.Add(propValue);
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Join(Config.Delimiter, strings));
            File.AppendAllText(Config.Path, sb.ToString());
        }
    }
}
