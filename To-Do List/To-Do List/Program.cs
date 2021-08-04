using CommandLine;
using System;
using System.Globalization;
using System.Threading;
using To_Do_List.Models;

namespace To_Do_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser(with => {
                with.ParsingCulture = new CultureInfo("en-GB");
                with.HelpWriter = Console.Out;
                });
            var result = parser.ParseArguments<AddOptions, ViewOptions>(args)
                   .WithParsed<AddOptions>(o =>
                   {
                       var newTask = AddTask.AddNewTask(o);
                      
                   })
                   .WithParsed<ViewOptions>(o =>
                   {
                       ViewTask.ViewTasks(o);
                   });
        }
    }
}
