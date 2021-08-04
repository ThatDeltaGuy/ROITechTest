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
            SharedMethods.CheckForFile();
            WriteToFile(addOptions);
            return true;
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

            Console.WriteLine($"Added {sb} To File");
        }
    }
}
