using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace To_Do_List.Models
{
    [Verb("add", false, HelpText = "Adds a Task")]
    public class AddOptions: ITask
    {
        [Option('t', "title", Required = true, HelpText = "Task Title.")]
        public string Title { get; set; }

        [Option('d', "due-date", Required = true, HelpText = "Task Due Date.")]
        public DateTime Date { get; set; }

        [Option("description", Required = false, HelpText = "Task Description.")]
        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}
