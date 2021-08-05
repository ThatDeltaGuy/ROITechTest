using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace To_Do_List.Models
{
    [Verb("complete", false, HelpText = "Completes a Task")]
    public class CompleteOptions
    {
        [Option('i', "id", Required = false, HelpText = "Id of task to complete")]
        public int Id { get; set; }

    }
}
