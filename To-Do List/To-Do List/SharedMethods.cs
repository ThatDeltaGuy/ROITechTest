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
    }
}
