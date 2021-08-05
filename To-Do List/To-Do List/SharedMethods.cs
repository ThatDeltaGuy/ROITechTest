using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using To_Do_List.Models;

namespace To_Do_List
{
    public static class SharedMethods{
        public static void CheckForFile()
        {
            if (File.Exists(Config.Path))
                return;

            var props = typeof(AddOptions).GetProperties().Select(o => o.Name);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Join(Config.Delimiter, props));
            File.WriteAllText(Config.Path, sb.ToString());
        }

        public static void CompleteTasksById(int taskLine)
        {
            CompleteTasksById(new List<int> { taskLine });
        }

        public static void CompleteTasksById(List<int> taskLines)
        {
            var lines = File.ReadAllLines(Config.Path);
            foreach (var lineNum in taskLines)
            {
                var line = lines[lineNum].Split(',');
                line[line.Length - 1] = true.ToString();
                lines[lineNum] = string.Join(Config.Delimiter, line);
            }

            File.WriteAllLines(Config.Path, lines);
        }
    }
}
